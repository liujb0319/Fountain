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
using System.Windows.Forms;
using LlewellynScripting;
using Fountain.Media;

namespace Fountain.Forms
{
	public partial class BrushDialog : Form
	{
		private string brushName;
		private HeightBrush brush;
		private CSScript script;

		public BrushDialog(string brushName, Form owner)
		{
			Owner = owner;
			if (brushName != null && brushName.Length > 0)
			{
				CenterToParent();
				InitializeComponent();

				if (Document.ContainsBrush(this.brushName = brushName))
				{
					brush = Document.GetBrush(brushName);
					script = Document.GetBrushScript(brushName);
				}
				else
				{
					Document.SetBrush(brushName, brush = new HeightBrush(64, 64, 1.0f, 8));
					script = Document.GetBrushScript(brushName);
				}

				Text = "Brush - " + brushName;
				widthBox.Value = brush.Width;
				heightBox.Value = brush.Height;
				powerBox.Value = (decimal)brush.Power;
				precisionBox.Value = brush.Precision;
				scriptBox.Text = script.Source;

				Document.BrushRemoved += FountainDocument_BrushRemoved;
				Document.Loaded += FountainDocument_Loaded;
				Document.Cleared += FountainDocument_Cleared;
			}
			else throw new Exception("The supplied name was empty or null.");
		}

		private void FountainDocument_Cleared()
		{
			Close();
		}
		private void FountainDocument_Loaded(string path)
		{
			Close();
		}
		private void FountainDocument_BrushRemoved(string name, HeightBrush brush)
		{
			if (name == brushName) Close();
		}

		private void widthBox_ValueChanged(object sender, EventArgs e)
		{
			brush.Width = (int)widthBox.Value;
		}
		private void heightBox_ValueChanged(object sender, EventArgs e)
		{
			brush.Height = (int)heightBox.Value;
		}
		private void powerBox_ValueChanged(object sender, EventArgs e)
		{
			brush.Power = (float)powerBox.Value;
		}
		private void precisionBox_ValueChanged(object sender, EventArgs e)
		{
			brush.Precision = (int)precisionBox.Value;
		}
		private void compileButton_Click(object sender, EventArgs e)
		{
			script.Source = scriptBox.Text;
			HeightBrush.SampleFunction sample;
			HeightBrush.BlendFunction blend;
			string errors;
			switch (HeightBrush.CompileFunctions(script, out sample, out blend, out errors))
			{
				case HeightBrush.CompileResult.WrongSampleSignature:
					MessageBox.Show("The method signature for the \"Sample\" function should be:\n\nfloat Sample(int x, int y, float intensity, int left, int right, int top int bottom)", "Script Error");
					break;
				case HeightBrush.CompileResult.MissingSampleFunction:
					MessageBox.Show("The \"Sample\" function is missing from your script.");
					break;
				case HeightBrush.CompileResult.WrongBlendSignature:
					MessageBox.Show("The method signature for the \"Blend\" function should be:\n\nfloat Blend(float baseValue, float newValue)", "Script Error");
					break;
				case HeightBrush.CompileResult.MissingBlendFunction:
					MessageBox.Show("The \"Blend\" function is missing from your script.");
					break;
				case HeightBrush.CompileResult.SyntaxError:
					MessageBox.Show("There was a compilation error in your script:\r\n" + errors, "Syntax Error");
					break;
				case HeightBrush.CompileResult.Success:
					brush.Sample = sample;
					brush.Blend = blend;
					break;
			}
		}
		private void scriptBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{
				scriptBox.SelectionStart = 0;
				scriptBox.SelectionLength = scriptBox.Text.Length;

				e.SuppressKeyPress = true;
			}
		}
	}
}
