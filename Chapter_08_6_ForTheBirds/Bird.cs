using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter_08_6_ForTheBirds
{
    class Bird
    {
        public string Name { get; set; }

        public virtual void Fly()
        {
            Console.WriteLine("Flap, flap");
        }

        public override string ToString()
        {
            return "A bird named " + Name;
        }
    }
}
