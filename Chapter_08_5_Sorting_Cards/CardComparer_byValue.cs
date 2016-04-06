using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter_08_5_Sorting_Cards
{
    class CardComparer_byValue : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            if (x.Value > y.Value)
                return 1;
            if (x.Value < y.Value)
                return -1;
            if (x.Suit > y.Suit)
                return 1;
            if (x.Suit < y.Suit)
                return -1;

            return 0;
        }
    }
}
