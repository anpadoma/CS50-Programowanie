using System;
using System.Collections.Generic;
using System.Linq;

namespace Operators
{
    class Examples26_30
    {
        public static void SelectManyQueryExpression()
        {
            //Listing 10-26
            int[] numbers = {1, 2, 3, 4, 5};
            string[] letters = {"A", "B", "C"};

            IEnumerable<string> combined = 
                from number in numbers
                from letter in letters
                select letter + number;
            foreach (string s in combined)
            {
                Console.WriteLine(s);
            }
        }

        public static void SelectManyDirect()
        {
            int[] numbers = {1, 2, 3, 4, 5};
            string[] letters = {"A", "B", "C"};

            //Listing 10-27
            IEnumerable<string> combined = numbers.SelectMany(
                number => letters, (number, letter) => letter + number);
            combined.Show();
        }

        public static void FlattenArray()
        {
            //Listing 10-28
            int[][] arrays =
            {
                new []{1, 2},
                new []{1, 2, 3, 4, 5, 6},
                new []{1, 2, 4},
                new []{1},
                new []{1, 2, 3, 4, 5}
            };
            IEnumerable<int> combined =
                from item in arrays
                from number in item
                select number;

            combined.Show();
        }

        public static void FlattenArrayDirect()
        {
            int[][] arrays =
            {
                new []{1, 2},
                new []{1, 2, 3, 4, 5, 6},
                new []{1, 2, 4},
                new []{1},
                new []{1, 2, 3, 4, 5}
            };

            //Listing 10-29
            var combined = arrays.SelectMany(item => item);
            combined.Show();
        }
    }
}
