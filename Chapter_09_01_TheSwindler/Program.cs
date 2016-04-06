using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_09_01_TheSwindler
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("secret_plan.txt");
            sw.WriteLine("How I'll defeat Captain Amazing");
            sw.WriteLine("Another genius secret plan by The Swindler");
            sw.Write("I'll create an army of clones and ");
            sw.WriteLine("unleash them upon the xitezens of Objectville.");
            string location = "the mall";
            for(int number = 0; number <= 6; number++)
            {
                sw.WriteLine("Conle #{0} attacks {1}", number, location);
                if (location == "the mall")
                    location = "downtown";
                else
                    location = "the mall";
            }
            sw.Close();
            sw.Dispose();
        }
    }
}
