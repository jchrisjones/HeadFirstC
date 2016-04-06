using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_09_03_EmailCaptAmazing
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = Application.StartupPath;
            string evilMessageFile = folder + "\\secret_plan.txt";
            string emailFile  = folder + @"\emailToCaptAmazing.txt";
            new TheSwindler(evilMessageFile);

            StreamReader reader = new StreamReader(evilMessageFile);
            StreamWriter writer = new StreamWriter(emailFile);

            writer.WriteLine("To: CaptAmazing@objectville.net");
            writer.WriteLine("From: Commissioner@objectville.net");
            writer.WriteLine("Subject: Can you save the day... again?");
            writer.WriteLine();
            writer.WriteLine("We've descovered the Swindler's plan:");
            while(!reader.EndOfStream)
            {
                string lineFromThePlan = reader.ReadLine();
                writer.WriteLine("The plan -> " + lineFromThePlan);
            }
            writer.WriteLine();
            writer.WriteLine("Can you help us?");
            writer.Close();
            writer.Dispose();
            reader.Close();
            reader.Dispose();

            File.Open(emailFile, FileMode.Open);
        }

        class TheSwindler
        {
            public TheSwindler(string filePath)
            {
                StreamWriter sw = new StreamWriter(filePath);
                sw.WriteLine("How I'll defeat Captain Amazing");
                sw.WriteLine("Another genius secret plan by The Swindler");
                sw.Write("I'll create an army of clones and ");
                sw.WriteLine("unleash them upon the citezens of Objectville.");
                string location = "the mall";
                for (int number = 0; number <= 6; number++)
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
}
