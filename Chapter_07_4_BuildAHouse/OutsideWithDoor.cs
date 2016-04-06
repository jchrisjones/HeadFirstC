using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_07_5_HideAndSeek
{
    class OutsideWithDoor : Outside, IHasExteriorDoor
    {
        //========== Fields ===========//

        //======== Constructors =======//

        public OutsideWithDoor(string name, bool hot, string doorDescription) 
            : base(name, hot)
        {
            this.DoorDescription = doorDescription;            
        }

        //======== Properties =========//

        public string DoorDescription { get; private set; }

        public Location DoorLocation { get; set; }

        public override string Description
        {
            get
            {
                return base.Description + " You see the " + DoorDescription + ".";
            }
        }
            

        //========== Methods ==========//
       
    }
}
