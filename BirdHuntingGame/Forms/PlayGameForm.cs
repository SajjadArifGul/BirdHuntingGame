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
		private GameStatus GameStatus;
		private Guns SelectedGun;
		private Birds SelectedBird;

		private List<BirdTimer> FlyingBirds = new List<BirdTimer>();

		public PlayGameForm(Guns gun, Birds bird)
		{
			InitializeComponent();

			this.GameStatus = GameStatus.Continue;
			this.SelectedGun = gun;
			this.SelectedBird = bird;

			SetupCrossHair();

			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		}

		private void SetupCrossHair()
		{
			if (SelectedGun == Guns.Shotgun)
			{
				this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.ShotGun_crosshair_small.GetHicon());
			}
			else if (SelectedGun == Guns.M1Grand)
			{
				this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.M1Garand_crosshair_small.GetHicon());
			}
			else if (SelectedGun == Guns.Glock)
			{
				this.Cursor = new System.Windows.Forms.Cursor(Properties.Resources.glock_crosshair_small.GetHicon());
			}
		}

		#region SoundRelatedCode

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

		public void KnowSounds()
		{
			mciSendString(@"open Sounds/forest-and-birds.wav type waveaudio alias forest-and-birds", null, 0, IntPtr.Zero);
			mciSendString(@"open Sounds/Glock-Gun-Fire.wav type waveaudio alias Glock-Gun-Fire", null, 0, IntPtr.Zero);
			mciSendString(@"open Sounds/Shotgun-Fire.wav type waveaudio alias Shotgun-Fire", null, 0, IntPtr.Zero);
			mciSendString(@"open Sounds/M1Garand-Fire.wav type waveaudio alias M1Garand-Fire", null, 0, IntPtr.Zero);
		}

		public void PlayGunSound()
		{
			new System.Threading.Thread(() =>
			{
				if (SelectedGun == Guns.Shotgun)
				{
					FileStream gunSoundFile = new FileStream("Sounds/Shotgun-Fire.wav", FileMode.Open, FileAccess.Read);
					new SoundPlayer(gunSoundFile).Play();
				}
				else if (SelectedGun == Guns.M1Grand)
				{
					FileStream gunSoundFile = new FileStream("Sounds/M1Garand-Fire.wav", FileMode.Open, FileAccess.Read);
					new SoundPlayer(gunSoundFile).Play();
				}
				else if (SelectedGun == Guns.Glock)
				{
					FileStream gunSoundFile = new FileStream("Sounds/Glock-Gun-Fire.wav", FileMode.Open, FileAccess.Read);
					new SoundPlayer(gunSoundFile).Play();
				}
			}).Start();
		}

		public void PlayBirdHitSound()
		{
			new System.Threading.Thread(() =>
			{
				FileStream gunSoundFile = new FileStream("Sounds/bird-hit.wav", FileMode.Open, FileAccess.Read);
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
		#endregion

		private void PlayGameForm_Load(object sender, EventArgs e)
		{
			AddNewBird("", "");
			AddNewBird("", "");
			AddNewBird("", "");

			KnowSounds();
			PlayForestBirdsSound();
		}
		
		public void AddNewBird(string Direction, string Bird)
		{
			BirdTimer BirdTimer = new BirdTimer();
			BirdTimer.BirdBox = NewBirdBox(Direction, Bird);
			
			BirdTimer.Interval = Extensions.GetRandomInterval();
			BirdTimer.Tick += new EventHandler(BirdTimer_Tick);

			this.Controls.Add(BirdTimer.BirdBox);

			FlyingBirds.Add(BirdTimer);

			BirdTimer.Start();
		}
		
		private void BirdTimer_Tick(object sender, EventArgs e)
		{
			BirdTimer BirdTimer = (BirdTimer)sender;

			if (BirdTimer != null)
			{
				int XLocation = 0;
				int YLocation = 0;

				if (BirdTimer.BirdBox.Status == "Alive")
				{
					if (BirdTimer.BirdBox.Location.X + BirdTimer.BirdBox.Size.Width < 0)
					{
						//XLocation = this.Width;
						XLocation = BirdTimer.BirdBox.Location.X - Extensions.GetRandomNumber();
						BirdTimer.BirdBox.Status = "Downed";
					}
					else
					{
						XLocation = BirdTimer.BirdBox.Location.X - Extensions.GetRandomNumber();
					}

					if (BirdTimer.BirdBox.Location.Y + BirdTimer.BirdBox.Size.Height > this.Height - 50)
					{
						BirdTimer.BirdBox.Status = "Downed";
						return;
					}
					else if (BirdTimer.BirdBox.Location.Y + BirdTimer.BirdBox.Size.Height - 50 < 0)
					{
						BirdTimer.BirdBox.Status = "Downed";
						return;
					}
					else
					{
						YLocation = BirdTimer.BirdBox.Location.Y + Extensions.GetLimitedRandomNumber(-8, 8);
					}
					
					//this.SuspendLayout();
					BirdTimer.BirdBox.Location = new Point(XLocation, YLocation);
					//this.ResumeLayout();
				}
				else if (BirdTimer.BirdBox.Status == "Dead")
				{
					if (BirdTimer.BirdBox.Location.X + BirdTimer.BirdBox.Size.Width < 0)
					{
						BirdTimer.BirdBox.Status = "Downed";
						return;
					}
					else
					{
						XLocation = BirdTimer.BirdBox.Location.X - Extensions.GetLimitedRandomNumber(5, 10);
					}

					if (BirdTimer.BirdBox.Location.Y + BirdTimer.BirdBox.Size.Height > this.Height)
					{
						BirdTimer.BirdBox.Status = "Downed";
						return;
					}
					else
					{
						YLocation = BirdTimer.BirdBox.Location.Y + Extensions.GetLimitedRandomNumber(10, 15);
					}
					
					//this.SuspendLayout();
					BirdTimer.BirdBox.Location = new Point(XLocation, YLocation);
					//this.ResumeLayout();
				}
				else if(BirdTimer.BirdBox.Status == "Downed")
				{
					RemoveBird(BirdTimer);
					AddNewBird("", "");
				}				
			}
		}

		public BirdBox NewBirdBox(string Direction, string Bird)
		{
			BirdBox birdBox = new BirdBox();
			var birdBoxSize = Extensions.GetLimitedRandomNumber(50, 120);
			birdBox.Size = new Size(birdBoxSize, birdBoxSize);
			birdBox.SizeMode = PictureBoxSizeMode.StretchImage;
			birdBox.Direction = Direction;
			
			if (SelectedBird == Birds.Parrot)
			{
				birdBox.Image = Properties.Resources.bird3;
			}
			else if (SelectedBird == Birds.Stork)
			{
				birdBox.Image = Properties.Resources.Stork_Bird;
			}
			else if (SelectedBird == Birds.Crow)
			{
				birdBox.Image = Properties.Resources.bird2;
			}

			birdBox.BackColor = Color.Transparent;

			birdBox.Location = new Point(this.Width, Extensions.GetLimitedRandomNumber(200, this.Height - 200));

			birdBox.Click += new EventHandler(birdBox_Click);
			birdBox.DoubleClick += new EventHandler(birdBox_Click);

			return birdBox;
		}

		private void birdBox_Click(object sender, EventArgs e)
		{
			if (GameStatus == GameStatus.Continue)
			{
				BirdBox birdbox = (BirdBox)sender;

				if (birdbox != null && birdbox.Status != "Dead")
				{
					PlayBirdHitSound();
					birdbox.Status = "Dead";
					birdbox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
					birdbox.Image = Properties.Resources.explosion_animation;
				}
				else
				{
					PlayGunSound();
				}
			}
		}
		
		private void PlayGameForm_Click(object sender, EventArgs e)
		{
			if (GameStatus == GameStatus.Continue)
			{
				PlayGunSound();
			}
		}		

		private void RemoveBird(BirdTimer BirdTimer)
		{
			if (BirdTimer != null)
			{
				FlyingBirds.Remove(BirdTimer);

				BirdTimer.Stop();
				BirdTimer.BirdBox.Dispose();
				BirdTimer.Dispose();
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void btnPause_Click(object sender, EventArgs e)
		{
			if(GameStatus == GameStatus.Continue)
			{
				GameStatus = GameStatus.Pause;

				foreach (var bird in FlyingBirds)
				{
					if(bird != null)
					{
						bird.Stop();
					}
				}

				btnPause.BackgroundImage = Properties.Resources.control_play;
			}
			else
			{
				GameStatus = GameStatus.Continue;

				foreach (var bird in FlyingBirds)
				{
					if (bird != null)
					{
						bird.Start();
					}
				}

				btnPause.BackgroundImage = Properties.Resources.control_pause;
			}
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			//GameOptionsForm.Instance.Close();
			this.Hide();

			GameOptionsForm.Instance.Show();
		}
	}
}
