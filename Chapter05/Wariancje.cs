using System.Collections.Generic;

namespace Chapter05
{
    public class Wariancje
    {
        public static void UseBase(Base b)
        {
            //Kowariantny parametr typu
            //public interface IEnumerable<out T> : IEnumerable
            IEnumerable<Derived> derivedBases = new[] {new Derived(), new Derived()};
            AllYourBase(derivedBases);

            //parametr T w interfejsie ICollection nie jest kowariantny
            //ICollection<Derived> derivedList = new List<Derived>();
            //AddBase(derivedList);

            Derived[] derivedBases1 = {new Derived(), new Derived()};
            UseBaseArray(derivedBases1);
        }

        private static void AllYourBase(IEnumerable<Base> bases)
        {
            
        }

        private static void AddBase(ICollection<Base> bases)
        {
            bases.Add(new Base());
        }

        private static void UseBaseArray(Base[] bases)
        {
            bases[0] = new Base();
        }

        
    }

    
    public class Base
    {
        
    }

    public class Derived : Base
    {
        
    }

    public class MoreDerived : Derived
    {
        
    }
}
