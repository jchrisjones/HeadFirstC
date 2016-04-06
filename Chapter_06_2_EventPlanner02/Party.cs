using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_06_EventPlanner
{
    class Party
    {
        //============ Fields ================//

        public const int CostOfFoodPerPerson = 25;

        //============ Properties ============//
        public int NumberOfPeople { get; set; }
        public bool FancyDecorations { get; set; }
        virtual public decimal Cost 
        {
            get
            {
                decimal totalCost = CalculateCostOfDecorations();
                totalCost += CostOfFoodPerPerson * NumberOfPeople;

                if (NumberOfPeople > 12)
                    totalCost += 100;

                return totalCost;
            }
        }

        private decimal CalculateCostOfDecorations()
        {
            decimal costOfDecorations;
            if (FancyDecorations)
                costOfDecorations = (NumberOfPeople * 15.00M) + 50M;
            else
                costOfDecorations = (NumberOfPeople * 7.50M) + 30M;
            return costOfDecorations;
        }
    }
}
