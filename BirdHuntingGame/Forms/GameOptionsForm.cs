using BirdHuntingGame.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirdHuntingGame.Forms
{
	public partial class GameOptionsForm : Form
	{
		#region Define as Singleton
		private static GameOptionsForm _Instance;

		public static GameOptionsForm Instance
		{
			get
			{
				if (_Instance == null)
				{
					_Instance = new GameOptionsForm();
				}

				return (_Instance);
			}
		}

		private GameOptionsForm()
		{
			InitializeComponent();
		}
		#endregion

		private void GameOptionsForm_Load(object sender, EventArgs e)
		{
			cmbGun.SelectedIndex = 0;
			cmbBird.SelectedIndex = 0;
		}

		private void cmbGun_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(cmbGun.SelectedItem.ToString() == "9mm Glock 17")
			{
				pbGun.Image = Properties.Resources.Glock_Gun;
			}
			else if (cmbGun.SelectedItem.ToString() == "M1 Garand Single")
			{
				pbGun.Image = Properties.Resources.M1Garand_Gun;
			}
			else if (cmbGun.SelectedItem.ToString() == "ShotGun")
			{
				pbGun.Image = Properties.Resources.Shotgun;
			}
		}
		
		private void cmbBird_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbBird.SelectedItem.ToString() == "Parrot")
			{
				pbBird.Image = Properties.Resources.bird3;
			}
			else if (cmbBird.SelectedItem.ToString() == "Stork")
			{
				pbBird.Image = Properties.Resources.Stork_Bird;
			}
			else if (cmbBird.SelectedItem.ToString() == "Crow")
			{
				pbBird.Image = Properties.Resources.bird2;
			}
		}

		private void btnStartGame_Click(object sender, EventArgs e)
		{
			Guns SelectedGun = Guns.Shotgun;
			Birds SelectedBird = Birds.Parrot;

			if (cmbGun.SelectedItem.ToString() == "9mm Glock 17")
			{
				SelectedGun = Guns.Glock;
			}
			else if (cmbGun.SelectedItem.ToString() == "M1 Garand Single")
			{
				SelectedGun = Guns.M1Grand;
			}
			else if (cmbGun.SelectedItem.ToString() == "ShotGun")
			{
				SelectedGun = Guns.Shotgun;
			}

			if (cmbBird.SelectedItem.ToString() == "Parrot")
			{
				SelectedBird = Birds.Parrot;
			}
			else if (cmbBird.SelectedItem.ToString() == "Stork")
			{
				SelectedBird = Birds.Stork;
			}
			else if (cmbBird.SelectedItem.ToString() == "Crow")
			{
				SelectedBird = Birds.Crow;
			}

			PlayGameForm playGameForm = new PlayGameForm(SelectedGun, SelectedBird);
			this.Hide();
			playGameForm.ShowDialog(); 
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
