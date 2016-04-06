using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter_06_EventPlanner
{    
    class DinnerParty : Party
    {
        //======== Construtors ==========//
        public DinnerParty(int numberOfPeople, bool healthyOption,
                            bool fancyDecorations)
        {
            this.NumberOfPeople = numberOfPeople;
            this.HealthyOption = healthyOption;
            this.FancyDecorations = fancyDecorations;
        }

        //======== Properties ==========//

        public bool HealthyOption { get; set; }
        override public decimal Cost
        {
            get
            {
                decimal totalCost = base.Cost;
                totalCost += CalculateCostOfBeveragesPerPerson() * NumberOfPeople;
                if (HealthyOption)
                    totalCost *= 0.95M;               

                return totalCost;
            }
        }

        //======== Methods ===========//
        private decimal CalculateCostOfBeveragesPerPerson()
        {           
            if (HealthyOption)
                return 5.00M;
            else
                return 20.00M;
        }        
    }
}
