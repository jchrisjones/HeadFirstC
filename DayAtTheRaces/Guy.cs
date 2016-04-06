using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayAtTheRaces
{
    public class Guy
    {
        public string Name; // The guy's name
        public Bet MyBet;  // An instance of Bet that has his bet
        public int Cash;  // How much cash he has

        public RadioButton MyRadioButton; // my RadioButton
        public Label MyLabel; // my Label

        public Guy() { }

        public Guy(string name, int cash, RadioButton rButton, Label label)
        {
            this.Name = name;
            this.Cash = cash;
            this.MyRadioButton = rButton;           
            this.MyLabel = label;
            this.UpdateLabels();
        }
        public void UpdateLabels()
        {
            // Set my label to my bet's description, and label on my
            // radio button to show my cash ("Joe has 43 bucks")
            this.MyRadioButton.Text = Name + " has " + Cash + " bucks";
            if (MyBet != null)
                MyLabel.Text = this.Name + " bets " + this.MyBet.Amount + 
                                           " bucks on dog #" + this.MyBet.Dog;
            else
                MyLabel.Text = this.Name + " hasn't placed a bet";

        }

        public void ClearBet()
        {
            this.MyBet = null;
        }

        public bool PlaceBet(int AmountToBet, int Winner)
        {
            if (this.MyBet == null)
            {
                if (AmountToBet <= Cash)
                {
                    this.MyBet = new Bet(AmountToBet, Winner, this);
                    this.Cash -= AmountToBet;
                    this.UpdateLabels();
                    return true;
                }
                else
                    MessageBox.Show(this.Name + " doesn't have enough cash to make this bet.");
                    this.UpdateLabels();
                    return false;
            }
            else
            {

                if (AmountToBet <= Cash + this.MyBet.Amount)
                {
                    this.Cash += this.MyBet.Amount;
                    this.MyBet = new Bet(AmountToBet, Winner, this);
                    this.Cash -= AmountToBet;
                    this.UpdateLabels();
                    return true;
                }
                else
                    MessageBox.Show(this.Name + " doesn't have enough cash to make this bet.");
                    this.UpdateLabels();
                return false;

            }           
        }

        public void Collect(int Winner)
        {
            // Ask my bet to pay out, clear my bet, and update my labels
            this.Cash += this.MyBet.PayOut(Winner);
            this.ClearBet();
            this.UpdateLabels();
        }
    }
}
