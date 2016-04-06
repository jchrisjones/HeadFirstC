using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_07_5_HideAndSeek
{
    class RoomWithHidingPlace : Room, IHidingPlace
    {
        //========== Fields ===========//

        private string _hidingPlace = "";

        //======== Constructors =======//

        public RoomWithHidingPlace(string name, string decoration, string hidingPlace)
            : base(name, decoration)
        {
            HidingPlace = hidingPlace;
        }

        //======== Interfaces =========//
        public string HidingPlace
        {
            get { return _hidingPlace; }
            private set { _hidingPlace = value; }
        }

        public int HidingPlaceChecked { get; set; }

        //======== Properties =========//

        //========== Methods ==========//
        
    }
}
