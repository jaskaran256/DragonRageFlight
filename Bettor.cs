using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragonRageFlight
{
    public class Bettor : Bet
    {
        public string title { get; set; }
        public int PocketCash { get; set; }
        public Bet ExistingBet;

        public RadioButton selectedGambler { get; set; }
        public Label activityIndicator { get; set; }

        public void ActivityLabelUpdator()
        {
            selectedGambler.Text = title + " has $" + PocketCash;
        }

        public void ResetBettingHistory()
        {
            ExistingBet = null;
            activityIndicator.Text = title + " hasn't placed a bet";
        }

        public bool Betting(int Amount, int BidAthlete)
        {
            this.ExistingBet = new Bet() { betBalance = Amount, betDragon = BidAthlete };

            if (Amount <= PocketCash)
            {
                activityIndicator.Text = this.title + " has placed $" + Amount + " on Athlete #" + BidAthlete;
                this.ActivityLabelUpdator();
                return true;
            }
            else
            {
                MessageBox.Show(this.title + " doesn't have enough money to cover for the bet!");
                this.ExistingBet = null;
                return false;
            }
        }

        public void CollectWinnings(int WinningGambler)
        {
            if (this.ExistingBet != null)
            {
                PocketCash += ExistingBet.CashOut(WinningGambler);
                ResetBettingHistory();
                ActivityLabelUpdator();
            }
        }
    }
}
