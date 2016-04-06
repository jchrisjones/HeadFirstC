using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_07_1
{
    class Bee : IStingPatrol
    {
        public int AlertLevel { get; set; }       

        public int StingerLength { get; set; }

        public bool LookForEnemies()
        {
            return false;
        }

        public int SharpenStinger(int length)
        {
            return 7;
        }
    }
}
