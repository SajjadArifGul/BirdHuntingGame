namespace BirdHuntingGame.Forms
{
	partial class GameOptionsForm
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
			this.label2 = new System.Windows.Forms.Label();
			this.pbBird = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbBird = new System.Windows.Forms.ComboBox();
			this.pbGun = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbGun = new System.Windows.Forms.ComboBox();
			this.btnStartGame = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pbBird)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbGun)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.label2.Location = new System.Drawing.Point(12, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(626, 65);
			this.label2.TabIndex = 2;
			this.label2.Text = "Bird Hunting Game";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pbBird
			// 
			this.pbBird.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pbBird.BackColor = System.Drawing.Color.Transparent;
			this.pbBird.Image = global::BirdHuntingGame.Properties.Resources.bird3;
			this.pbBird.Location = new System.Drawing.Point(187, 408);
			this.pbBird.Name = "pbBird";
			this.pbBird.Padding = new System.Windows.Forms.Padding(20);
			this.pbBird.Size = new System.Drawing.Size(262, 89);
			this.pbBird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbBird.TabIndex = 11;
			this.pbBird.TabStop = false;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.label3.Location = new System.Drawing.Point(263, 341);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(106, 25);
			this.label3.TabIndex = 9;
			this.label3.Text = "Select Bird";
			// 
			// cmbBird
			// 
			this.cmbBird.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cmbBird.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmbBird.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBird.FormattingEnabled = true;
			this.cmbBird.Items.AddRange(new object[] {
            "Bird 1",
            "Bird 2",
            "Bird 3"});
			this.cmbBird.Location = new System.Drawing.Point(187, 369);
			this.cmbBird.Name = "cmbBird";
			this.cmbBird.Size = new System.Drawing.Size(262, 33);
			this.cmbBird.TabIndex = 10;
			this.cmbBird.SelectedIndexChanged += new System.EventHandler(this.cmbBird_SelectedIndexChanged);
			// 
			// pbGun
			// 
			this.pbGun.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pbGun.BackColor = System.Drawing.Color.Transparent;
			this.pbGun.Image = global::BirdHuntingGame.Properties.Resources.Glock_Gun;
			this.pbGun.Location = new System.Drawing.Point(187, 231);
			this.pbGun.Name = "pbGun";
			this.pbGun.Padding = new System.Windows.Forms.Padding(20);
			this.pbGun.Size = new System.Drawing.Size(262, 89);
			this.pbGun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbGun.TabIndex = 8;
			this.pbGun.TabStop = false;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.label1.Location = new System.Drawing.Point(263, 164);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 25);
			this.label1.TabIndex = 6;
			this.label1.Text = "Select Gun";
			// 
			// cmbGun
			// 
			this.cmbGun.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.cmbGun.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cmbGun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGun.FormattingEnabled = true;
			this.cmbGun.Items.AddRange(new object[] {
            "9mm Glock 17",
            "M1 Garand Single",
            "ShotGun"});
			this.cmbGun.Location = new System.Drawing.Point(187, 192);
			this.cmbGun.Name = "cmbGun";
			this.cmbGun.Size = new System.Drawing.Size(262, 33);
			this.cmbGun.TabIndex = 7;
			this.cmbGun.SelectedIndexChanged += new System.EventHandler(this.cmbGun_SelectedIndexChanged);
			// 
			// btnStartGame
			// 
			this.btnStartGame.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnStartGame.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnStartGame.FlatAppearance.BorderSize = 0;
			this.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnStartGame.Location = new System.Drawing.Point(144, 503);
			this.btnStartGame.Name = "btnStartGame";
			this.btnStartGame.Size = new System.Drawing.Size(343, 84);
			this.btnStartGame.TabIndex = 12;
			this.btnStartGame.Text = "Start Game";
			this.btnStartGame.UseVisualStyleBackColor = true;
			this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
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
			this.btnClose.Location = new System.Drawing.Point(588, 9);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(50, 50);
			this.btnClose.TabIndex = 13;
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// GameOptionsForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackgroundImage = global::BirdHuntingGame.Properties.Resources.bgwallpaper;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(650, 606);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnStartGame);
			this.Controls.Add(this.pbBird);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbBird);
			this.Controls.Add(this.pbGun);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbGun);
			this.Controls.Add(this.label2);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "GameOptionsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GameOptionsForm";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.GameOptionsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pbBird)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbGun)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pbBird;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pbGun;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnStartGame;
		private System.Windows.Forms.ComboBox cmbBird;
		private System.Windows.Forms.ComboBox cmbGun;
		private System.Windows.Forms.Button btnClose;
	}
}