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
	public partial class EffectDialog : Form
	{
		private string effectName;
		private CSScript script;

		public EffectDialog(string effectName, Form owner)
		{
			Owner = owner;
			if (effectName != null && effectName.Length > 0)
			{
				InitializeComponent();

				if (Document.ContainsEffect(this.effectName = effectName))
				{
					script = Document.GetEffectScript(effectName);
				}
				else
				{
					Document.SetEffect(effectName, null);
					script = Document.GetEffectScript(effectName);
				}

				Text = "Effect - " + effectName;
				scriptBox.Text = script.Source;

				Document.Cleared += Document_Cleared;
				Document.Loaded += Document_Loaded;
				Document.EffectRemoved += Document_EffectRemoved;
			}
			else throw new Exception("The supplied name was empty or null.");
		}

		private void Document_EffectRemoved(string name, Media.HeightRender.Effect effect)
		{
			if (name == effectName) Close();
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
			HeightRender.Effect effect;
			string errors;
			switch (HeightRender.CompileEffect(script, out effect, out errors))
			{
				case HeightRender.EffectCompileResult.WrongApplySignature:
					MessageBox.Show("The method signature for the \"Apply\" function should be:\n\nPhoton Apply(int x, int y, Photon color, HeightField heightField)", "Script Error");
					break;
				case HeightRender.EffectCompileResult.MissingApplyFunction:
					MessageBox.Show("The \"Apply\" function is missing from your script.", "Script Error");
					break;
				case HeightRender.EffectCompileResult.SyntaxError:
					MessageBox.Show("There was a compilation error in your script:\r\n" + errors, "Script Error");
					break;
				case HeightRender.EffectCompileResult.Success:
					Document.SetEffect(effectName, effect, script);
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
