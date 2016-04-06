using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_06_EventPlanner
{
    class BirthdayParty : Party 
    {
        //============= Fields ================//

            

        //============= Constructors ==========//

        public BirthdayParty(int numberOfPeople, bool fancyDecorations,
                             string cakeWriting)
        {
            NumberOfPeople = numberOfPeople;
            FancyDecorations = fancyDecorations;
            CakeWriting = cakeWriting;
        }

        //============= Properties =============//       
                

        public bool FancyDecorations { get; set; }

        public string CakeWriting { get; set; }

        public bool CakeWritingTooLong
        {
            get
            {
                if (CakeWriting.Length > MaxWritingLength())
                    return true;
                else
                    return false;
            }
        }

        override public decimal Cost
        { 
            get
            {
                decimal totalCost = base.Cost;               
                decimal cakeCost;
                if (CakeSize() == 8)
                    cakeCost = 40M + ActualLength * .25M;
                else
                    cakeCost = 75M + ActualLength * .25M;
              
                return totalCost + cakeCost;
            }
        }

        private int ActualLength
        {
            get
            {
                if (CakeWriting.Length > MaxWritingLength())
                    return MaxWritingLength();
                else
                    return CakeWriting.Length;
            }
        }        

        //=========== Methods =============//

        private int MaxWritingLength()
        {
            if (CakeSize() == 8)
                return 16;
            else
                return 40;
        }

        private int CakeSize()
        {
            if (NumberOfPeople <= 4)
                return 8;
            else
                return 16; 
        }

        
    }
}
