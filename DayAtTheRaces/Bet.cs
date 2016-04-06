using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayAtTheRaces
{
    public class Bet
    {
        public int Amount; // The amount of cash that was bet
        public int Dog; // the number of the dog the bet is on
        public Guy Bettor; // the guy who placed the bet

        public Bet() { }

        public Bet(int amount, int dog, Guy bettor)
        {
            Amount = amount;
            Dog = dog;
            Bettor = bettor;
        }

        public string GetDescripton()
        {
            // return a string that says who placed the bet, how much
            // cas was bet, and which dog he bet on (" Joe bets 8 on 
            // dog #4"). If the amount is zero, no bet was placed
            // ("Joe hasn't placed a bet")
            if(Amount > 0)
                return this.Bettor.Name + " bets " + this.Amount + " on dog #" + Dog;
            return this.Bettor.Name + " hasn't placed a bet";
        }

        public int PayOut(int Winner)
        {
            // The paramenter is the winner of the race. If the dog won, 
            // return the amount bet. Otherwise, return the negative of 
            // the amount bet.
            if (Winner == Dog)
                return Amount * 2;
            else
                return 0;
        }
    }
}
