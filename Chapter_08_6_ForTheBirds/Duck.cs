using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_08_6_ForTheBirds
{
    class Duck : Bird, IComparable<Duck>
    {
        //========== Fields ===========//
        public int Size;
        public KindOfDuck Kind;

        //======== Constructors =======//

        //======== Interfaces =========//
        public int CompareTo(Duck duckToCompare)
        {
            if (this.Size > duckToCompare.Size)
                return 1;
            else if (this.Size < duckToCompare.Size)
                return -1;
            else
                return 0;
        }

        //======== Properties =========//

        //========== Methods ==========//

        public override string ToString()
        {            
            return "A " + Size + " inch " + Kind.ToString();
        }
        
    }
}
