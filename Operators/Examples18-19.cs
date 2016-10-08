using System;
using System.Collections.Generic;
using System.Linq;

namespace Operators
{
    class Examples18_19
    {
        public static void IndexedWhere()
        {
            //Listing 10-18
            IEnumerable<Course> q = Course.Catalog.Where(
                (course, index) => (index%2 == 0) && course.Duration.TotalHours >= 3);
            q.Show();
        }

        //Listing 10-19
        static void ShowAllStrings(IEnumerable<object> src)
        {
            var strings = src.OfType<string>();
            foreach (string s in strings)
            {
                Console.WriteLine(s);
            }
        }

        public static void UseOfType()
        {
            ShowAllStrings(new Object[] { 42, "42", "Witaj, świecie", null, (42).ToString()});
        }
    }
}
