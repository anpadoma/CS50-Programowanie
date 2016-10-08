using System.Linq;
using System.Security.Cryptography;

namespace Operators
{
    class Examples31_34
    {
        public static void OrderByQueryExpression()
        {
            //Listing 10-31
            var q = from course in Course.Catalog
                orderby course.PublicationDate ascending
                select course;

            q.Show();
        }

        public static void BadMultipleOrdering()
        {
            //Listing 10-32
            var q = from course in Course.Catalog
                orderby course.PublicationDate ascending
                orderby course.Duration descending //Błąd może spowodować utratę wcześniejszej kolejności
                select course;

            q.Show();
        }

        public static void MultipleOrderingQueryEspression()
        {
            //Listing 10-33
            var q = from course in Course.Catalog
                orderby course.PublicationDate ascending, course.Duration descending
                select course;

            q.Show();
        }

        public static void MultipleOrderingdirect()
        {
            //Listing 10-34
            var q = Course.Catalog
                .OrderBy(course => course.PublicationDate)
                .ThenByDescending(course => course.Duration);

            q.Show();
        }
    }
}
