using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_09_02_StreamWriterMagnets
{
    class Program
    {
        static void Main(string[] args)
        {                      
            Flobbo f = new Flobbo("blue yellow");
            StreamWriter sw = f.Snobbo();
            f.Blobbo(f.Blobbo(f.Blobbo(sw), sw), sw);
        }

        class Flobbo
        {
            //======== Fields =========//
            private string zap;

            //======== Constructors ===//
            public Flobbo(string zap)
            {
                this.zap = zap;
            }

            //======= Methods ======//
            public StreamWriter Snobbo()
            {
                return new StreamWriter(
                    @"C:\Users\Christopher\Documents\Visual Studio 2013\Projects\HeadFirstCSharp\Chapter_09_02_StreamWriterMagnets\bin\Debug\macaw.txt");
            }

            public bool Blobbo(StreamWriter sw)
            {
                sw.WriteLine(zap);
                zap = "green purple";
                return false;
            }

            public bool Blobbo(bool Already, StreamWriter sw)
            {
                if (Already)
                {
                    sw.WriteLine(zap);
                    sw.Close();
                    return false;
                }
                else
                {
                    sw.WriteLine(zap);
                    zap = "red orange";
                    return true;
                }
            }
        }
    }

   
}
