# Fountain
A map painting/generating software kit for worldbuilders.

#Installation
Fountain for Windows can be downloaded for installation [here](https://github.com/Mavichist/Fountain/releases).

If you would like to run Fountain on Mac OSX or Linux, download the windows binary (linked above) and run it using [Mono](http://www.mono-project.com/). Once Mono is installed; running Fountain should be as easy as typing 'mono pathto/Fountain.exe' into your commandline.

# Known Issues/To Do List

* Undo and Redo functions don't exist yet for painting. I know about this one and it's a real problem so I'm devoting quite a bit of attention to it.

#Tutorials
Fountain might be a bit of a headache for some people - it's designed to be very, very flexible but with that comes certain magnitudes of complexity that most people might not be willing to accept. Much of this complexity comes from the brush and effect scripting, but thankfully; much of that will be done away with if you grab brushes and effects from the tutorials or other users.

##1: The Document
A Fountain document contains renders, brushes, effects and gradients. When you save a Fountain document, the brush and effect scripts are saved to the file along with the heightmaps behind the renders and the data from your gradients.

Adding any of these four elements to a document is easy - click the appropriate tab, then type a name for the item into the combo box. Once you're happy with the name, hit enter to create a new render, brush, effect or gradient and add it to the document. A window will appear allowing you to alter the attributes of the item - this window can always be re-opened by clicking the appropriate 'Edit' option later in the same tab.

##2: Renders
Renders are the images and accompanying heightmaps that constitute the goal and output of the entire program. When adding a render to a document, consider what attributes might be appropriate for it. If the render is to be a world map then consider selecting horizontal (x-axis) wrapping so that you can paint accross the edge of the map and have the result wrap back to the other side.

Renders are subject to both Gradients and Effects. Gradients determine how the heightmaps are colorized, while Effects alter the appearance of a Render even further. If no Gradients are supplied, the render will simply appear in grayscale.

##3: Scripting
Renders and gradients are simple enough but things get trickier when dealing in brushes and effects. This is because there is no default implementation for brushes or effects in Fountain; you need to write your own or use someone elses.

The actual scripting component of Fountain is performed in a language called C#, and it's actually not as troublesome as it might appear. Your scripts can include anything (including classes, structs, global variables, enumerated types and other functions) but principally they will only consist of a function or two, depending on what you're scripting.

In Fountain's scripting you have access to a couple of helper APIs that I've written. They mostly deal with annoying math functionality and the like.

###Brushes
Brushes are integral if you want to do any painting in Fountain. Their scripts consist of two parts; the 'Sample' function, and the 'Blend' function. The 'Sample' function defines the shape of your brush, while the 'Blend' function denotes how the shape is blended into the area you are painting.

Soft, circular brushes are a caste favourite in image manipulation - they're incredibly useful. Essentially what this script is doing is determining how far the current point (at the coordinates of 'x' and 'y') is from the center of the brush area (halfway between 'top' 'left' and 'bottom' 'right').

```
float Sample(int x, int y, float intensity, int left, int right, int top, int bottom)
{
	float u = (float)(x - left) / (right - left) * 2.0f - 1.0f;
	float v = (float)(y - top) / (bottom - top) * 2.0f - 1.0f;
	float d = 1.0f - (float)Math.Sqrt(u * u + v * v);
	if (d < 0)
		d = 0f;
	return d * intensity;
}
float Blend(float baseValue, float newValue)
{
	return baseValue + newValue;
}
```

Smoothing brushes attempt to even out an area. The one listed below tries to level the area it affects, sinking high areas and raising low ones:

```
float smoothTarget = 0.5f;

float Sample(int x, int y, float intensity, int left, int right, int top, int bottom)
{
	float u = (float)(x - left) / (right - left) * 2.0f - 1.0f;
	float v = (float)(y - top) / (bottom - top) * 2.0f - 1.0f;
	float d = 1.0f - (float)Math.Sqrt(u * u + v * v);
	if (d < 0)
		d = 0f;
	return d * intensity;
}
float Blend(float baseValue, float newValue)
{
	float delta = smoothTarget - baseValue;
	return baseValue + delta * newValue;
}
```

The next sample brush is useful for adding random detail to your renders. It acts like a smooth circular brush for the most part, but it also adds a random value to every sample point to add fine detail.

```
Random r = new Random(0);
float jitter = 0.03f;

float Sample(int x, int y, float intensity, int left, int right, int top, int bottom)
{
	float u = (float)(x - left) / (right - left) * 2.0f - 1.0f;
	float v = (float)(y - top) / (bottom - top) * 2.0f - 1.0f;
	float d = 1.0f - (float)Math.Sqrt(u * u + v * v);
	if (d < 0) d = 0f;
	return d * intensity + (jitter / 2 - (float)r.NextDouble() * jitter) * d;
}
float Blend(float baseValue, float newValue)
{
	return baseValue + newValue;
}
```

Finally; the most useful brush: The noise brush. These brushes use a noise field to generate random strokes. They add an element of chaos to your coastlines and terrain, making them look more organic.

```
NoiseGenerator gen = new PerlinNoise(0, 4, 0.1f, 2, 0.5f);

float Sample(int x, int y, float intensity, int left, int right, int top, int bottom)
{
	float u = (float)(x - left) / (right - left) * 2.0f - 1.0f;
	float v = (float)(y - top) / (bottom - top) * 2.0f - 1.0f;
	float d = 1.0f - (float)Math.Sqrt(u * u + v * v);
	if (d < 0)
		d = 0f;
	return d * intensity * gen.Sample(x, y);
}
float Blend(float baseValue, float newValue)
{
	return baseValue + newValue;
}
```

###Effects
Effects are functions that are laid over the render when it updates. They can be really simple or really tricky, but the couple of following examples should demonstrate them relatively clearly.

The most basic effects will be things like overlays that simply change the color of the render. The following effect script tints the entire render red:

```
Photon tintColor = new Photon(1.0f, 0.0f, 0.0f, 1.0f);

Photon Apply(int x, int y, Photon color, HeightField heightField)
{
	return Photon.InterpolateLinear(color, tintColor, 0.2f);
}
```

Shadowing is a really nice thing to have because it adds depth to your maps. All this script does is compare the height of the current sample point to the height of the sample point above it and to the left. If the upper point is higher, it applies a shadow. If the upper point is lower, it applies lighting.

```
float contrast = 3;
float cutOff = 0.5f;
Photon lightColor = new Photon(1.0f, 0.8f, 0.7f, 1.0f);
Photon shadowColor = new Photon(0.0f, 0.2f, 0.3f, 1.0f);

Photon Apply(int x, int y, Photon color, HeightField heightField)
{
	float sample;
	float upper;
	if (heightField.TryGetHeight(x, y, out sample) & sample >= cutOff & heightField.TryGetHeight(x - 1, y - 1, out upper))
	{
		float t = (RemoveCutOff(upper) - RemoveCutOff(sample)) * contrast;
		if (t >= 0) return Photon.InterpolateLinear(color, shadowColor, t);
		else return Photon.InterpolateLinear(color, lightColor, -t);
	}
	else return color;
}
public float RemoveCutOff(float sample)
{
	return (sample - cutOff) / (1 - cutOff);
}
```

Contouring is also a nice thing to have when painting maps - it gives you a sense of scale. The following script is a bit trickier to follow, but essentially it's breaking the height value down into a given number of levels, and checking to see whether any of the surrounding heights are a level below the current one. If one of them is; then the current sample point rest on the border between those levels and needs to be highlighted as a contour.

```
float contrast = 0.4f;
int stepCount = 10;
float cutOff = 0.5f;

Photon Apply(int x, int y, Photon color, HeightField heightField)
{
	float sample;
	if (heightField.TryGetHeight(x, y, out sample) && sample >= cutOff)
	{
		float thresshold = (float)Math.Floor(RemoveCutOff(sample) * stepCount) / stepCount;
		
		if (heightField.TryGetHeight(x - 1, y, out sample) && RemoveCutOff(sample) < thresshold)
			color *= contrast;
		else if (heightField.TryGetHeight(x + 1, y, out sample) && RemoveCutOff(sample) < thresshold)
			color *= contrast;
		else if (heightField.TryGetHeight(x, y + 1, out sample) && RemoveCutOff(sample) < thresshold)
			color *= contrast;
		else if (heightField.TryGetHeight(x, y - 1, out sample) && RemoveCutOff(sample) < thresshold)
			color *= contrast;
	}
	return color;
}
float RemoveCutOff(float sample)
{
	return (sample - cutOff) / (1 - cutOff);
}
```

##4: C# Scripting Conventions
Scripting in Fountain utilizes C#'s dynamic assembly. The language isn't the easiest for beginners, so here are a few conventions that will come in handy when trying to decipher scripts and write your own.

###Semicolons
Semicolons tell C# that you're done with your current instruction. They need to be placed after pretty much everything you do. You'll see them frequently in example scripts; just remember that they _are_ necessary. If your code fails to compile and you can't figure out why; check for missing semicolons first because it's a common mistake.

###Logical Statements and Operators
Logical operators and statements are bread and butter in programming languages. There's already a wealth of documentation about them so I'll refrain from re-inventing the wheel and instead [link the page](https://msdn.microsoft.com/en-us/library/xt4z8b0f.aspx) that I myself learned them from.

###Variables
At the end of the day, all programs really do is manipulate information, and you store said information in variables. [This page](https://msdn.microsoft.com/en-us/library/wew5ytx4(v=vs.90).aspx) describes them more thoroughly than I ever could.

###Structures and Objects
Scripting doesn't just let you write functions; you can write classes and structures as well if you need them. Detail on objects can be found [here](https://msdn.microsoft.com/en-us/library/ey4ke239(v=vs.90).aspx), while detail on structures/value types can be found [here](https://msdn.microsoft.com/en-us/library/89892kc7(v=vs.90).aspx).

##5: Scripting API
There are a few helper classes that you can utilize in scripting. I've written them for my own personal use, but they have a lot of functionality that really helps shorten the amount of code you need to write. Some of the following functions will be fairly mandatory for effect scripts in particular.

###Numerics
The Numerics class has a whole heap of helper functions for math-related use. You can call these functions in your script by typing "Numerics._FunctionName_(_InputVariables_)". Be sure to separate the input variables with commas.
* Clamp - The clamp function will take a number, a minimum and a maximum, and return a number that is bound by those constraints.
* InterpolateCubic - Interpolates between two numbers using a cubic function and a linear amount value between 0 and 1.
* InterpolateLinear - Interpolates between two numbers using a linear function and a linear amount value between 0 and 1.
* Modulo - performs a modulo operation by repeating a given number by another number.
* Floor - Takes a value and rounds it down to the nearest whole value.
* Ceiling - Takes a value and rounds it up to the nearest whole value.
* Round - Takes a value and rounds it to the nearest whole value.
* Min - Returns the smallest of the two supplied values.
* Max - Returns the largest of the two supplied values.
* Pow - Raises a given value to the power of a second value. This function handles negative and fractional powers, but is slower than the 'Power' function.
* Power - Raises a given value to the power of a second integer value.
* Abs - Returns the supplied value, but positive if it wasn't already.

###HeightRender
This class is the heart and soul of your renders; it holds all the information related to the topology of your map.

The principal functions that you need to worry about are _TryGetValue_ and _TrySetValue_. The former function will attempt to get a height value from the field, while the latter will attempt to edit a value in the field. Both functions return a value of either _true_ or _false_ that denotes whether the location you supplied was within the bounds of the field (this includes wrapping, if wrapping is enabled).

You can use them like this...

```
float sample;
if (heightField.TryGetValue(10, 8, out sample))
{
	//Your sample value is now equal to the height value at the location x = 10, y = 8.
}
else
{
	//Your sample value will be equal to zero because the location lay outside the field.
}
```

or like this:

```
if (heightField.TrySetValue(10, 8, 100.3f))
{
	//Your location lay within the field and the value is now equal to 100.3 (subject to clamping, if the field is set to clamp values).
}
else
{
	//Your location lay outside the field and nothing in the field was changed.
}
```

###Photon
Photons are a simple little structures that denote colors. They contain a value each for _red_, _green_, _blue_ and _transparency_. They are predominantly used in effect scripting.

Photons can be made by doing the following:

```
Photon white = new Photon(1.0f, 1.0f, 1.0f, 1.0f);
Photon red = new Photon(1.0f, 0.0f, 0.0f, 1.0f);
Photon yellow = new Photon(1.0f, 1.0f, 0.0f, 1.0f);
Photon transparent = new Photon(0.0f, 0.0f, 0.0f, 0.0f);
```

They can be added together (so adding _red_ to _blue_ will yield a Photon that denotes purple), multiplied together (color burn), multiplied by a number (increasing or decreasing brightness) and subtracted from one-another:

```
Photon red = new Photon(1.0f, 0.0f, 0.0f, 1.0f);
Photon blue = new Photon(0.0f, 0.0f, 1.0f, 1.0f);
Photon purple = red + blue;
Photon black = red * blue; //Because the parts will be multiplied together; meaning they will all end up being zero.
```

They can also be interpolated between using _Photon.InterpolateCubic_ and _Photon.InterpolateLinear_ like so:

```
Photon black = new Photon(0.0f, 0.0f, 0.0f, 1.0f);
Photon white = new Photon(1.0f, 1.0f, 1.0f, 1.0f);
Photon darkGray = Photon.InterpolateLinear(black, white, 0.2f);
Photon gray = Photon.InterpolateLinear(black, white, 0.5f);
Photon lightGray = Photon.InterpolateLinear(black, white, 0.8f);
```

###Noise Generators
Noise generators can be utilized in both effect and brush scripting and provide you with an avenue for creating organic topographical features and effects.

There are a few kinds of built-in noise generator. They are notably:

* PerlinNoise - Plain perlin noise.
* OffsetNoise - Noise that is sampled from an offset position (slow but high quality).
* RidgedMultifractalNoise - Noise that has lots of ridges.
* DifferenceNoise - Noise that can contain high detail and defining features.

To create and use one, just do the following:

```
//Creates a perlin noise generator with a seed of 0, 4 octaves,
//a frequency of 0.1, a lacunarity of 2.0 and a persistence of 0.5
NoiseGenerator gen = new PerlinNoise(0, 4, 0.1f, 2.0f, 0.5f);
//Samples the point x = 10, y = 20 in 2D space.
//You can do this in 1 and 3 dimensions as well if you need to.
float sample = gen.Sample(10, 20);
```

Beware though; they each have different input parameters:

* PerlinNoise
  * Seed - A number that will generate unique noise.
  * Octaves - The number of subsequent levels to sample.
  * Frequency - Denotes the scale of the noise (lower spreads it out).
  * Lacunarity - Hard to describe, but a safe value is usually around 2.0
  * Persistence - Again; hard to describe, but a safe value is usually around 0.5
* OffsetNoise
  * Seed - A number that will generate unique noise.
  * Octaves - The number of subsequent levels to sample.
  * Frequency - Denotes the scale of the noise (lower spreads it out).
  * Lacunarity - Hard to describe, but a safe value is usually around 2.0
  * Persistence - Again; hard to describe, but a safe value is usually around 0.5
  * Offset - Denotes how far the sample position will be offset before sampling.
* RidgedMultifractalNoise
  * Seed - A number that will generate unique noise.
  * Octaves - The number of subsequent levels to sample.
  * Frequency - Denotes the scale of the noise (lower spreads it out).
  * Lacunarity - Hard to describe, but a safe value is usually around 2.0
  * Persistence - Again; hard to describe, but a safe value is usually around 0.5
  * Power - A value denoting how thin the ridges should be.
* DifferenceNoise
  * Seed - A number that will generate unique noise.
  * Octaves - The number of subsequent levels to sample.
  * Frequency - Denotes the scale of the noise (lower spreads it out).
  * Lacunarity - Hard to describe, but a safe value is usually around 2.0
  * Persistence - Again; hard to describe, but a safe value is usually around 0.5
  * Layers - A value describing how many layers should be compared (even numbers give different results to odd numbers).