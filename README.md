# Fountain
A map painting/generating software kit for worldbuilders.

#Installation
Fountain for Windows can be downloaded for installation [here](https://www.dropbox.com/s/gtntkonolnda6wr/Fountain_Windows.zip?dl=0).

If you would like to install Fountain on a Linux or Macintosh operating system, please download and compile the source code provided using Mono. I will, at some point, include a binary for Linux, but I have no Linux machine upon which to perform testing so the task may fall to another poor, unfortunate soul.

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

###Brushes
Brushes are integral if you want to do any painting in Fountain. Their scripts consist of two parts; the 'Sample' function, and the 'Blend' function. The 'Sample' function defines the shape of your brush, while the 'Blend' function denotes how the shape is blended into the area you are painting.

Soft, circular brushes are a caste favourite in image manipulation - they're incredibly useful. Here's a really basic one in script form:

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