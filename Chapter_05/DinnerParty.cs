using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter_05
{    
    class DinnerParty
    {
        public int NumberOfPeople { get; set; }
        public bool FancyDecorations { get; set; }
        public bool HealthyOption { get; set; }
        public decimal Cost
        {
            get
            {
                decimal totalCost = 0.00M;
                totalCost += this.CalculateCostOfDecorations() +
                             (this.CalculateCostOfBeveragesPerPerson() * NumberOfPeople);
                if (HealthyOption)
                    totalCost *= 0.95M;

                return totalCost;
            }
        }
        
        public DinnerParty(int numberOfPeople, bool healthyOption,
                            bool fancyDecorations)
        {
            this.NumberOfPeople = numberOfPeople;
            this.HealthyOption = healthyOption;
            this.FancyDecorations = fancyDecorations;
        }

        private decimal CalculateCostOfDecorations()
        {
            decimal costOfDecorations = 0.00M;
            if (this.FancyDecorations)
                return costOfDecorations = (15.00M * NumberOfPeople) + 50.00M;
            else
                return costOfDecorations = (7.50M * NumberOfPeople) + 30.00M;
        }

        private decimal CalculateCostOfBeveragesPerPerson()
        {           
            if (HealthyOption)
                return 5.00M;
            else
                return 20.00M;
        }        
    }
}
