using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BirdHuntingGame.Code;
using System.Media;
using System.IO;
using System.Runtime.InteropServices;

namespace BirdHuntingGame.Forms
{
	public partial class PlayGameForm : Form
	{
		Timer bird1Timer = new Timer();

		int WindowWidth = 0;
		int WindowHeight = 0;

		[DllImport("winmm.dll")]
		static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

		private const int MM_MCINOTIFY = 0x03b9;
		private const int MCI_NOTIFY_SUCCESS = 0x01;

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == MM_MCINOTIFY)
			{
				switch (m.WParam.ToInt32())
				{
					case MCI_NOTIFY_SUCCESS:
						mciSendString("close forest-and-birds", null, 0, this.Handle); // first close, after first run, the previous opened file should be terminated
						mciSendString("stop forest-and-birds", null, 0, this.Handle);
						PlayForestBirdsSound();
						break;
					default:
						break;
				}
			}
			base.WndProc(ref m);
		}
		
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}

		public PlayGameForm()
		{
			InitializeComponent();

			//this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			//this.TransparencyKey = Color.FromKnownColor(KnownColor.Control);
			//this.Update();

			this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.crosshair.GetHicon());

			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

		}

		private void PlayGameForm_Load(object sender, EventArgs e)
		{	
			WindowWidth = this.Width;
			WindowHeight = this.Height;
			
			InitBirdTimer();

			KnowSounds();
			PlayForestBirdsSound();
		}

		public void KnowSounds()
		{
			mciSendString(@"open forest-and-birds.wav type waveaudio alias forest-and-birds", null, 0, IntPtr.Zero);
			mciSendString(@"open gun1.wav type waveaudio alias gun1", null, 0, IntPtr.Zero);
		}

		public BirdTimer BirdTimer { get; set; }

		public void InitBirdTimer()
		{
			if(BirdTimer != null)
			{
				BirdTimer.Stop();
				BirdTimer.BirdBox.Dispose();
				BirdTimer.Dispose();
			}
			
			BirdTimer = new BirdTimer();
			BirdTimer.BirdBox = NewBirdBox();
			
			BirdTimer.Interval = Extensions.GetRandomInterval();
			BirdTimer.Tick += new EventHandler(BirdTimer_Tick);

			this.Controls.Add(BirdTimer.BirdBox);

			BirdTimer.Start();
		}
		
		private void BirdTimer_Tick(object sender, EventArgs e)
		{
			int XLocation = 0;
			int YLocation = 0;

			if (BirdTimer.BirdBox.Status == "Alive")
			{
				if (BirdTimer.BirdBox.Location.X + BirdTimer.BirdBox.Size.Width < 0)
				{
					XLocation = this.WindowWidth;
				}
				else
				{
					XLocation = BirdTimer.BirdBox.Location.X - Extensions.GetRandomNumber();
				}

				if (BirdTimer.BirdBox.Location.Y + BirdTimer.BirdBox.Size.Height > WindowHeight)
				{
					BirdTimer.BirdBox.Status = "Downed";
					return;
				}
				else if (BirdTimer.BirdBox.Location.Y + BirdTimer.BirdBox.Size.Height < 0)
				{
					BirdTimer.BirdBox.Status = "Downed";
					return;
				}
				else
				{
					YLocation = BirdTimer.BirdBox.Location.Y + Extensions.GetLimitedRandomNumber(-8, 8);
				}

				lbl1X.Text = XLocation.ToString();
				lbl1Y.Text = YLocation.ToString();
				
				this.SuspendLayout();
				BirdTimer.BirdBox.Location = new Point(XLocation, YLocation);
				this.ResumeLayout();
			}
			else if(BirdTimer.BirdBox.Status == "Dead")
			{
				if (BirdTimer.BirdBox.Location.X + BirdTimer.BirdBox.Size.Width < 0)
				{
					BirdTimer.BirdBox.Status = "Downed";
					return;
				}
				else
				{
					XLocation = BirdTimer.BirdBox.Location.X - Extensions.GetLimitedRandomNumber(3, 5);
				}

				if (BirdTimer.BirdBox.Location.Y + BirdTimer.BirdBox.Size.Height > WindowHeight)
				{
					BirdTimer.BirdBox.Status = "Downed";
					return;
				}
				else
				{
					YLocation = BirdTimer.BirdBox.Location.Y + Extensions.GetLimitedRandomNumber(5, 10);
				}
				
				lbl1X.Text = XLocation.ToString();
				lbl1Y.Text = YLocation.ToString();

				this.SuspendLayout();
				BirdTimer.BirdBox.Location = new Point(XLocation, YLocation);
				this.ResumeLayout();
			}
			else
			{
				InitBirdTimer();
			}

			label5.Text = BirdTimer.BirdBox.Location.ToString();
		}

		public BirdBox NewBirdBox()
		{
			BirdBox birdBox = new BirdBox();
			birdBox.Size = new Size(100, 100);
			birdBox.SizeMode = PictureBoxSizeMode.StretchImage;
			birdBox.Image = Properties.Resources.bird1;
			birdBox.BackColor = Color.Transparent;

			birdBox.Location = new Point(WindowWidth, Extensions.GetLimitedRandomNumber(200, WindowHeight - 200));

			birdBox.Click += new EventHandler(birdBox_Click);

			return birdBox;
		}

		private void birdBox_Click(object sender, EventArgs e)
		{
			BirdBox birdbox = (BirdBox)sender;

			if(birdbox != null)
			{
				birdbox.Status = "Dead";
				PlayGunSound();
				birdbox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
				birdbox.Image = Properties.Resources.explosion_animation;
			}
		}
		
		private void PlayGameForm_Click(object sender, EventArgs e)
		{
			PlayGunSound();
		}

		private void birdBox1_Click(object sender, EventArgs e)
		{

		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
		}

		public void PlayGunSound()
		{
			new System.Threading.Thread(() =>
			{
				FileStream gunSoundFile = new FileStream("gun1.wav", FileMode.Open, FileAccess.Read);
				new SoundPlayer(gunSoundFile).Play();
			}).Start();

			//mciSendString(@"play gun1", null, 0, IntPtr.Zero);
		}
		
		public void PlayForestBirdsSound()
		{
			//new System.Threading.Thread(() => {

			//	FileStream forestBirdsSoundFile = new FileStream("forest-and-birds.wav", FileMode.Open, FileAccess.Read);
			//	new SoundPlayer(forestBirdsSoundFile).Play();

			//}).Start();			

			mciSendString(@"play forest-and-birds notify", null, 0, IntPtr.Zero);
		}
	}
}
