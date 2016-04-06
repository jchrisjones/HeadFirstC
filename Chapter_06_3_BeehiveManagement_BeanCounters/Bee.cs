using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_06_4_BeehiveManagement_BeanCounters
{
    class Bee
    {
        //========= Fields =======//

        public const double HoneyUnitsConsumedPerMg = .25;

        //========= Constructors ======//

        public Bee(double weightMg)
        {
            WeightMg = weightMg;
        }

        //========== Properties =======//
        public double WeightMg { get; private set; }

        //========== Methods =========//

        virtual public double HoneyConsumptionRate()
        {
            return WeightMg * HoneyUnitsConsumedPerMg;
        }

    }
}
