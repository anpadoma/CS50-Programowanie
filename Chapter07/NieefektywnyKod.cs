using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Chapter07
{
    public class NieefektywnyKod
    {
        public static void Nieefektywny()
        {
            var sw = new Stopwatch();
            var numbers = new List<string>();
            long total = 0;
            sw.Start();
            for (int i = 1; i < 100000; ++i)
            {
                numbers.Add(i.ToString());
                total += 1;
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed.ToString("s\\.f"));
            Console.WriteLine("Suma: {0}. średnia: {1}", total, total/numbers.Count);
        }
    }
}
