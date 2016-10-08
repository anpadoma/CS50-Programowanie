using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter05
{
    class Examples22_23
    {
        public static void UsingAList()
        {
            //Listing 5-22
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
        }

        public static void ListInitializer()
        {
            //Listing 5-23
            var numbers = new List<int> {123, 99, 42};
            Console.WriteLine("{0}, {1}, {2}", numbers[0], numbers[1], numbers[2]);
        }
    }
}
