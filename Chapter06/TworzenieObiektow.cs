using System;

namespace Chapter06
{
    public class TworzenieObiektow
    {
        public TworzenieObiektow()
        {
            Console.WriteLine("Konstruktor klasy bazowej.");
        }
    }

    public class BaseNoDefaultCtor
    {
        public BaseNoDefaultCtor(int i)
        {
            Console.WriteLine("Konstruktor klasy bazowej: ", + i);
        }
    }

    public class DerivedCallingBaseCtor : BaseNoDefaultCtor
    {
        public DerivedCallingBaseCtor() : base(123)
        {
            Console.WriteLine("Konstruktor klasy pochodnej (domyślny).");
        }

        public DerivedCallingBaseCtor(int i) :base(i)
        {
            Console.WriteLine("Konstruktor klasy pochodnej: " + i);
        }
    }

    public class TwObiektów
    {
        public static void Sample()
        {
            var sim = new DerivedCallingBaseCtor();
            var sim1 = new DerivedCallingBaseCtor(123);
        }
    }
}
