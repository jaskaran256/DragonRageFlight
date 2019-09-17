using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragonRageFlight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int StartRace = Dragon1.Left;
            int RaceTrackLength = pictureBox1.Width - Dragon1.Right;

            Variables.dragon[0] = new Dragon() { dragonImage = Dragon1, positionToFinish = RaceTrackLength, positionToStart = StartRace };
            Variables.dragon[1] = new Dragon() { dragonImage = Dragon2, positionToFinish = RaceTrackLength, positionToStart = StartRace };
            Variables.dragon[2] = new Dragon() { dragonImage = Dragon3, positionToFinish = RaceTrackLength, positionToStart = StartRace };
            Variables.dragon[3] = new Dragon() { dragonImage = Dragon4, positionToFinish = RaceTrackLength, positionToStart = StartRace };

            Variables.dragonGambler[0] = new Bettor() { PocketCash = 65, activityIndicator = label1, selectedGambler = radioButton1, title = "Player 1" };
            Variables.dragonGambler[1] = new Bettor() { PocketCash = 75, activityIndicator = label4, selectedGambler = radioButton2, title = "Player 2" };
            Variables.dragonGambler[2] = new Bettor() { PocketCash = 55, activityIndicator = label5, selectedGambler = radioButton3, title = "Player 3" };

            // Sets the default values to the labels
            Variables.dragonGambler[0].ActivityLabelUpdator();
            Variables.dragonGambler[1].ActivityLabelUpdator();
            Variables.dragonGambler[2].ActivityLabelUpdator();
            Variables.dragonGambler[0].ResetBettingHistory();
            Variables.dragonGambler[1].ResetBettingHistory();
            Variables.dragonGambler[2].ResetBettingHistory();
        }

        private void PlaceBet_Click(object sender, EventArgs e)
        {
            Variables.dragonGambler[Variables.CurrentGambler].Betting((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            Variables.dragonGambler[Variables.CurrentGambler].ActivityLabelUpdator();
        }

        private void BeginRace_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            BeginRace.Enabled = false;
        }

        private void QuitGame_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Variables.dragon.Length; i++)
            {
                Variables.dragon[Variables.randomSpeed.Next(0, 4)].Fly();
                if (Variables.dragon[i].Fly())
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                    BeginRace.Enabled = true;
                    DeclarTheeWinner(i + 1);
                }
            }
        }

        private void MoveDragons()
        {
            Variables.dragon[0].MoveDragonsToStart();
            Variables.dragon[1].MoveDragonsToStart();
            Variables.dragon[2].MoveDragonsToStart();
            Variables.dragon[3].MoveDragonsToStart();
        }

        private void ResetBids()
        {
            label1.Text = "Player 1 hasn't placed a bet.";
            label4.Text = "Player 2 hasn't placed a bet.";
            label5.Text = "Player 3 hasn't placed a bet.";
        }

        private void DeclarTheeWinner(int Winner)
        {
            MessageBox.Show("Dragon #" + Winner + " is the Winning Dragon");
            for (int i = 0; i < Variables.dragonGambler.Length; i++)
            {
                Variables.dragonGambler[i].CollectWinnings(Winner);
                Variables.dragonGambler[i].ActivityLabelUpdator();
                MoveDragons();
                ResetBids();
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Variables.CurrentGambler = 0;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Variables.CurrentGambler = 1;
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Variables.CurrentGambler = 2;
        }
    }
}
