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
	public partial class GeneratorDialog : Form
	{
		private string generatorName;
		private CSScript script;

		public GeneratorDialog(string generatorName, Form owner)
		{
			Owner = owner;
			if (generatorName != null && generatorName.Length > 0)
			{
				InitializeComponent();

				if (Document.ContainsGenerator(this.generatorName = generatorName))
				{
					script = Document.GetGeneratorScript(generatorName);
				}
				else
				{
					Document.SetGenerator(generatorName, null);
					script = Document.GetGeneratorScript(generatorName);
				}

				Text = "Generator - " + generatorName;
				scriptBox.Text = script.Source;

				Document.Cleared += Document_Cleared;
				Document.Loaded += Document_Loaded;
				Document.GeneratorRemoved += Document_GeneratorRemoved;
			}
			else throw new Exception("The supplied name was empty or null.");
		}

		private void Document_GeneratorRemoved(string name, HeightRender.Generator generator)
		{
			if (name == generatorName) Close();
		}
		private void Document_Loaded(string path)
		{
			Close();
		}
		private void Document_Cleared()
		{
			Close();
		}

		private void compileButton_Click(object sender, EventArgs e)
		{
			script.Source = scriptBox.Text;
			HeightRender.Generator generator;
			string errors;
			switch (HeightRender.CompileGenerator(script, out generator, out errors))
			{
				case HeightRender.GeneratorCompileResult.WrongGenerateSignature:
					MessageBox.Show("The method signature for the \"Generate\" function should be:\n\nfloat Generate(int x, int y, HeightField heightField)", "Script Error");
					break;
				case HeightRender.GeneratorCompileResult.MissingGenerateFunction:
					MessageBox.Show("The \"Generate\" function is missing from your script.", "Script Error");
					break;
				case HeightRender.GeneratorCompileResult.SyntaxError:
					MessageBox.Show("There was a compilation error in your script:\r\n" + errors, "Script Error");
					break;
				case HeightRender.GeneratorCompileResult.Success:
					Document.SetGenerator(generatorName, generator, script);
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
