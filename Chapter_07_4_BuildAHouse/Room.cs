using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_07_5_HideAndSeek
{
    class Room : Location
    {
        //========= Fields ========//
        private string _decoration;

        //======== Constructor ====//
        public Room(string name, string decoration) : base(name)
        {
            Decoration = decoration;
        }

        //======== Properties ======//

        public string Decoration
        {
            get { return _decoration;  }
            private set { _decoration = value; }
        }

        public override string Description
        {
            get
            {
                return base.Description + " You see the " + Decoration +".";
            }
        }
    }
}
