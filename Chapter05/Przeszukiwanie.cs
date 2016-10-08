using System;
using System.Diagnostics;

namespace Chapter05
{
    internal class Przeszukiwanie
    {
        internal static void operacje_binarysearch()
        {
            var sw = new Stopwatch();

            var big = new int[100000000];
            Console.WriteLine("Inicjalizacja danych");
            sw.Start();
            var r = new Random(0);

            for (int i = 0; i < big.Length; ++i)
            {
                big[i] = r.Next(big.Length);
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed.ToString("s\\.f"));
            Console.WriteLine();

            Console.WriteLine("Przeszukiwanie");
            for (int i = 0; i < 6; ++i)
            {
                int searchFor = r.Next(big.Length);
                sw.Reset();
                sw.Start();
                int index = Array.IndexOf(big, searchFor);
                sw.Stop();
                Console.WriteLine("Indeks: {0}", index);
                Console.WriteLine("Czas: {0:s\\.ffff}", sw.Elapsed);
            }
            Console.WriteLine();

            Console.WriteLine("Sortowanie");
            sw.Reset();
            sw.Start();
            Array.Sort(big);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.ToString("s\\.f"));
            Console.WriteLine();

            Console.WriteLine("Przeszukiwanie binarne");
            for (int i = 0; i < 6; ++i)
            {
                int searchFor = r.Next()%big.Length;
                sw.Reset();
                sw.Start();
                int index = Array.BinarySearch(big, searchFor);
                sw.Stop();
                Console.WriteLine("Indeks: {0}", index);
                Console.WriteLine("Czas: {0:s\\.fffffff}", sw.Elapsed);
            }
        }
    }
}
