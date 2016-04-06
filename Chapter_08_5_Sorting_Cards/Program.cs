using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_08_5_Sorting_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();            
            List<Card> hand = new List<Card>();
            Console.WriteLine("Five random cards:");
            for (int i = 0; i < 5; i++)
            {
                hand.Add(new Card((Suit)rand.Next(4), (Values)rand.Next(1, 14)));
                Console.WriteLine(hand[i].Name);
            }

            Console.WriteLine();
            hand.Sort(new CardComparer_byValue());

            Console.WriteLine("Those same cards, sorted:");
            foreach (Card card in hand)
                Console.WriteLine(card.Name);

        }
        
    }
}
