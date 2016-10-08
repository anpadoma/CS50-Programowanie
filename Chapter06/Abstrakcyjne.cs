using System;

namespace Chapter06
{
    public abstract class AbstrakcyjneBase
    {
        public abstract void ShowMessage();
    }

    public abstract class MustBeComparable : IComparable<string>
    {
        public abstract int CompareTo(string other);
    }

    public class LibraryBase
    {
        public virtual void Start()
        {
            Console.WriteLine("Metoda klasy bazowej LibraryBase!");
        }
    }

    public class CustomerDerived : LibraryBase
    {
        public new void Start()
        {
            Console.WriteLine("Metoda Start typu pochodnego");
            base.Start();
        }
    }

    public static class AbstrakcyjneSample
    {
        public static void Sample()
        {
            var d = new CustomerDerived();
            LibraryBase b = d;
            d.Start();
            b.Start();
        }
    }
}
