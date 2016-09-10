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
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Fountain.Controls;
using Fountain.Media;

using LlewellynMath;
using LlewellynMath.NoiseGenerators;
using LlewellynMedia;

namespace Fountain.Forms
{
	public partial class MainWindow : Form
	{
		private Vector2 lastPointOnRenderArea;
		private Vector2 lastPointOnRender;

		[STAThread]
		private static void Main(params string[] args)
		{
			MainWindow mw;
			if (args.Length > 0) mw = new MainWindow(args[0]);
			else mw = new MainWindow();
			Application.EnableVisualStyles();
			Application.Run(mw);
		}
		public MainWindow(string filePath = null)
		{
			CenterToScreen();
			InitializeComponent();
			if (filePath != null) HandleFileLoad(filePath);

			renderArea.MouseWheel += renderArea_MouseWheel;
			Application.Idle += Application_Idle;

			Document.RenderSet += Document_RenderSet;
			Document.RenderRemoved += Document_RenderRemoved;
			Document.GradientSet += Document_GradientSet;
			Document.GradientRemoved += Document_GradientRemoved;
			Document.EffectSet += Document_EffectSet;
			Document.EffectRemoved += Document_EffectRemoved;
			Document.BrushSet += Document_BrushSet;
			Document.BrushRemoved += Document_BrushRemoved;
			Document.SelectedRenderChanged += Document_SelectedRenderChanged;
			Document.EffectSelected += Document_EffectSelected;
			Document.EffectDeselected += Document_EffectDeselected;
		}

		private void Document_EffectDeselected(string name)
		{
			selectedEffectList.Items.Clear();
			foreach (string s in Document.SelectedEffectNames)
				selectedEffectList.Items.Add(s);
		}
		private void Document_EffectSelected(string name)
		{
			selectedEffectList.Items.Clear();
			foreach (string s in Document.SelectedEffectNames)
				selectedEffectList.Items.Add(s);
		}
		private void Document_SelectedRenderChanged(string name)
		{
			if (Document.SelectedRender != null) renderArea.Image = Document.SelectedRender.Bitmap;
			else renderArea.Image = null;
		}
		private void Document_BrushRemoved(string name, HeightBrush brush)
		{
			brushNameBox.Items.Clear();
			leftBrushNameBox.Items.Clear();
			rightBrushNameBox.Items.Clear();
			foreach (string s in Document.BrushNames)
			{
				brushNameBox.Items.Add(s);
				leftBrushNameBox.Items.Add(s);
				rightBrushNameBox.Items.Add(s);
			}
			leftBrushNameBox.SelectedItem = Document.LeftBrushName;
			rightBrushNameBox.SelectedItem = Document.RightBrushName;
		}
		private void Document_BrushSet(string name, HeightBrush brush)
		{
			brushNameBox.Items.Clear();
			leftBrushNameBox.Items.Clear();
			rightBrushNameBox.Items.Clear();
			foreach (string s in Document.BrushNames)
			{
				brushNameBox.Items.Add(s);
				leftBrushNameBox.Items.Add(s);
				rightBrushNameBox.Items.Add(s);
			}
			leftBrushNameBox.SelectedItem = Document.LeftBrushName;
			rightBrushNameBox.SelectedItem = Document.RightBrushName;
		}
		private void Document_EffectRemoved(string name, HeightRender.Effect effect)
		{
			effectNameBox.Items.Clear();
			foreach (string s in Document.EffectNames)
				effectNameBox.Items.Add(s);
		}
		private void Document_EffectSet(string name, HeightRender.Effect effect)
		{
			effectNameBox.Items.Clear();
			foreach (string s in Document.EffectNames)
				effectNameBox.Items.Add(s);
		}
		private void Document_GradientRemoved(string name, PhotonGradient gradient)
		{
			gradientNameBox.Items.Clear();
			foreach (string s in Document.GradientNames)
				gradientNameBox.Items.Add(s);
		}
		private void Document_GradientSet(string name, PhotonGradient gradient)
		{
			gradientNameBox.Items.Clear();
			foreach (string s in Document.GradientNames)
				gradientNameBox.Items.Add(s);
		}
		private void Document_RenderRemoved(string name, HeightRender render)
		{
			renderNameBox.Items.Clear();
			foreach (string s in Document.RenderNames)
				renderNameBox.Items.Add(s);
		}
		private void Document_RenderSet(string name, HeightRender render)
		{
			renderNameBox.Items.Clear();
			foreach (string s in Document.RenderNames)
				renderNameBox.Items.Add(s);
		}

		//Render Area
		private void renderArea_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				renderArea.ImageScale = Vector2.One;
				renderArea.ImageOffset = Vector2.Zero;
			}
		}
		private void renderArea_MouseWheel(object sender, MouseEventArgs e)
		{
			if (e.Delta != 0)
			{
				renderArea.ImageScale *= Numerics.Pow(1.1f, Numerics.Clamp(e.Delta, -2, 2));
			}
		}
		private void Application_Idle(object sender, EventArgs e)
		{
			Vector2 pointOnRenderArea = Numerics.ToVector(renderArea.PointToClient(Control.MousePosition));
			Vector2 pointOnRender = renderArea.ClientToImage(pointOnRenderArea);

			if (renderArea.Focused && Document.SelectedRender != null)
			{
				#region Panning
				if (MouseButtons == MouseButtons.Middle)
				{
					renderArea.ImageOffset += (pointOnRenderArea - lastPointOnRenderArea) / renderArea.ImageScale;
				}
				#endregion
				#region Brush
				HeightBrush activeBrush = null;
				if (MouseButtons == MouseButtons.Left) activeBrush = Document.LeftBrush;
				else if (MouseButtons == MouseButtons.Right) activeBrush = Document.RightBrush;

				if (activeBrush != null)
				{
					HeightRender render = Document.SelectedRender;
					PhotonGradient gradient = Document.SelectedGradient;
					IEnumerable<HeightRender.Effect> effects;
					if (paintEffectsBox.Checked) effects = Document.SelectedEffects;
					else effects = null;
					#region Process Steps
					Vector2 brushDelta = lastPointOnRender - pointOnRender;
					float strokeLength = (float)brushDelta.Length;
					float steps = strokeLength / activeBrush.Precision + 1;
					Vector2 brushStep = brushDelta * (1.0f / steps);
					for (int i = 0; i < steps; i++)
					{
						Vector2 brushPosition = pointOnRender + brushStep * i;
						#region Process Brush Paint
						try
						{
							FieldSelection brushArea;
							activeBrush.Paint(render.HeightField, (int)brushPosition.X, (int)brushPosition.Y, strokeLength, out brushArea);
							foreach (FieldSelection fs in brushArea.SubSelectionsOf(render.HeightField))
							{
								if (!fs.IsEmpty)
								{
									render.UpdateArea(fs.Left, fs.Top, fs.Width, fs.Height, gradient, effects);
									Point start = Numerics.ToPoint(renderArea.ImageToClient(new Vector2(fs.Left, fs.Top)));
									Point end = Numerics.ToPoint(renderArea.ImageToClient(new Vector2(fs.Right, fs.Bottom)));
									renderArea.Invalidate(new Rectangle(Numerics.Max(start.X, 0), Numerics.Max(start.Y, 0), Numerics.Max(end.X, 0), Numerics.Max(end.Y, 0)));
								}
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, "There was a runtime error with your brush script.");
						}
						#endregion
					}
					#endregion
				}
				#endregion
			}

			lastPointOnRenderArea = pointOnRenderArea;
			lastPointOnRender = pointOnRender;
		}
		//Document
		private void newDocumentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Document.IsEmpty || MessageBox.Show("Are you sure you want to create a new document?\nAll progress will be lost...", "New Document", MessageBoxButtons.YesNo) == DialogResult.Yes)
				Document.Clear();
		}
		private void openDocumentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Document.IsEmpty || MessageBox.Show("Are you sure you want to open another document?\nAll progress will be lost...", "Open Document", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				openFileDialog.Filter = "Fountain Document (*.fdf)|*.fdf";
				openFileDialog.FileName = Document.AssociatedPath;
				if (openFileDialog.ShowDialog() == DialogResult.OK) HandleFileLoad(openFileDialog.FileName);
			}
		}
		private void saveDocumentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Document.AssociatedPath != null)
			{
				HandleFileSave(Document.AssociatedPath);
			}
			else saveDocumentAsToolStripMenuItem_Click(sender, e);
		}
		private void saveDocumentAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			saveFileDialog.Filter = "Fountain Document (*.fdf)|*.fdf";
			if (saveFileDialog.ShowDialog() == DialogResult.OK) HandleFileSave(saveFileDialog.FileName);
		}
		//Renders
		private void renderNameBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				newRenderToolStripMenuItem_Click(sender, e);
				e.SuppressKeyPress = true;
			}
		}
		private void newRenderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!Document.ContainsRender(renderNameBox.Text))
			{
				if (Document.SetRender(renderNameBox.Text, null))
				{
					RenderDialog rd = new RenderDialog(renderNameBox.Text);
					if (rd.ShowDialog() == DialogResult.OK)
					{
						Document.SetRender(renderNameBox.Text, new HeightRender(rd.RenderWidth, rd.RenderHeight, rd.RenderClamp, rd.RenderClampMin, rd.RenderClampMax, rd.RenderWrapX, rd.RenderWrapY));
						Document.SelectedRenderName = renderNameBox.Text;
						Document.SelectedRender.UpdateAll(Document.SelectedGradient, Document.SelectedEffects);
						renderArea.Invalidate();
					}
					else Document.RemoveRender(renderNameBox.Text);
				}
				else MessageBox.Show("Please enter a valid name for your render in the box above.", "Naming Error");
			}
			else MessageBox.Show(string.Format("A render named {0} already exists. Type a new name in the box above, or remove the existing render.", renderNameBox.Text), "Naming Conflict");
		}
		private void renderNameBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Document.SelectedRenderName = renderNameBox.Text;
		}
		private void editRenderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Document.SelectedRender != null)
			{
				RenderDialog rd = new RenderDialog(Document.SelectedRenderName);
				rd.Show();
			}
		}
		private void clearRenderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Document.SelectedRender != null && MessageBox.Show("Are you sure you want to clear " + Document.SelectedRenderName + "?", "Clear Render", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				Document.SelectedRender.Clear();
				Document.SelectedRender.UpdateAll(Document.SelectedGradient, Document.SelectedEffects);
				renderArea.Invalidate();
			}
		}
		private void exportRenderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Document.SelectedRender != null)
			{
				saveFileDialog.Filter = "Portable Network Graphics (*.png)|*.png";
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
					Document.SelectedRender.Bitmap.Save(saveFileDialog.FileName);
			}
		}
		private void updateRenderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Document.SelectedRender != null)
			{
				Document.SelectedRender.UpdateAll(Document.SelectedGradient, Document.SelectedEffects);
				renderArea.Invalidate();
			}
		}
		private void removeRenderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Document.SelectedRender != null && MessageBox.Show("Are you sure you want to remove " + Document.SelectedRenderName + "?", "Remove Render", MessageBoxButtons.YesNo) == DialogResult.Yes)
				Document.RemoveRender(Document.SelectedRenderName);
		}
		//Gradients
		private void gradientNameBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				newGradientToolStripMenuItem_Click(sender, e);
				e.SuppressKeyPress = true;
			}
		}
		private void newGradientToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!Document.ContainsGradient(gradientNameBox.Text))
			{
				PhotonGradient pg = new PhotonGradient(PhotonInterpolationMode.Linear);
				pg.Add(new Photon(0, 0, 0), 0);
				pg.Add(new Photon(1, 1, 1), 1);
				if (Document.SetGradient(gradientNameBox.Text, pg))
				{
					GradientDialog gd = new GradientDialog(pg);
					if (gd.ShowDialog() != DialogResult.OK) Document.RemoveGradient(gradientNameBox.Text);
				}
				else MessageBox.Show("Please enter a valid name for your gradient in the box above.", "Naming Error");
			}
			else MessageBox.Show(string.Format("A gradient named {0} already exists. Type a new name in the box above, or remove the existing gradient.", gradientNameBox.Text), "Naming Conflict");
		}
		private void gradientNameBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Document.SelectedGradientName = gradientNameBox.Text;
		}
		private void editGradientToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Document.SelectedGradient != null)
			{
				GradientDialog gd = new GradientDialog(Document.SelectedGradient.MakeCopy());
				if (gd.ShowDialog() == DialogResult.OK)
				{
					Document.SetGradient(Document.SelectedGradientName, gd.Gradient);
				}
			}
		}
		private void removeGradientToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Document.RemoveGradient(Document.SelectedGradientName);
		}
		//Effects
		private void effectNameBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				newEffectToolStripMenuItem_Click(sender, e);
				e.SuppressKeyPress = true;
			}
		}
		private void newEffectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!Document.ContainsEffect(effectNameBox.Text))
			{
				if (Document.SetEffect(effectNameBox.Text, null))
				{
					EffectDialog ed = new EffectDialog(effectNameBox.Text);
					ed.Show();
				}
				else MessageBox.Show("Please enter a valid name for your effect in the box above.", "Naming Error");
			}
			else MessageBox.Show(string.Format("An effect named {0} already exists. Type a new name in the box above, or remove the existing effect.", effectNameBox.Text), "Naming Conflict");
		}
		private void editEffectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Document.ContainsEffect(effectNameBox.Text))
			{
				EffectDialog ed = new EffectDialog(effectNameBox.Text);
				ed.Show();
			}
		}
		private void removeEffectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Document.ContainsBrush(effectNameBox.Text) && MessageBox.Show("Are you sure you want to remove " + effectNameBox.Text + "?", "Remove Effect", MessageBoxButtons.YesNo) == DialogResult.Yes)
				Document.RemoveEffect(effectNameBox.Text);
		}
		private void addEffectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Document.SelectEffect(effectNameBox.Text);
		}
		private void selectedEffectList_DoubleClick(object sender, EventArgs e)
		{
			Document.DeselectEffect(selectedEffectList.Text);
		}
		//Brushes
		private void brushNameBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				newBrushToolStripMenuItem_Click(sender, e);
				e.SuppressKeyPress = true;
			}
		}
		private void newBrushToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!Document.ContainsBrush(brushNameBox.Text))
			{
				if (Document.SetBrush(brushNameBox.Text, new HeightBrush(64, 64, 1, 8)))
				{
					BrushDialog bd = new BrushDialog(brushNameBox.Text);
					bd.Show();
				}
				else MessageBox.Show("Please enter a valid name for your brush in the box above.", "Naming Error");
			}
			else MessageBox.Show(string.Format("A brush named {0} already exists. Type a new name in the box above, or remove the existing brush.", brushNameBox.Text), "Naming Conflict");
		}
		private void editBrushToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Document.ContainsBrush(brushNameBox.Text))
			{
				BrushDialog bd = new BrushDialog(brushNameBox.Text);
				bd.Show();
			}
		}
		private void removeBrushToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (Document.ContainsBrush(brushNameBox.Text) && MessageBox.Show("Are you sure you want to remove " + brushNameBox.Text + "?", "Remove Brush", MessageBoxButtons.YesNo) == DialogResult.Yes)
				Document.RemoveBrush(brushNameBox.Text);
		}
		private void leftBrushNameBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Document.LeftBrushName = leftBrushNameBox.Text;
		}
		private void rightBrushNameBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Document.RightBrushName = rightBrushNameBox.Text;
		}

		private static void HandleFileLoad(string path)
		{
			if (path != null)
			{
				switch (Document.Load(path))
				{
					case Document.IOEvaluation.CannotOpenStream:
						MessageBox.Show(string.Format("The file at {0} could not be loaded. This was likely caused by a permissions issue - try running Fountain as Administrator.", path), "Cannot Open Stream");
						break;
					case Document.IOEvaluation.ConversionError:
						MessageBox.Show(string.Format("The file at {0} could not be loaded. The file may be corrupt, or the file standard may have changed.", path), "File Parsing Error");
						break;
					case Document.IOEvaluation.FileDoesNotExist:
						MessageBox.Show(string.Format("There was no file located at {0}.", path), "File Does Not Exist");
						break;
				}
			}
			else MessageBox.Show("The supplied path was null.", "File Path Null");
		}
		private static void HandleFileSave(string path)
		{
			if (path != null)
			{
				switch (Document.Save(path))
				{
					case Document.IOEvaluation.CannotOpenStream:
						MessageBox.Show(string.Format("The file could not be saved to {0}. This was likely caused by a permissions issue - try running Fountain as Administrator.", path), "Cannot Open Stream");
						break;
					case Document.IOEvaluation.ConversionError:
						MessageBox.Show(string.Format("The file could not be saved to {0}. The document may be corrupt.", path), "Document Conversion Error");
						break;
				}
			}
			else MessageBox.Show("The supplied path was null.", "File Path Null");
		}
	}
}