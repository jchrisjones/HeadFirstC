using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_05_Cow_Calculator
{
    class Farmer
    {
        private int numberOfCows;
        public int BagsOfFeed { get; private set; }
        private int feedMultiplier = 30;

        public int FeedMultiplier 
        {
            get { return feedMultiplier; } 
            private set { feedMultiplier = value; } 
        }

        public int NumberOfCows 
        {
            get { return numberOfCows; }            
            set
            {
                numberOfCows = value;
                BagsOfFeed = numberOfCows * FeedMultiplier;
            }
        }

        public Farmer(int numberOfCows, int feedMultiplier)
        {
            FeedMultiplier = feedMultiplier;
            NumberOfCows = numberOfCows;            
        }
    }
}
