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
    }
}
