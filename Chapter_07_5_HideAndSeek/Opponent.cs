using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_07_5_HideAndSeek
{
    class Opponent
    {
        //========== Fields ===========//

        private Location _myLocation;
        private Random _random;

        //======== Constructors =======//

        public Opponent(Location myLocation)
        {
            MyLocation = myLocation;
            _random = new Random();
        }
        //======== Properties =========//

        public Location MyLocation 
        { 
            get { return _myLocation; } 
            private set { _myLocation = value; } 
        }

        //========== Methods ==========//

        public void Move()
        {
            do
            {
                if (MyLocation is IHasExteriorDoor && _random.Next(2) == 1)
                {
                    MyLocation = (MyLocation as IHasExteriorDoor).DoorLocation;
                }
                MyLocation = MyLocation.Exits[_random.Next(MyLocation.Exits.Length)];

            } while (!(MyLocation is IHidingPlace));
        }

        public bool Check(Location Loc)
        {
            if( Loc == MyLocation)
                return true;

            return false;
        }
    }
}
