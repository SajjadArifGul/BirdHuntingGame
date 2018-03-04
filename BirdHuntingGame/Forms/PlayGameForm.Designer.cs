namespace BirdHuntingGame.Forms
{
	partial class PlayGameForm
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
			this.btnClose = new System.Windows.Forms.Button();
			this.btnPause = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.BackColor = System.Drawing.Color.Transparent;
			this.btnClose.BackgroundImage = global::BirdHuntingGame.Properties.Resources.close1;
			this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Location = new System.Drawing.Point(498, 12);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(50, 50);
			this.btnClose.TabIndex = 14;
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnPause
			// 
			this.btnPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPause.BackColor = System.Drawing.Color.Transparent;
			this.btnPause.BackgroundImage = global::BirdHuntingGame.Properties.Resources.control_pause;
			this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnPause.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnPause.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btnPause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPause.Location = new System.Drawing.Point(442, 12);
			this.btnPause.Name = "btnPause";
			this.btnPause.Size = new System.Drawing.Size(50, 50);
			this.btnPause.TabIndex = 15;
			this.btnPause.UseVisualStyleBackColor = false;
			this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBack.BackColor = System.Drawing.Color.Transparent;
			this.btnBack.BackgroundImage = global::BirdHuntingGame.Properties.Resources.settings;
			this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBack.Location = new System.Drawing.Point(386, 12);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(50, 50);
			this.btnBack.TabIndex = 16;
			this.btnBack.UseVisualStyleBackColor = false;
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = global::BirdHuntingGame.Properties.Resources.whiteparrot_animation_3;
			this.pictureBox1.Location = new System.Drawing.Point(371, 414);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(53, 63);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 17;
			this.pictureBox1.TabStop = false;
			// 
			// PlayGameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::BirdHuntingGame.Properties.Resources.Wallpaper4Animated;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(560, 476);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.btnPause);
			this.Controls.Add(this.btnClose);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "PlayGameForm";
			this.Text = "PlayGameForm";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.PlayGameForm_Load);
			this.Click += new System.EventHandler(this.PlayGameForm_Click);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnPause;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}