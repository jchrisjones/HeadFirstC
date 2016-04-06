using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_8_10_Breakfast4Lumberjacks
{
    class Lumberjack
    {
        //========== Fields ===========//

        private string _name;
        private Stack<Flapjack> _meal;

        //======== Constructors =======//
        /// <summary>
        ///     <para>Create a new Lumberjack passing in his (or her) name</para>
        /// </summary>
        /// <param name="name"></param>
        public Lumberjack(string name)
        {
            _name = name;
            _meal = new Stack<Flapjack>();
        }

        //======== Interfaces =========//

        //======== Properties =========//

        public string Name { get { return _name; } }
        public int FlapjackCount { get { return _meal.Count; } }

        //========== Methods ==========//

        public void TakeFlapjacks(Flapjack food, int howMany)
        {
            for (int i = 0; i < howMany; i++)
                _meal.Push(food);
        }

        public void EatFlapjacks()
        {
            Console.WriteLine(Name + "'s eating flapjacks");
            while(_meal.Count > 0)
            {
                Console.WriteLine(Name + " at a " + _meal.Pop().ToString().ToLower() + " flapjack");
            }
        }
    }
}
