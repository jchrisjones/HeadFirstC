using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_07_5_HideAndSeek
{
    class OutsideWithHidingPlace : Outside, IHidingPlace
    {
        //========== Fields ===========//
        private string _hidingPlace;

        //======== Constructors =======//
        public OutsideWithHidingPlace(string name, bool hot, string hidingPlace) : base(name, hot)
        {
            HidingPlace = hidingPlace;
        }

        //======== Interfaces ========//
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
