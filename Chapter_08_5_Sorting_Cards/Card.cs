using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_08_5_Sorting_Cards
{
    class Card
    {
        //========== Fields ===========//

        private Suit _suit;
        private Values _value;
        //======== Constructors =======//
        public Card (Suit suit, Values value)
        {
            _suit = suit;
            _value = value;
        }
        //======== Interfaces =========//

        //======== Properties =========//
        public Suit Suit { get { return _suit; } }
        public Values Value { get { return _value; } }
        public string Name { get { return Value.ToString() + " of " + Suit.ToString(); } }

        //========== Methods ==========//

        public override string ToString()
        {
            return Name;
        }
    }
}
