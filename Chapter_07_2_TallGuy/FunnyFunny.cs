using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_07_2_TallGuy
{
    class FunnyFunny : IClown
    {
        protected string _funnyThingIHave = "";

        public FunnyFunny(string funnyThingIHave) { _funnyThingIHave = funnyThingIHave; }

        public string FunnyThingIHave
        {
            get { return "Hi Kids! I have a " + _funnyThingIHave; }
        }

        public void Honk()
        {
            Console.WriteLine(this.FunnyThingIHave);
        }
    }
}
