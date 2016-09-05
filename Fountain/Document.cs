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
using System.IO;

using LlewellynMedia;
using LlewellynScripting;

using Fountain.Media;

namespace Fountain
{
	public static class Document
	{
		#region Renders
		private static Dictionary<string, HeightRender> renders = new Dictionary<string, HeightRender>();
		public static IEnumerable<string> RenderNames
		{
			get
			{
				return renders.Keys;
			}
		}
		public static IEnumerable<HeightRender> Renders
		{
			get
			{
				return renders.Values;
			}
		}
		//Getting
		public static HeightRender GetRender(string name)
		{
			HeightRender r;
			if (name != null && renders.TryGetValue(name, out r)) return r;
			else return null;
		}
		public static bool ContainsRender(string name)
		{
			return renders.ContainsKey(name);
		}
		//Setting
		public static bool SetRender(string name, HeightRender render)
		{
			if (name != null)
			{
				renders[name] = render;
				if (renderSet != null) renderSet(name, render);
				return true;
			}
			else return false;
		}
		private static OnRenderSet renderSet;
		public static event OnRenderSet RenderSet
		{
			add
			{
				renderSet += value;
			}
			remove
			{
				renderSet -= value;
			}
		}
		//Removing
		public static bool RemoveRender(string name)
		{
			HeightRender render;
			if (renders.TryGetValue(name, out render))
			{
				renders.Remove(name);
				if (name == SelectedRenderName) SelectedRenderName = null;
				if (renderRemoved != null) renderRemoved(name, render);
				return true;
			}
			else return false;
		}
		private static OnRenderRemoved renderRemoved;
		public static event OnRenderRemoved RenderRemoved
		{
			add
			{
				renderRemoved += value;
			}
			remove
			{
				renderRemoved -= value;
			}
		}
		//Selected
		private static string selectedRenderName;
		public static string SelectedRenderName
		{
			get
			{
				return selectedRenderName;
			}
			set
			{
				selectedRenderName = value;
				if (selectedRenderChanged != null) selectedRenderChanged(value);
			}
		}
		public static HeightRender SelectedRender
		{
			get
			{
				return GetRender(selectedRenderName);
			}
		}
		private static OnSelectedRenderChanged selectedRenderChanged;
		public static event OnSelectedRenderChanged SelectedRenderChanged
		{
			add
			{
				selectedRenderChanged += value;
			}
			remove
			{
				selectedRenderChanged -= value;
			}
		}

		public delegate void OnRenderSet(string name, HeightRender render);
		public delegate void OnRenderRemoved(string name, HeightRender render);
		public delegate void OnSelectedRenderChanged(string name);
		#endregion
		#region Gradients
		private static Dictionary<string, PhotonGradient> gradients = new Dictionary<string, PhotonGradient>();
		public static IEnumerable<string> GradientNames
		{
			get
			{
				return gradients.Keys;
			}
		}
		public static IEnumerable<PhotonGradient> Gradients
		{
			get
			{
				foreach (PhotonGradient pg in gradients.Values)
					yield return pg;
			}
		}
		//Getting
		public static PhotonGradient GetGradient(string name)
		{
			PhotonGradient g;
			if (name != null && gradients.TryGetValue(name, out g)) return g;
			else return null;
		}
		public static bool ContainsGradient(string name)
		{
			return gradients.ContainsKey(name);
		}
		//Setting
		public static bool SetGradient(string name, PhotonGradient gradient)
		{
			if (name != null)
			{
				gradients[name] = gradient;
				if (gradientSet != null) gradientSet(name, gradient);
				return true;
			}
			else return false;
		}
		private static OnGradientSet gradientSet;
		public static event OnGradientSet GradientSet
		{
			add
			{
				gradientSet += value;
			}
			remove
			{
				gradientSet -= value;
			}
		}
		//Removing
		public static bool RemoveGradient(string name)
		{
			PhotonGradient gradient;
			if (gradients.TryGetValue(name, out gradient))
			{
				gradients.Remove(name);
				if (SelectedGradientName == name) SelectedGradientName = null;
				if (gradientRemoved != null) gradientRemoved(name, gradient);
				return true;
			}
			else return false;
		}
		private static OnGradientRemoved gradientRemoved;
		public static event OnGradientRemoved GradientRemoved
		{
			add
			{
				gradientRemoved += value;
			}
			remove
			{
				gradientRemoved -= value;
			}
		}
		//Selected
		private static string selectedGradientName;
		public static string SelectedGradientName
		{
			get
			{
				return selectedGradientName;
			}
			set
			{
				selectedGradientName = value;
				if (selectedGradientChanged != null) selectedGradientChanged(value);
			}
		}
		public static PhotonGradient SelectedGradient
		{
			get
			{
				return GetGradient(selectedGradientName);
			}
		}
		private static OnSelectedGradientChanged selectedGradientChanged;
		public static event OnSelectedGradientChanged SelectedGradientChanged
		{
			add
			{
				selectedGradientChanged += value;
			}
			remove
			{
				selectedGradientChanged -= value;
			}
		}

		public delegate void OnGradientSet(string name, PhotonGradient gradient);
		public delegate void OnGradientRemoved(string name, PhotonGradient gradient);
		public delegate void OnSelectedGradientChanged(string name);
		#endregion
		#region Effects
		private static Dictionary<string, EffectScript> effects = new Dictionary<string, EffectScript>();
		public static IEnumerable<string> EffectNames
		{
			get
			{
				return effects.Keys;
			}
		}
		public static IEnumerable<HeightRender.Effect> Effects
		{
			get
			{
				foreach (EffectScript es in effects.Values)
					yield return es.effect;
			}
		}
		//Getting
		public static HeightRender.Effect GetEffect(string name)
		{
			EffectScript es;
			if (name != null && effects.TryGetValue(name, out es)) return es.effect;
			else return null;
		}
		public static CSScript GetEffectScript(string name)
		{
			EffectScript es;
			if (name != null && effects.TryGetValue(name, out es)) return es.script;
			else return null;
		}
		public static bool ContainsEffect(string name)
		{
			return effects.ContainsKey(name);
		}
		//Setting
		public static bool SetEffect(string name, HeightRender.Effect effect, CSScript script = null)
		{
			if (name != null)
			{
				if (script == null) script = new CSScript();
				EffectScript es;
				if (!effects.TryGetValue(name, out es)) es = new EffectScript() { effect = effect, script = script };
				else es.effect = effect;
				effects[name] = es;
				if (effectSet != null) effectSet(name, es.effect);
				return true;
			}
			else return false;
		}
		private static OnEffectSet effectSet;
		public static event OnEffectSet EffectSet
		{
			add
			{
				effectSet += value;
			}
			remove
			{
				effectSet -= value;
			}
		}
		//Removing
		public static bool RemoveEffect(string name)
		{
			EffectScript es;
			if (effects.TryGetValue(name, out es))
			{
				effects.Remove(name);
				if (selectedEffectNames.Contains(name)) DeselectEffect(name);
				if (effectRemoved != null) effectRemoved(name, es.effect);
				return true;
			}
			else return false;
		}
		private static OnEffectRemoved effectRemoved;
		public static event OnEffectRemoved EffectRemoved
		{
			add
			{
				effectRemoved += value;
			}
			remove
			{
				effectRemoved -= value;
			}
		}
		//Selected
		private static List<string> selectedEffectNames = new List<string>();
		public static IEnumerable<string> SelectedEffectNames
		{
			get
			{
				foreach (string s in selectedEffectNames)
					yield return s;
			}
		}
		public static IEnumerable<HeightRender.Effect> SelectedEffects
		{
			get
			{
				foreach (string s in selectedEffectNames)
					yield return GetEffect(s);
			}
		}
		public static bool IsEffectSelected(string name)
		{
			return selectedEffectNames.Contains(name);
		}
		//Selecting
		public static bool SelectEffect(string name)
		{
			if (effects.ContainsKey(name))
			{
				selectedEffectNames.Add(name);
				if (effectSelected != null) effectSelected(name);
				return true;
			}
			else return false;
		}
		private static OnEffectSelected effectSelected;
		public static event OnEffectSelected EffectSelected
		{
			add
			{
				effectSelected += value;
			}
			remove
			{
				effectSelected -= value;
			}
		}
		//Deselecting
		public static bool DeselectEffect(string name)
		{
			if (selectedEffectNames.Remove(name))
			{
				if (effectDeselected != null) effectDeselected(name);
				return true;
			}
			else return false;
		}
		private static OnEffectDeselected effectDeselected;
		public static event OnEffectDeselected EffectDeselected
		{
			add
			{
				effectDeselected += value;
			}
			remove
			{
				effectDeselected -= value;
			}
		}

		public delegate void OnEffectSet(string name, HeightRender.Effect effect);
		public delegate void OnEffectRemoved(string name, HeightRender.Effect effect);
		public delegate void OnEffectSelected(string name);
		public delegate void OnEffectDeselected(string name);

		private struct EffectScript
		{
			public HeightRender.Effect effect;
			public CSScript script;
		}
		#endregion
		#region Brushes
		private static Dictionary<string, BrushScript> brushes = new Dictionary<string, BrushScript>();
		public static IEnumerable<string> BrushNames
		{
			get
			{
				return brushes.Keys;
			}
		}
		public static IEnumerable<HeightBrush> Brushes
		{
			get
			{
				foreach (BrushScript bs in brushes.Values)
					yield return bs.brush;
			}
		}
		//Getting
		public static HeightBrush GetBrush(string name)
		{
			BrushScript bs;
			if (name != null && brushes.TryGetValue(name, out bs)) return bs.brush;
			else return null;
		}
		public static CSScript GetBrushScript(string name)
		{
			BrushScript bs;
			if (name != null && brushes.TryGetValue(name, out bs)) return bs.script;
			else return null;
		}
		public static bool ContainsBrush(string name)
		{
			return brushes.ContainsKey(name);
		}
		//Setting
		public static bool SetBrush(string name, HeightBrush brush, CSScript script = null)
		{
			if (name != null)
			{
				if (script == null) script = new CSScript();
				BrushScript bs;
				if (!brushes.TryGetValue(name, out bs)) bs = new BrushScript() { brush = brush, script = script };
				else bs.brush = brush;
				brushes[name] = bs;
				if (brushSet != null) brushSet(name, bs.brush);
				return true;
			}
			else return false;
		}
		private static OnBrushSet brushSet;
		public static event OnBrushSet BrushSet
		{
			add
			{
				brushSet += value;
			}
			remove
			{
				brushSet -= value;
			}
		}
		//Removing
		public static bool RemoveBrush(string name)
		{
			BrushScript bs;
			if (brushes.TryGetValue(name, out bs))
			{
				brushes.Remove(name);
				if (LeftBrushName == name) LeftBrushName = null;
				if (RightBrushName == name) RightBrushName = null;
				if (brushRemoved != null) brushRemoved(name, bs.brush);
				return true;
			}
			else return false;
		}
		private static OnBrushRemoved brushRemoved;
		public static event OnBrushRemoved BrushRemoved
		{
			add
			{
				brushRemoved += value;
			}
			remove
			{
				brushRemoved -= value;
			}
		}
		//Left
		private static string leftBrushName;
		public static string LeftBrushName
		{
			get
			{
				return leftBrushName;
			}
			set
			{
				leftBrushName = value;
				if (leftBrushChanged != null) leftBrushChanged(value);
			}
		}
		public static HeightBrush LeftBrush
		{
			get
			{
				return GetBrush(leftBrushName);
			}
		}
		private static OnLeftBrushChanged leftBrushChanged;
		public static event OnLeftBrushChanged LeftBrushChanged
		{
			add
			{
				leftBrushChanged += value;
			}
			remove
			{
				leftBrushChanged -= value;
			}
		}
		//Right
		private static string rightBrushName;
		public static string RightBrushName
		{
			get
			{
				return rightBrushName;
			}
			set
			{
				rightBrushName = value;
				if (rightBrushChanged != null) rightBrushChanged(value);
			}
		}
		public static HeightBrush RightBrush
		{
			get
			{
				return GetBrush(rightBrushName);
			}
		}
		private static OnRightBrushChanged rightBrushChanged;
		public static event OnRightBrushChanged RightBrushChanged
		{
			add
			{
				rightBrushChanged += value;
			}
			remove
			{
				rightBrushChanged -= value;
			}
		}

		public delegate void OnBrushSet(string name, HeightBrush brush);
		public delegate void OnBrushRemoved(string name, HeightBrush brush);
		public delegate void OnLeftBrushChanged(string name);
		public delegate void OnRightBrushChanged(string name);

		private struct BrushScript
		{
			public HeightBrush brush;
			public CSScript script;
		}
		#endregion
		#region IO
		private static string associatedPath;
		public static string AssociatedPath
		{
			get
			{
				return associatedPath;
			}
		}
		public static bool IsEmpty
		{
			get
			{
				return renders.Count == 0 && gradients.Count == 0 && effects.Count == 0 && brushes.Count == 0;
			}
		}
		public static void Clear()
		{
			string[] names;
			names = renders.Keys.ToArray();
			foreach (string name in names)
				RemoveRender(name);
			names = gradients.Keys.ToArray();
			foreach (string name in names)
				RemoveGradient(name);
			names = effects.Keys.ToArray();
			foreach (string name in names)
				RemoveEffect(name);
			names = brushes.Keys.ToArray();
			foreach (string name in names)
				RemoveBrush(name);
			associatedPath = null;
			if (cleared != null) cleared();
		}
		//Clearing
		private static OnCleared cleared;
		public static event OnCleared Cleared
		{
			add
			{
				cleared += value;
			}
			remove
			{
				cleared -= value;
			}
		}
		//Loading
		public static bool Load(string path)
		{
			Clear();
			if (File.Exists(path))
			{
				FileStream stream = new FileStream(path, FileMode.Open);
				try
				{
					byte[] countBuf = new byte[4];
					int count;
					//Load Renders
					stream.Read(countBuf, 0, sizeof(int));
					count = BitConverter.ToInt32(countBuf, 0);
					for (int i = 0; i < count; i++)
					{
						string name = LoadText(stream);
						HeightRender render = LoadRender(stream);
						SetRender(name, render);
					}
					//Load Gradients
					stream.Read(countBuf, 0, sizeof(int));
					count = BitConverter.ToInt32(countBuf, 0);
					for (int i = 0; i < count; i++)
					{
						string name = LoadText(stream);
						PhotonGradient gradient = LoadGradient(stream);
						SetGradient(name, gradient);
					}
					//Load Effects
					stream.Read(countBuf, 0, sizeof(int));
					count = BitConverter.ToInt32(countBuf, 0);
					for (int i = 0; i < count; i++)
					{
						string name = LoadText(stream);
						EffectScript es = LoadEffect(stream);
						SetEffect(name, es.effect, es.script);
					}
					//Load Brushes
					stream.Read(countBuf, 0, sizeof(int));
					count = BitConverter.ToInt32(countBuf, 0);
					for (int i = 0; i < count; i++)
					{
						string name = LoadText(stream);
						BrushScript bs = LoadBrush(stream);
						SetBrush(name, bs.brush, bs.script);
					}
					//Path and Callback
					associatedPath = path;
					if (loaded != null) loaded(path);
					return true;
				}
				catch
				{
					associatedPath = null;
					return false;
				}
				finally
				{
					stream.Close();
				}
			}
			else
			{
				associatedPath = path;
				return false;
			}
		}
		private static OnLoaded loaded;
		public static event OnLoaded Loaded
		{
			add
			{
				loaded += value;
			}
			remove
			{
				loaded -= value;
			}
		}
		private static string LoadText(Stream stream)
		{
			byte[] sizBuff = new byte[4];
			stream.Read(sizBuff, 0, sizeof(int));
			int size = BitConverter.ToInt32(sizBuff, 0);
			byte[] texBuff = new byte[size];
			stream.Read(texBuff, 0, size);
			return Encoding.Unicode.GetString(texBuff);
		}
		private static HeightRender LoadRender(Stream stream)
		{
			byte[] buffer = new byte[4];

			stream.Read(buffer, 0, sizeof(int));
			int width = BitConverter.ToInt32(buffer, 0);
			stream.Read(buffer, 0, sizeof(int));
			int height = BitConverter.ToInt32(buffer, 0);
			stream.Read(buffer, 0, sizeof(bool));
			bool clamp = BitConverter.ToBoolean(buffer, 0);
			stream.Read(buffer, 0, sizeof(float));
			float clampMin = BitConverter.ToSingle(buffer, 0);
			stream.Read(buffer, 0, sizeof(float));
			float clampMax = BitConverter.ToSingle(buffer, 0);
			stream.Read(buffer, 0, sizeof(bool));
			bool wrapX = BitConverter.ToBoolean(buffer, 0);
			stream.Read(buffer, 0, sizeof(bool));
			bool wrapY = BitConverter.ToBoolean(buffer, 0);

			HeightRender render = new HeightRender(width, height, clamp, clampMin, clampMax, wrapX, wrapY);
			for (int i = 0; i < render.HeightField.Data.Length; i++)
			{
				stream.Read(buffer, 0, sizeof(float));
				render.HeightField.Data[i] = BitConverter.ToSingle(buffer, 0);
			}

			return render;
		}
		private static PhotonGradient LoadGradient(Stream stream)
		{
			byte[] buffer = new byte[4];

			stream.Read(buffer, 0, sizeof(int));
			int count = BitConverter.ToInt32(buffer, 0);
			stream.Read(buffer, 0, sizeof(int));
			PhotonInterpolationMode mode = (PhotonInterpolationMode)BitConverter.ToInt32(buffer, 0);

			PhotonGradient gradient = new PhotonGradient(mode);
			for (int i = 0; i < count; i++)
			{
				stream.Read(buffer, 0, sizeof(byte) * 4);
				Photon p = buffer;
				stream.Read(buffer, 0, sizeof(float));
				float f = BitConverter.ToSingle(buffer, 0);
				gradient.Add(p, f);
			}

			return gradient;
		}
		private static EffectScript LoadEffect(Stream stream)
		{
			EffectScript es = new EffectScript() { effect = null, script = new CSScript() };
			es.script.Source = LoadText(stream);
			return es;
		}
		private static BrushScript LoadBrush(Stream stream)
		{
			byte[] buffer = new byte[4];

			stream.Read(buffer, 0, sizeof(int));
			int width = BitConverter.ToInt32(buffer, 0);
			stream.Read(buffer, 0, sizeof(int));
			int height = BitConverter.ToInt32(buffer, 0);
			stream.Read(buffer, 0, sizeof(float));
			float power = BitConverter.ToSingle(buffer, 0);
			stream.Read(buffer, 0, sizeof(int));
			int precision = BitConverter.ToInt32(buffer, 0);

			BrushScript bs = new BrushScript() { brush = new HeightBrush(width, height, power, precision), script = new CSScript() };
			bs.script.Source = LoadText(stream);

			return bs;
		}
		//Saving
		public static bool Save(string path)
		{
			FileStream stream = new FileStream(path, FileMode.Create);
			try
			{
				//Save Renders
				stream.Write(BitConverter.GetBytes(renders.Count), 0, sizeof(int));
				foreach (string name in RenderNames)
				{
					SaveText(stream, name);
					SaveRender(stream, renders[name]);
				}
				//Save Gradients
				stream.Write(BitConverter.GetBytes(gradients.Count), 0, sizeof(int));
				foreach (string name in GradientNames)
				{
					SaveText(stream, name);
					SaveGradient(stream, gradients[name]);
				}
				//Save Effects
				stream.Write(BitConverter.GetBytes(effects.Count), 0, sizeof(int));
				foreach (string name in EffectNames)
				{
					SaveText(stream, name);
					SaveEffect(stream, effects[name]);
				}
				//Save Brushes
				stream.Write(BitConverter.GetBytes(brushes.Count), 0, sizeof(int));
				foreach (string name in BrushNames)
				{
					SaveText(stream, name);
					SaveBrush(stream, brushes[name]);
				}
				//Path and Callback
				associatedPath = path;
				if (saved != null) saved(path);
				return true;
			}
			catch
			{
				associatedPath = null;
				return false;
			}
			finally
			{
				stream.Close();
			}
		}
		private static OnSaved saved;
		public static event OnSaved Saved
		{
			add
			{
				saved += value;
			}
			remove
			{
				saved -= value;
			}
		}
		private static void SaveText(Stream stream, string text)
		{
			byte[] texBuff = Encoding.Unicode.GetBytes(text);
			stream.Write(BitConverter.GetBytes(texBuff.Length), 0, sizeof(int));
			stream.Write(texBuff, 0, texBuff.Length);
		}
		private static void SaveRender(Stream stream, HeightRender render)
		{
			stream.Write(BitConverter.GetBytes(render.HeightField.Width), 0, sizeof(int));
			stream.Write(BitConverter.GetBytes(render.HeightField.Height), 0, sizeof(int));
			stream.Write(BitConverter.GetBytes(render.HeightField.Clamp), 0, sizeof(bool));
			stream.Write(BitConverter.GetBytes(render.HeightField.ClampMin), 0, sizeof(float));
			stream.Write(BitConverter.GetBytes(render.HeightField.ClampMax), 0, sizeof(float));
			stream.Write(BitConverter.GetBytes(render.HeightField.WrapX), 0, sizeof(bool));
			stream.Write(BitConverter.GetBytes(render.HeightField.WrapY), 0, sizeof(bool));
			for (int i = 0; i < render.HeightField.Data.Length; i++)
				stream.Write(BitConverter.GetBytes(render.HeightField.Data[i]), 0, sizeof(float));
		}
		private static void SaveGradient(Stream stream, PhotonGradient gradient)
		{
			stream.Write(BitConverter.GetBytes(gradient.PhotonPositionCount), 0, sizeof(int));
			stream.Write(BitConverter.GetBytes((int)gradient.Mode), 0, sizeof(int));
			for (int i = 0; i < gradient.PhotonPositionCount; i++)
			{
				stream.Write(gradient[i].Photon, 0, sizeof(byte) * 4);
				stream.Write(BitConverter.GetBytes(gradient[i].Position), 0, sizeof(float));
			}
		}
		private static void SaveEffect(Stream stream, EffectScript effect)
		{
			SaveText(stream, effect.script.Source);
		}
		private static void SaveBrush(Stream stream, BrushScript brush)
		{
			stream.Write(BitConverter.GetBytes(brush.brush.Width), 0, sizeof(int));
			stream.Write(BitConverter.GetBytes(brush.brush.Height), 0, sizeof(int));
			stream.Write(BitConverter.GetBytes(brush.brush.Power), 0, sizeof(float));
			stream.Write(BitConverter.GetBytes(brush.brush.Precision), 0, sizeof(int));
			SaveText(stream, brush.script.Source);
		}

		public delegate void OnCleared();
		public delegate void OnLoaded(string path);
		public delegate void OnSaved(string path);
		#endregion
	}
}
