using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_08_7_OverloadingMethods
{
    class Card
    {
        //========== Fields ===========//

        //======== Constructors =======//
        public Card(Suits suit, Values value)
        {
            this.Suit = suit;
            this.Value = value;
        }

        //======== Properties =========//

        public Suits Suit { get; set; }
        public Values Value { get; set; }
        public string Name { get { return this.Value.ToString() + " of " + this.Suit.ToString(); } }

        //========== Methods ==========//

        public static bool DoesCardMatch(Card cardToCheck, Suits suit)
        {
            if (cardToCheck.Suit == suit)
                return true;
            return false;
        }

        public static bool DoesCardMatch(Card cardToCheck, Values value)
        {
            if (cardToCheck.Value == value)
                return true;
            return false;
        }
    }
}
