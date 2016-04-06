using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_07_5_HideAndSeek
{
    class RoomWithDoor : RoomWithHidingPlace, IHasExteriorDoor
    {
        //========== Fields ===========//

        //======== Constructors =======//
        public RoomWithDoor(string name, string decoration, string hidingPlace, string doorDescription)
            : base(name, decoration, hidingPlace)
        {
            DoorDescription = doorDescription;            
        }

        //======== Properties =========//
        public string DoorDescription { get; private set; }

        public Location DoorLocation { get; set; }

        //========== Methods ==========//
       
    }
}
