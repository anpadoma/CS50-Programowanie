using System.Collections.Generic;
using System.Linq;

namespace Operators
{
    class Examples20_25
    {
        public static void IndexedSelect()
        {
            //Listing 10-20
            IEnumerable<string> nonIntro =
                Course.Catalog.Select((course, index) => string.Format("Kurs {0}: {1}", index + 1, course.Title));
            nonIntro.Show();
        }

        public static void IndexedSelectAfterWhere()
        {
            //Listing 10-21
            IEnumerable<string> nonintro = Course.Catalog
                .Where(c => c.Number >= 200)
                .Select((course, index) => string.Format("Kurs {0}: {1}", index + 1, course.Title));
            nonintro.Show();
        }

        public static void IndexedSelectBeforeWhere()
        {
            //Listing 10-22
            IEnumerable<string> nonintro = Course.Catalog
                .Select((course, index) => new {course, index})
                .Where(vars => vars.course.Number >= 200)
                .Select(vars => string.Format("Kurs {0}: {1}", vars.index + 1, vars.course.Title));
            nonintro.Show();
        }

        public static void MappingItems()
        {
            //Listing 10-25
            int[] numbers = {0, 1, 2, 3, 4, 5};

            IEnumerable<int> doubled = numbers.Select(x => 2*x);
            IEnumerable<int> squared = numbers.Select(x => x*x);
            IEnumerable<string> numberText = numbers.Select(x => x.ToString());

            doubled.Show();
            squared.Show();
            numberText.Show();
        }
    }
}
