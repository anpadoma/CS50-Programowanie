using System;

namespace Chapter06
{
    public class BaseInit
    {
        protected static int Init(string message)
        {
            Console.WriteLine(message);
            return 1;
        }

        private int b1 = Init("Pole b1 klasy bazowej.");

        public BaseInit()
        {
            Init("Konstruktor klasy bazowej.");
        }

        private int b2 = Init("Pole b2 klasy bazowej.");
    }

    public class DerivedInit : BaseInit
    {
        private int d1 = Init("Pole d1 klasy pochodnej.");

        public DerivedInit()
        {
            Init("Konstruktor klasy pochodnej.");
        }

        private int d2 = Init("Pole d2 klasy pochodnej.");
    }
}
