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

using LlewellynMedia;

namespace Fountain.Forms
{
	public partial class GradientDialog : Form
	{
		public PhotonGradient Gradient
		{
			get
			{
				return gradientBox.Gradient;
			}
			set
			{
				if (value != null)
				{
					gradientBox.Gradient = value;
					gradientTypeBox.SelectedItem = value.Mode;
					minBox.Value = (decimal)value.Start;
					maxBox.Value = (decimal)(value.Length - value.Start);
				}
				else throw new Exception("The supplied gradient cannot be null.");
			}
		}

		public GradientDialog(PhotonGradient gradient)
		{
			CenterToParent();
			InitializeComponent();
			gradientTypeBox.DataSource = Enum.GetValues(typeof(PhotonInterpolationMode));
			Gradient = gradient;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}
		private void cancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
		private void gradientTypeBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Gradient != null)
			{
				Gradient.Mode = (PhotonInterpolationMode)gradientTypeBox.SelectedItem;
				gradientBox.UpdateRender();
			}
		}
		private void gradientBox_MouseClick(object sender, MouseEventArgs e)
		{
			if (Gradient != null)
			{
				float u = (float)e.X / gradientBox.Width * Gradient.Length + Gradient.Start;
				int i = Gradient.ClosestIndex(u);
				if (e.Button == MouseButtons.Left)
				{
					PhotonGradient.PhotonPosition pp = Gradient[i];
					if (ModifierKeys == Keys.Control)
					{
						pp.Photon = Gradient[u];
						pp.Position = u;
						Gradient.Add(pp);
						gradientBox.UpdateRender();
					}
					else
					{
						PhotonDialog photonDialog = new PhotonDialog();
						photonDialog.Photon = pp.Photon;
						if (photonDialog.ShowDialog() == DialogResult.OK)
						{
							pp.Photon = photonDialog.Photon;
							Gradient[i] = pp;
							gradientBox.UpdateRender();
						}
					}
				}
				else if (e.Button == MouseButtons.Right && i > 0 && i < Gradient.PhotonPositionCount - 1)
				{
					Gradient.Remove(i);
					gradientBox.UpdateRender();
				}
			}
		}
		private void gradientBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (Gradient != null)
			{
				float u = (float)e.X / gradientBox.Width * Gradient.Length + Gradient.Start;
				int i = Gradient.ClosestIndex(u);
				if (e.Button == MouseButtons.Middle && i > 0 && i < Gradient.PhotonPositionCount - 1)
				{
					PhotonGradient.PhotonPosition pp = Gradient[i];
					if (ModifierKeys == Keys.Shift) pp.Position = (float)(int)(Math.Round(u * gradientRuler.Segments)) / gradientRuler.Segments;
					else pp.Position = u;
					Gradient[i] = pp;
					gradientBox.UpdateRender();
				}
			}
		}
		private void minBox_ValueChanged(object sender, EventArgs e)
		{
			Gradient.Normalize((float)minBox.Value, (float)maxBox.Value);
		}
		private void maxBox_ValueChanged(object sender, EventArgs e)
		{
			Gradient.Normalize((float)minBox.Value, (float)maxBox.Value);
		}
	}
}
