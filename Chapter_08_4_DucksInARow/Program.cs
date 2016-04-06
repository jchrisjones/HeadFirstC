using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_08_6_ForTheBirds
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Duck> ducks = new List<Duck>()
            {
                new Duck() { Kind = KindOfDuck.Mallard, Size = 17 },
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 18 },
                new Duck() { Kind = KindOfDuck.Decoy, Size = 14 },
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 11 },
                new Duck() { Kind = KindOfDuck.Mallard, Size = 14 },
                new Duck() { Kind = KindOfDuck.Decoy, Size = 13 },               
            };
            ducks.Sort();

            DuckComparerBySize sizeComparer = new DuckComparerBySize();
            ducks.Sort(sizeComparer);
            PrintDucks(ducks);
            Console.WriteLine();

            DuckComparerByKind kindComparer = new DuckComparerByKind();
            ducks.Sort(kindComparer);
            PrintDucks(ducks);
            Console.WriteLine();

            DuckComparer comparer = new DuckComparer();

            comparer.SortBy = SortCriteria.KindThenSize;
            ducks.Sort(comparer);
            PrintDucks(ducks);
            Console.WriteLine();

            comparer.SortBy = SortCriteria.SizeThenKind;
            ducks.Sort(comparer);
            PrintDucks(ducks);

            foreach (Duck duck in ducks)
            {
                Console.WriteLine(duck);
            }

            IEnumerator<Duck> enumerator = ducks.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Duck duck = enumerator.Current;
                Console.WriteLine(duck);
            }
            IDisposable dispo = enumerator as IDisposable;
            if (dispo != null) dispo.Dispose();

            Console.ReadKey();
        }

        public static void PrintDucks(List<Duck> ducks)
        {
            foreach (Duck duck in ducks)
                Console.WriteLine(duck);
            Console.WriteLine("End of Ducks!");
        }
    }
}
