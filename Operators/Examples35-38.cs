using System;
using System.Linq;

namespace Operators
{
    class Examples35_38
    {
        public static void SingleOperator()
        {
            //Listing 10-35
            var q = from course in Course.Catalog
                where course.Category == "MAT" && course.Number == 101
                select course;

            Course geometry = q.Single();
            Console.WriteLine(geometry.Title);
        }

        public static void SingleWithPredicate()
        {
            //Listing 10-36
            Course geometry = Course.Catalog.Single(course => course.Category == "MAT" && course.Number == 101);
            Console.WriteLine(geometry.Title);
        }

        public static void SelectFirstFromOrderedCollection()
        {
            //Listing 10-37
            var q = from course in Course.Catalog
                orderby course.Duration descending
                select course;
            Course longest = q.First();
            Course najkrotszy = q.Last();
            Console.WriteLine(longest.Title);
            Console.WriteLine(najkrotszy.Title);
        }

        public static void UsingElementAtTheSlowWay()
        {
            //Listing 10-38
            var mathCourse = Course.Catalog.Where(c => c.Category == "MAT");
            for (int i = 0; i < mathCourse.Count(); ++i)
            {
                //Nigdy nie należy tego robić
                Course c = mathCourse.ElementAt(i);
                Console.WriteLine(c.Title);
            }
            //Uwaga: tutaj nie dzieje się nic strasznego, gdyż operujemy na
            //niewielkiej liczbie danych. To na wypadek, gdybyś się zastanawiał,
            //dlaczego przykład nie dziala wolno.
        }
    }
}
