using System;
using System.Security.Cryptography;

namespace QueryExpression
{
    //Listing 8-10
    public class SillyLinqProvider
    {
        public SillyLinqProvider Where(Func<string, int> pred)
        {
            Console.WriteLine("Wywołano metodę Where.");
            return this;
        }

        public string Select<T>(Func<DateTime, T> map)
        {
            Console.WriteLine("Wywołano metodę Select, argumentem typu jest: " + typeof(T));
            return "Ten operator jest całkowicie bezsensowny!";
        }
    }

    class Examples8_10
    {
        public static void QuerySillyProvider()
        {
            //Listing 9-10
            var q = from x in new SillyLinqProvider()
                where int.Parse(x)
                select x.Hour;

            //PonieważSillyLinqProvider.Select zwraca string
            //to właśnie łańcuch znaków będzie wynikiem zapytania,
            //a nie coś czego zawartość można przejrzeć używając iteracji.
            Console.WriteLine(q);
        }

        public static void ExpandedSillyQuery()
        {
            //Listing 10-10
            var q = new SillyLinqProvider().Where(int.Parse).Select(x => x.Hour);
            Console.WriteLine(q);
        }
    }
}
