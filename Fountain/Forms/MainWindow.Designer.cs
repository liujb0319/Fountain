﻿namespace Fountain.Forms
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.documentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveDocumentAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rendersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renderNameBox = new System.Windows.Forms.ToolStripComboBox();
			this.newRenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editRenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearRenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportRenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.updateRenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeRenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gradientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gradientNameBox = new System.Windows.Forms.ToolStripComboBox();
			this.newGradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editGradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeGradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.effectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.effectNameBox = new System.Windows.Forms.ToolStripComboBox();
			this.newEffectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editEffectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeEffectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.addEffectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.brushesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.brushNameBox = new System.Windows.Forms.ToolStripComboBox();
			this.newBrushToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editBrushToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeBrushToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.selectedEffectList = new System.Windows.Forms.ListBox();
			this.rightBrushNameBox = new System.Windows.Forms.ComboBox();
			this.leftBrushNameBox = new System.Windows.Forms.ComboBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.selectedGradientBox = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.paintEffectsBox = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.selectedRenderBox = new System.Windows.Forms.ComboBox();
			this.generatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.generatorNameBox = new System.Windows.Forms.ToolStripComboBox();
			this.newGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.applyGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.renderArea = new Fountain.Controls.RenderArea();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentToolStripMenuItem,
            this.rendersToolStripMenuItem,
            this.gradientsToolStripMenuItem,
            this.effectsToolStripMenuItem,
            this.brushesToolStripMenuItem,
            this.generatorsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(1012, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// documentToolStripMenuItem
			// 
			this.documentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDocumentToolStripMenuItem,
            this.openDocumentToolStripMenuItem,
            this.saveDocumentToolStripMenuItem,
            this.saveDocumentAsToolStripMenuItem});
			this.documentToolStripMenuItem.Name = "documentToolStripMenuItem";
			this.documentToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
			this.documentToolStripMenuItem.Text = "Document";
			// 
			// newDocumentToolStripMenuItem
			// 
			this.newDocumentToolStripMenuItem.Name = "newDocumentToolStripMenuItem";
			this.newDocumentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newDocumentToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
			this.newDocumentToolStripMenuItem.Text = "New";
			this.newDocumentToolStripMenuItem.Click += new System.EventHandler(this.newDocumentToolStripMenuItem_Click);
			// 
			// openDocumentToolStripMenuItem
			// 
			this.openDocumentToolStripMenuItem.Name = "openDocumentToolStripMenuItem";
			this.openDocumentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openDocumentToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
			this.openDocumentToolStripMenuItem.Text = "Open";
			this.openDocumentToolStripMenuItem.Click += new System.EventHandler(this.openDocumentToolStripMenuItem_Click);
			// 
			// saveDocumentToolStripMenuItem
			// 
			this.saveDocumentToolStripMenuItem.Name = "saveDocumentToolStripMenuItem";
			this.saveDocumentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveDocumentToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
			this.saveDocumentToolStripMenuItem.Text = "Save";
			this.saveDocumentToolStripMenuItem.Click += new System.EventHandler(this.saveDocumentToolStripMenuItem_Click);
			// 
			// saveDocumentAsToolStripMenuItem
			// 
			this.saveDocumentAsToolStripMenuItem.Name = "saveDocumentAsToolStripMenuItem";
			this.saveDocumentAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
			this.saveDocumentAsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
			this.saveDocumentAsToolStripMenuItem.Text = "Save As";
			this.saveDocumentAsToolStripMenuItem.Click += new System.EventHandler(this.saveDocumentAsToolStripMenuItem_Click);
			// 
			// rendersToolStripMenuItem
			// 
			this.rendersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renderNameBox,
            this.newRenderToolStripMenuItem,
            this.editRenderToolStripMenuItem,
            this.clearRenderToolStripMenuItem,
            this.exportRenderToolStripMenuItem,
            this.updateRenderToolStripMenuItem,
            this.removeRenderToolStripMenuItem});
			this.rendersToolStripMenuItem.Name = "rendersToolStripMenuItem";
			this.rendersToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
			this.rendersToolStripMenuItem.Text = "Renders";
			// 
			// renderNameBox
			// 
			this.renderNameBox.BackColor = System.Drawing.SystemColors.ControlLight;
			this.renderNameBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.renderNameBox.Name = "renderNameBox";
			this.renderNameBox.Size = new System.Drawing.Size(121, 23);
			this.renderNameBox.ToolTipText = "List of all renders in the current document.\r\n\r\nType a new name and press enter t" +
    "o create a new render.";
			this.renderNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.renderNameBox_KeyDown);
			// 
			// newRenderToolStripMenuItem
			// 
			this.newRenderToolStripMenuItem.Name = "newRenderToolStripMenuItem";
			this.newRenderToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.newRenderToolStripMenuItem.Text = "New";
			this.newRenderToolStripMenuItem.Click += new System.EventHandler(this.newRenderToolStripMenuItem_Click);
			// 
			// editRenderToolStripMenuItem
			// 
			this.editRenderToolStripMenuItem.Name = "editRenderToolStripMenuItem";
			this.editRenderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
			this.editRenderToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.editRenderToolStripMenuItem.Text = "Edit";
			this.editRenderToolStripMenuItem.Click += new System.EventHandler(this.editRenderToolStripMenuItem_Click);
			// 
			// clearRenderToolStripMenuItem
			// 
			this.clearRenderToolStripMenuItem.Name = "clearRenderToolStripMenuItem";
			this.clearRenderToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.clearRenderToolStripMenuItem.Text = "Clear";
			this.clearRenderToolStripMenuItem.Click += new System.EventHandler(this.clearRenderToolStripMenuItem_Click);
			// 
			// exportRenderToolStripMenuItem
			// 
			this.exportRenderToolStripMenuItem.Name = "exportRenderToolStripMenuItem";
			this.exportRenderToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.exportRenderToolStripMenuItem.Text = "Export";
			this.exportRenderToolStripMenuItem.Click += new System.EventHandler(this.exportRenderToolStripMenuItem_Click);
			// 
			// updateRenderToolStripMenuItem
			// 
			this.updateRenderToolStripMenuItem.Name = "updateRenderToolStripMenuItem";
			this.updateRenderToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.updateRenderToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.updateRenderToolStripMenuItem.Text = "Update";
			this.updateRenderToolStripMenuItem.Click += new System.EventHandler(this.updateRenderToolStripMenuItem_Click);
			// 
			// removeRenderToolStripMenuItem
			// 
			this.removeRenderToolStripMenuItem.Name = "removeRenderToolStripMenuItem";
			this.removeRenderToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.removeRenderToolStripMenuItem.Text = "Remove";
			this.removeRenderToolStripMenuItem.Click += new System.EventHandler(this.removeRenderToolStripMenuItem_Click);
			// 
			// gradientsToolStripMenuItem
			// 
			this.gradientsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gradientNameBox,
            this.newGradientToolStripMenuItem,
            this.editGradientToolStripMenuItem,
            this.removeGradientToolStripMenuItem});
			this.gradientsToolStripMenuItem.Name = "gradientsToolStripMenuItem";
			this.gradientsToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
			this.gradientsToolStripMenuItem.Text = "Gradients";
			// 
			// gradientNameBox
			// 
			this.gradientNameBox.BackColor = System.Drawing.SystemColors.ControlLight;
			this.gradientNameBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.gradientNameBox.Name = "gradientNameBox";
			this.gradientNameBox.Size = new System.Drawing.Size(121, 23);
			this.gradientNameBox.ToolTipText = "List of all gradients in the current document.\r\n\r\nType a new name and press enter" +
    " to create a new gradient.\r\n";
			this.gradientNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gradientNameBox_KeyDown);
			// 
			// newGradientToolStripMenuItem
			// 
			this.newGradientToolStripMenuItem.Name = "newGradientToolStripMenuItem";
			this.newGradientToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.newGradientToolStripMenuItem.Text = "New";
			this.newGradientToolStripMenuItem.Click += new System.EventHandler(this.newGradientToolStripMenuItem_Click);
			// 
			// editGradientToolStripMenuItem
			// 
			this.editGradientToolStripMenuItem.Name = "editGradientToolStripMenuItem";
			this.editGradientToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
			this.editGradientToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.editGradientToolStripMenuItem.Text = "Edit";
			this.editGradientToolStripMenuItem.Click += new System.EventHandler(this.editGradientToolStripMenuItem_Click);
			// 
			// removeGradientToolStripMenuItem
			// 
			this.removeGradientToolStripMenuItem.Name = "removeGradientToolStripMenuItem";
			this.removeGradientToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.removeGradientToolStripMenuItem.Text = "Remove";
			this.removeGradientToolStripMenuItem.Click += new System.EventHandler(this.removeGradientToolStripMenuItem_Click);
			// 
			// effectsToolStripMenuItem
			// 
			this.effectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.effectNameBox,
            this.newEffectToolStripMenuItem,
            this.editEffectToolStripMenuItem,
            this.removeEffectToolStripMenuItem,
            this.toolStripSeparator1,
            this.addEffectToolStripMenuItem});
			this.effectsToolStripMenuItem.Name = "effectsToolStripMenuItem";
			this.effectsToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
			this.effectsToolStripMenuItem.Text = "Effects";
			// 
			// effectNameBox
			// 
			this.effectNameBox.BackColor = System.Drawing.SystemColors.ControlLight;
			this.effectNameBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.effectNameBox.Name = "effectNameBox";
			this.effectNameBox.Size = new System.Drawing.Size(121, 23);
			this.effectNameBox.ToolTipText = "List of all effects in the current document.\r\n\r\nType a new name and press enter t" +
    "o create a new effect.\r\n";
			this.effectNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.effectNameBox_KeyDown);
			// 
			// newEffectToolStripMenuItem
			// 
			this.newEffectToolStripMenuItem.Name = "newEffectToolStripMenuItem";
			this.newEffectToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.newEffectToolStripMenuItem.Text = "New";
			this.newEffectToolStripMenuItem.Click += new System.EventHandler(this.newEffectToolStripMenuItem_Click);
			// 
			// editEffectToolStripMenuItem
			// 
			this.editEffectToolStripMenuItem.Name = "editEffectToolStripMenuItem";
			this.editEffectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.editEffectToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.editEffectToolStripMenuItem.Text = "Edit";
			this.editEffectToolStripMenuItem.Click += new System.EventHandler(this.editEffectToolStripMenuItem_Click);
			// 
			// removeEffectToolStripMenuItem
			// 
			this.removeEffectToolStripMenuItem.Name = "removeEffectToolStripMenuItem";
			this.removeEffectToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.removeEffectToolStripMenuItem.Text = "Remove";
			this.removeEffectToolStripMenuItem.Click += new System.EventHandler(this.removeEffectToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
			// 
			// addEffectToolStripMenuItem
			// 
			this.addEffectToolStripMenuItem.Name = "addEffectToolStripMenuItem";
			this.addEffectToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.addEffectToolStripMenuItem.Text = "Add";
			this.addEffectToolStripMenuItem.Click += new System.EventHandler(this.addEffectToolStripMenuItem_Click);
			// 
			// brushesToolStripMenuItem
			// 
			this.brushesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brushNameBox,
            this.newBrushToolStripMenuItem,
            this.editBrushToolStripMenuItem,
            this.removeBrushToolStripMenuItem});
			this.brushesToolStripMenuItem.Name = "brushesToolStripMenuItem";
			this.brushesToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
			this.brushesToolStripMenuItem.Text = "Brushes";
			// 
			// brushNameBox
			// 
			this.brushNameBox.BackColor = System.Drawing.SystemColors.ControlLight;
			this.brushNameBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.brushNameBox.Name = "brushNameBox";
			this.brushNameBox.Size = new System.Drawing.Size(121, 23);
			this.brushNameBox.ToolTipText = "List of all brushes in the current document.\r\n\r\nType a new name and press enter t" +
    "o create a new brush.\r\n";
			this.brushNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.brushNameBox_KeyDown);
			// 
			// newBrushToolStripMenuItem
			// 
			this.newBrushToolStripMenuItem.Name = "newBrushToolStripMenuItem";
			this.newBrushToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.newBrushToolStripMenuItem.Text = "New";
			this.newBrushToolStripMenuItem.Click += new System.EventHandler(this.newBrushToolStripMenuItem_Click);
			// 
			// editBrushToolStripMenuItem
			// 
			this.editBrushToolStripMenuItem.Name = "editBrushToolStripMenuItem";
			this.editBrushToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
			this.editBrushToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.editBrushToolStripMenuItem.Text = "Edit";
			this.editBrushToolStripMenuItem.Click += new System.EventHandler(this.editBrushToolStripMenuItem_Click);
			// 
			// removeBrushToolStripMenuItem
			// 
			this.removeBrushToolStripMenuItem.Name = "removeBrushToolStripMenuItem";
			this.removeBrushToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.removeBrushToolStripMenuItem.Text = "Remove";
			this.removeBrushToolStripMenuItem.Click += new System.EventHandler(this.removeBrushToolStripMenuItem_Click);
			// 
			// selectedEffectList
			// 
			this.selectedEffectList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.selectedEffectList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.selectedEffectList.ItemHeight = 15;
			this.selectedEffectList.Location = new System.Drawing.Point(3, 19);
			this.selectedEffectList.Name = "selectedEffectList";
			this.selectedEffectList.Size = new System.Drawing.Size(186, 244);
			this.selectedEffectList.TabIndex = 0;
			this.toolTip.SetToolTip(this.selectedEffectList, "The effects that are currently influencing the render.\r\n\r\nDouble-click an effect " +
        "to remove it from this list.");
			this.selectedEffectList.DoubleClick += new System.EventHandler(this.selectedEffectList_DoubleClick);
			// 
			// rightBrushNameBox
			// 
			this.rightBrushNameBox.BackColor = System.Drawing.SystemColors.ControlLight;
			this.rightBrushNameBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.rightBrushNameBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.rightBrushNameBox.FormattingEnabled = true;
			this.rightBrushNameBox.Location = new System.Drawing.Point(59, 51);
			this.rightBrushNameBox.Name = "rightBrushNameBox";
			this.rightBrushNameBox.Size = new System.Drawing.Size(121, 23);
			this.rightBrushNameBox.TabIndex = 2;
			this.toolTip.SetToolTip(this.rightBrushNameBox, "The brush that will be used when painting with the right mouse button.");
			this.rightBrushNameBox.SelectedIndexChanged += new System.EventHandler(this.rightBrushNameBox_SelectedIndexChanged);
			// 
			// leftBrushNameBox
			// 
			this.leftBrushNameBox.BackColor = System.Drawing.SystemColors.ControlLight;
			this.leftBrushNameBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.leftBrushNameBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.leftBrushNameBox.FormattingEnabled = true;
			this.leftBrushNameBox.Location = new System.Drawing.Point(59, 22);
			this.leftBrushNameBox.Name = "leftBrushNameBox";
			this.leftBrushNameBox.Size = new System.Drawing.Size(121, 23);
			this.leftBrushNameBox.TabIndex = 1;
			this.toolTip.SetToolTip(this.leftBrushNameBox, "The brush that will be used when painting with the left mouse button.");
			this.leftBrushNameBox.SelectedIndexChanged += new System.EventHandler(this.leftBrushNameBox_SelectedIndexChanged);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.renderArea);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
			this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
			this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
			this.splitContainer1.Size = new System.Drawing.Size(1012, 483);
			this.splitContainer1.SplitterDistance = 816;
			this.splitContainer1.TabIndex = 3;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.selectedEffectList);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 217);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(192, 266);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Effects";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.selectedGradientBox);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new System.Drawing.Point(0, 161);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(192, 56);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Gradient";
			// 
			// selectedGradientBox
			// 
			this.selectedGradientBox.BackColor = System.Drawing.SystemColors.ControlLight;
			this.selectedGradientBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.selectedGradientBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.selectedGradientBox.FormattingEnabled = true;
			this.selectedGradientBox.Location = new System.Drawing.Point(9, 22);
			this.selectedGradientBox.Name = "selectedGradientBox";
			this.selectedGradientBox.Size = new System.Drawing.Size(171, 23);
			this.selectedGradientBox.TabIndex = 0;
			this.selectedGradientBox.SelectedIndexChanged += new System.EventHandler(this.selectedGradientBox_SelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.paintEffectsBox);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.rightBrushNameBox);
			this.groupBox1.Controls.Add(this.leftBrushNameBox);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 54);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(192, 107);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Brushes";
			// 
			// paintEffectsBox
			// 
			this.paintEffectsBox.AutoSize = true;
			this.paintEffectsBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.paintEffectsBox.Location = new System.Drawing.Point(49, 80);
			this.paintEffectsBox.Name = "paintEffectsBox";
			this.paintEffectsBox.Size = new System.Drawing.Size(131, 21);
			this.paintEffectsBox.TabIndex = 5;
			this.paintEffectsBox.Text = "Paint Effects";
			this.paintEffectsBox.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "Right";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "Left";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.selectedRenderBox);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox4.Location = new System.Drawing.Point(0, 0);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(192, 54);
			this.groupBox4.TabIndex = 6;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Render";
			// 
			// selectedRenderBox
			// 
			this.selectedRenderBox.BackColor = System.Drawing.SystemColors.ControlLight;
			this.selectedRenderBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.selectedRenderBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.selectedRenderBox.FormattingEnabled = true;
			this.selectedRenderBox.Location = new System.Drawing.Point(9, 22);
			this.selectedRenderBox.Name = "selectedRenderBox";
			this.selectedRenderBox.Size = new System.Drawing.Size(171, 23);
			this.selectedRenderBox.TabIndex = 0;
			this.selectedRenderBox.SelectedIndexChanged += new System.EventHandler(this.selectedRenderBox_SelectedIndexChanged);
			// 
			// generatorsToolStripMenuItem
			// 
			this.generatorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generatorNameBox,
            this.newGeneratorToolStripMenuItem,
            this.editGeneratorToolStripMenuItem,
            this.removeGeneratorToolStripMenuItem,
            this.toolStripSeparator2,
            this.applyGeneratorToolStripMenuItem});
			this.generatorsToolStripMenuItem.Name = "generatorsToolStripMenuItem";
			this.generatorsToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
			this.generatorsToolStripMenuItem.Text = "Generators";
			// 
			// generatorNameBox
			// 
			this.generatorNameBox.BackColor = System.Drawing.SystemColors.ControlLight;
			this.generatorNameBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.generatorNameBox.Name = "generatorNameBox";
			this.generatorNameBox.Size = new System.Drawing.Size(121, 23);
			this.generatorNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.generatorNameBox_KeyDown);
			// 
			// newGeneratorToolStripMenuItem
			// 
			this.newGeneratorToolStripMenuItem.Name = "newGeneratorToolStripMenuItem";
			this.newGeneratorToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.newGeneratorToolStripMenuItem.Text = "New";
			this.newGeneratorToolStripMenuItem.Click += new System.EventHandler(this.newGeneratorToolStripMenuItem_Click);
			// 
			// editGeneratorToolStripMenuItem
			// 
			this.editGeneratorToolStripMenuItem.Name = "editGeneratorToolStripMenuItem";
			this.editGeneratorToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.editGeneratorToolStripMenuItem.Text = "Edit";
			this.editGeneratorToolStripMenuItem.Click += new System.EventHandler(this.editGeneratorToolStripMenuItem_Click);
			// 
			// removeGeneratorToolStripMenuItem
			// 
			this.removeGeneratorToolStripMenuItem.Name = "removeGeneratorToolStripMenuItem";
			this.removeGeneratorToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.removeGeneratorToolStripMenuItem.Text = "Remove";
			this.removeGeneratorToolStripMenuItem.Click += new System.EventHandler(this.removeGeneratorToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
			// 
			// applyGeneratorToolStripMenuItem
			// 
			this.applyGeneratorToolStripMenuItem.Name = "applyGeneratorToolStripMenuItem";
			this.applyGeneratorToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.applyGeneratorToolStripMenuItem.Text = "Apply";
			this.applyGeneratorToolStripMenuItem.Click += new System.EventHandler(this.applyGeneratorToolStripMenuItem_Click);
			// 
			// renderArea
			// 
			this.renderArea.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("renderArea.BackgroundImage")));
			this.renderArea.Dock = System.Windows.Forms.DockStyle.Fill;
			this.renderArea.Image = null;
			this.renderArea.Location = new System.Drawing.Point(0, 0);
			this.renderArea.Name = "renderArea";
			this.renderArea.OverlayThickness = 1F;
			this.renderArea.Size = new System.Drawing.Size(816, 483);
			this.renderArea.TabIndex = 0;
			this.renderArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.renderArea_KeyDown);
			this.renderArea.KeyUp += new System.Windows.Forms.KeyEventHandler(this.renderArea_KeyUp);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1012, 507);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.Name = "MainWindow";
			this.Text = "Fountain";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private Controls.RenderArea renderArea;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem documentToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newDocumentToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openDocumentToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveDocumentToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveDocumentAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rendersToolStripMenuItem;
		private System.Windows.Forms.ToolStripComboBox renderNameBox;
		private System.Windows.Forms.ToolStripMenuItem editRenderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeRenderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportRenderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem updateRenderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gradientsToolStripMenuItem;
		private System.Windows.Forms.ToolStripComboBox gradientNameBox;
		private System.Windows.Forms.ToolStripMenuItem editGradientToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeGradientToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem effectsToolStripMenuItem;
		private System.Windows.Forms.ToolStripComboBox effectNameBox;
		private System.Windows.Forms.ToolStripMenuItem editEffectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeEffectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem brushesToolStripMenuItem;
		private System.Windows.Forms.ToolStripComboBox brushNameBox;
		private System.Windows.Forms.ToolStripMenuItem editBrushToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeBrushToolStripMenuItem;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripMenuItem addEffectToolStripMenuItem;
		private System.Windows.Forms.ComboBox rightBrushNameBox;
		private System.Windows.Forms.ComboBox leftBrushNameBox;
		private System.Windows.Forms.ListBox selectedEffectList;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox paintEffectsBox;
		private System.Windows.Forms.ToolStripMenuItem clearRenderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newRenderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newGradientToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newEffectToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem newBrushToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox selectedGradientBox;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ComboBox selectedRenderBox;
		private System.Windows.Forms.ToolStripMenuItem generatorsToolStripMenuItem;
		private System.Windows.Forms.ToolStripComboBox generatorNameBox;
		private System.Windows.Forms.ToolStripMenuItem newGeneratorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editGeneratorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeGeneratorToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem applyGeneratorToolStripMenuItem;

	}
}