using System;
using System.Collections.Generic;

namespace Chapter05
{
    class SortowanieList
    {
        public static void Listy()
        {
            var numbers = new List<int>();
            numbers.Add(123);
            numbers.Add(99);
            numbers.Add(42);
            Console.WriteLine(numbers.Count);
            Console.WriteLine("{0}, {1}, {2}", numbers[0], numbers[1], numbers[2]);

            numbers[1] += 1;
            Console.WriteLine(numbers[1]);

            numbers.RemoveAt(1);
            Console.WriteLine(numbers.Count);
            Console.WriteLine("{0}, {1}", numbers[0], numbers[1]);
            //Console.WriteLine("{0}, {1}", numbers[0], numbers[1]);

        }
    }
}
