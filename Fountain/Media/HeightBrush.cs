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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;

using LlewellynMath;

namespace Fountain.Media
{
	public class HeightBrush
	{
		private int width;
		public virtual int Width
		{
			get
			{
				return width;
			}
			set
			{
				if (value >= 0) width = value;
				else throw new Exception("The width of a brush stroke cannot be negative.");
			}
		}
		private int height;
		public virtual int Height
		{
			get
			{
				return height;
			}
			set
			{
				if (value >= 0) height = value;
				else throw new Exception("The height of a brush stroke cannot be negative.");
			}
		}
		private float power;
		public virtual float Power
		{
			get
			{
				return power;
			}
			set
			{
				power = value;
			}
		}
		private int precision;
		public int Precision
		{
			get
			{
				return precision;
			}
			set
			{
				precision = Numerics.Max(value, 1);
			}
		}
		private SampleFunction sample;
		public SampleFunction Sample
		{
			get
			{
				return sample;
			}
			set
			{
				sample = value;
			}
		}
		private BlendFunction blend;
		public BlendFunction Blend
		{
			get
			{
				return blend;
			}
			set
			{
				blend = value;
			}
		}

		public HeightBrush(int width, int height, float power, int precision, SampleFunction sample = null, BlendFunction blend = null)
		{
			Width = width;
			Height = height;
			Power = power;
			Precision = precision;
			Sample = sample;
			Blend = blend;
		}

		public void Paint(HeightField field, int x, int y, float intensity, out FieldSelection brushArea)
		{
			brushArea = new FieldSelection(x - Width / 2 - Width % 2, y - Height / 2 - Height % 2, Width, Height);
			if (sample != null && blend != null)
			{
				for (int _x = brushArea.Left; _x < brushArea.Right; _x++)
				{
					for (int _y = brushArea.Top; _y < brushArea.Bottom; _y++)
					{
						float data;
						if (field.TryGetHeight(_x, _y, out data))
						{
							float shape = sample(_x, _y, intensity * Power, brushArea.Left, brushArea.Right, brushArea.Top, brushArea.Bottom);
							field[_x, _y] = blend(data, shape);
						}
					}
				}
			}
		}

		public delegate float SampleFunction(int x, int y, float intensity, int left, int right, int top, int bottom);
		public delegate float BlendFunction(float baseValue, float newValue);
	}
}
