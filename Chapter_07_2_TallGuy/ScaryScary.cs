using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_07_2_TallGuy
{
    class ScaryScary : FunnyFunny, IScaryClown
    {
        private int _numberOfScaryThings = 0;

        public ScaryScary(string funnyThingIHave, int numberOfScaryThings) : 
            base(funnyThingIHave)
        {
            _numberOfScaryThings = numberOfScaryThings; 
        } 
        public string ScaryThingIHave
        {
            get { return _numberOfScaryThings + " spiders"; }
        }

        public void ScareLittleChildren()
        {
            Console.WriteLine("You can't have may "
                              + base._funnyThingIHave);
        }
    }
}
