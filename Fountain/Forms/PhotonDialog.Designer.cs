namespace Fountain.Forms
{
	partial class PhotonDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotonDialog));
			this.redBar = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.greenBar = new System.Windows.Forms.TrackBar();
			this.blueBar = new System.Windows.Forms.TrackBar();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.alphaBar = new System.Windows.Forms.TrackBar();
			this.label4 = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.colorPanel = new Fountain.Controls.PhotonPanel();
			((System.ComponentModel.ISupportInitialize)(this.redBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.greenBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.blueBar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.alphaBar)).BeginInit();
			this.SuspendLayout();
			// 
			// redBar
			// 
			this.redBar.Location = new System.Drawing.Point(72, 12);
			this.redBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.redBar.Maximum = 255;
			this.redBar.Name = "redBar";
			this.redBar.Size = new System.Drawing.Size(269, 45);
			this.redBar.TabIndex = 0;
			this.redBar.TickFrequency = 16;
			this.redBar.ValueChanged += new System.EventHandler(this.redBar_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 19);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Red";
			// 
			// greenBar
			// 
			this.greenBar.Location = new System.Drawing.Point(72, 63);
			this.greenBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.greenBar.Maximum = 255;
			this.greenBar.Name = "greenBar";
			this.greenBar.Size = new System.Drawing.Size(269, 45);
			this.greenBar.TabIndex = 2;
			this.greenBar.TickFrequency = 16;
			this.greenBar.ValueChanged += new System.EventHandler(this.greenBar_ValueChanged);
			// 
			// blueBar
			// 
			this.blueBar.Location = new System.Drawing.Point(72, 114);
			this.blueBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.blueBar.Maximum = 255;
			this.blueBar.Name = "blueBar";
			this.blueBar.Size = new System.Drawing.Size(269, 45);
			this.blueBar.TabIndex = 3;
			this.blueBar.TickFrequency = 16;
			this.blueBar.ValueChanged += new System.EventHandler(this.blueBar_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 121);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Blue";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 70);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Green";
			// 
			// alphaBar
			// 
			this.alphaBar.Location = new System.Drawing.Point(72, 165);
			this.alphaBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.alphaBar.Maximum = 255;
			this.alphaBar.Name = "alphaBar";
			this.alphaBar.Size = new System.Drawing.Size(269, 45);
			this.alphaBar.TabIndex = 6;
			this.alphaBar.TickFrequency = 16;
			this.alphaBar.ValueChanged += new System.EventHandler(this.alphaBar_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 172);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Alpha";
			// 
			// okButton
			// 
			this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.okButton.Location = new System.Drawing.Point(349, 184);
			this.okButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(136, 23);
			this.okButton.TabIndex = 8;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cancelButton.Location = new System.Drawing.Point(493, 184);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(139, 23);
			this.cancelButton.TabIndex = 9;
			this.cancelButton.Text = "CANCEL";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// colorPanel
			// 
			this.colorPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("colorPanel.BackgroundImage")));
			this.colorPanel.Location = new System.Drawing.Point(349, 12);
			this.colorPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.colorPanel.Name = "colorPanel";
			this.colorPanel.Size = new System.Drawing.Size(283, 166);
			this.colorPanel.TabIndex = 10;
			// 
			// PhotonDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(647, 214);
			this.Controls.Add(this.colorPanel);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.alphaBar);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.blueBar);
			this.Controls.Add(this.greenBar);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.redBar);
			this.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "PhotonDialog";
			this.ShowIcon = false;
			this.Text = "Color";
			((System.ComponentModel.ISupportInitialize)(this.redBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.greenBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.blueBar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.alphaBar)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TrackBar redBar;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar greenBar;
		private System.Windows.Forms.TrackBar blueBar;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TrackBar alphaBar;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private Controls.PhotonPanel colorPanel;
	}
}