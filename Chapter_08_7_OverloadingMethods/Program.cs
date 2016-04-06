using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_08_7_OverloadingMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Card cardToCheck = new Card(Suits.Clubs, Values.Three);
            bool doesItMatch = Card.DoesCardMatch(cardToCheck, Suits.Hearts);
            Console.WriteLine(doesItMatch);

            doesItMatch = Card.DoesCardMatch(cardToCheck, Values.Three);
            Console.WriteLine(doesItMatch);
        }
    }
}
