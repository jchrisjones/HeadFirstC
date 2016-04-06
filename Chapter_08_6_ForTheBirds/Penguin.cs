using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_08_6_ForTheBirds
{
    class Penguin : Bird
    {
        //========== Fields ===========//

        //======== Constructors =======//

        //======== Interfaces =========//

        //======== Properties =========//

        //========== Methods ==========//
        public override void Fly()
        {
            Console.WriteLine("Penguins can't fly!");
        }

        public override string ToString()
        {
            return "A pengun named " + base.Name; 
        }
    }
}
