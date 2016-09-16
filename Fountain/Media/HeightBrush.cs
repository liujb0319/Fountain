/* Fountain - Map painting/generating software for worldbuilders. Copyright (C) 2016 Evan Llewellyn Price
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Reflection;
using LlewellynMath;
using LlewellynMath.NoiseGenerators;
using LlewellynScripting;

namespace Fountain.Media
{
	[Serializable]
	public class SerializableHeightBrush
	{
		public string Name;
		public int Width;
		public int Height;
		public float Power;
		public int Precision;
		public string Script;
	}

	public static class HeightBrushExtensions
	{
		public static SerializableHeightBrush ToSerializableHeightBrush(this HeightBrush hb, string script)
		{
			return new SerializableHeightBrush
			{
				Name = hb.Name,
				Width = hb.Width,
				Height = hb.Height,
				Power = hb.Power,
				Precision = hb.Precision,
				Script = script
			};
		}
	}

	public class HeightBrush
	{
		public string Name;

		private int width;

		public virtual int Width
		{
			get { return width; }
			set
			{
				if (value >= 0) width = value;
				else throw new Exception("The width of a brush stroke cannot be negative.");
			}
		}

		private int height;

		public virtual int Height
		{
			get { return height; }
			set
			{
				if (value >= 0) height = value;
				else throw new Exception("The height of a brush stroke cannot be negative.");
			}
		}

		public virtual float Power { get; set; }

		private int precision;

		public int Precision
		{
			get { return precision; }
			set { precision = Numerics.Max(value, 1); }
		}

		public SampleFunction Sample { get; set; }

		public BlendFunction Blend { get; set; }

		public HeightBrush(int width, int height, float power, int precision, SampleFunction sample = null,
			BlendFunction blend = null)
		{
			Width = width;
			Height = height;
			Power = power;
			Precision = precision;
			Sample = sample;
			Blend = blend;
		}

		public void Paint(HeightField field, int x, int y, float intensity, out FieldSelection brushArea,
			out float[] previousData)
		{
			brushArea = new FieldSelection(x - width/2 - width%2, y - height/2 - height%2, width, height);
			previousData = new float[width*height];
			if (Sample != null && Blend != null)
				for (var _x = brushArea.Left; _x < brushArea.Right; _x++)
					for (var _y = brushArea.Top; _y < brushArea.Bottom; _y++)
					{
						float data;
						if (field.TryGetHeight(_x, _y, out data))
						{
							previousData[(_y - brushArea.Top)*width + (_x - brushArea.Left)] = data;
							var shape = Sample(_x, _y, intensity*Power, brushArea.Left, brushArea.Right, brushArea.Top, brushArea.Bottom);
							field[_x, _y] = (float) Blend(data, shape);
						}
					}
		}

		public static CompileResult CompileFunctions(CSScript script, out SampleFunction sample, out BlendFunction blend,
			out string errors)
		{
			if (script != null)
			{
				script.RequiredTypes.Clear();
				script.RequiredTypes.Add(typeof(Math));
				script.RequiredTypes.Add(typeof(Numerics));
				script.RequiredTypes.Add(typeof(PerlinNoise));

				if (script.Compile(out errors))
				{
					MethodInfo sampleInfo;
					if (script.TryGetMember("Sample", out sampleInfo))
					{
						try
						{
							sample = (SampleFunction) sampleInfo.CreateDelegate(typeof(SampleFunction), script.ScriptObject);
						}
						catch
						{
							sample = null;
							blend = null;
							return CompileResult.WrongSampleSignature;
						}
					}
					else
					{
						sample = null;
						blend = null;
						return CompileResult.MissingSampleFunction;
					}

					MethodInfo blendInfo;
					if (script.TryGetMember("Blend", out blendInfo))
					{
						try
						{
							blend = (BlendFunction) blendInfo.CreateDelegate(typeof(BlendFunction), script.ScriptObject);
						}
						catch
						{
							sample = null;
							blend = null;
							return CompileResult.WrongBlendSignature;
						}
					}
					else
					{
						sample = null;
						blend = null;
						return CompileResult.MissingBlendFunction;
					}
					return CompileResult.Success;
				}
				sample = null;
				blend = null;
				return CompileResult.SyntaxError;
			}
			throw new Exception("The supplied script was null.");
		}

		public enum CompileResult
		{
			Success,
			SyntaxError,
			MissingBlendFunction,
			MissingSampleFunction,
			WrongSampleSignature,
			WrongBlendSignature
		}

		public delegate double SampleFunction(int x, int y, double intensity, int left, int right, int top, int bottom);

		public delegate double BlendFunction(double baseValue, double newValue);
	}
}
