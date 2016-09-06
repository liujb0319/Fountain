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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

using LlewellynScripting;
using LlewellynMath;
using LlewellynMath.NoiseGenerators;
using LlewellynMedia;

using Fountain.Media;

namespace Fountain.Forms
{
	public partial class EffectDialog : Form
	{
		private string effectName;
		private CSScript script;

		public EffectDialog(string effectName)
		{
			InitializeComponent();
			if (Document.ContainsEffect(this.effectName = effectName))
			{
				script = Document.GetEffectScript(effectName);

				Text = "Effect - " + effectName;
				scriptBox.Text = script.Source;

				Document.Cleared += Document_Cleared;
				Document.Loaded += Document_Loaded;
				Document.EffectRemoved += Document_EffectRemoved;
			}
			else throw new Exception("The given effect name does not correspond to any effect in the current document.");
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
			script.RequiredTypes.Add(typeof(Color));
			script.RequiredTypes.Add(typeof(HeightField));
			script.RequiredTypes.Add(typeof(Photon));
			script.RequiredTypes.Add(typeof(Numerics));
			script.RequiredTypes.Add(typeof(Math));
			script.RequiredTypes.Add(typeof(PerlinNoise));
			script.Source = scriptBox.Text;

			string errors;
			if (script.Compile(out errors))
			{
				MethodInfo applyInfo;
				if (script.TryGetMember<MethodInfo>("Apply", out applyInfo))
				{
					try
					{
						HeightRender.Effect effect = (HeightRender.Effect)applyInfo.CreateDelegate(typeof(HeightRender.Effect), script.ScriptObject);
						Document.SetEffect(effectName, effect);
					}
					catch
					{
						MessageBox.Show("The method signature for the \"Apply\" function should be:\n\nfloat[] Apply(int x, int y, float[] color, dynamic heightField)", "Script Error");
					}
				}
				else MessageBox.Show("The \"Apply\" function is missing from your script.");
			}
			else MessageBox.Show("There was a compilation error in your script:\n\n" + errors.Split('\n')[0], "Script Error");
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
