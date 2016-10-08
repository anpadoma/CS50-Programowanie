using System;

namespace Delegates
{
    class Examples15_20
    {
        //Listing 9-15
        public static bool IsLongString(object o)
        {
            var s = o as string;
            return s != null && s.Length > 20;
        }

        public static void Test()
        {
            Predicate<object> po = IsLongString;
            Predicate<string> ps = po;
            Console.WriteLine(ps("Zbyt krótki."));
        }

        //Kod w komentarzu - ilustruje błąd
        //public static CodeIdentifier IllegalConversion()
        //{
        //    //Listing 9-16
        //    Predicate<string> pred = IsLongString;
        //    Func<string, bool> f = pred;
        //}

        public static void DelegateRefToOtherDelegate()
        {
            //Listing 9-17
            Predicate<string> pred = IsLongString;
            var pred2 = new Func<string, bool>(pred);
        }

        public static void DelegateExplicitRefToOtherDelegate()
        {
            //Listing 9-18
            Predicate<string> pred = IsLongString;
            var pred2 = new Func<string, bool>(pred.Invoke);
        }

        public static void CreateNewDelegateWithSameTargetAsExist()
        {
            //Listing 9-19
            Predicate<string> pred = IsLongString;
            var pred2 =
                (Func<string, bool>) Delegate.CreateDelegate(typeof (Func<string, bool>), pred.Target, pred.Method);
        }

        public static TResult DuplicateDelegateAs<TResult>(MulticastDelegate source)
        {
            Delegate result = null;
            foreach (Delegate sourceItem in source.GetInvocationList())
            {
                var copy = Delegate.CreateDelegate(typeof (TResult), sourceItem.Target, sourceItem.Method);
                result = Delegate.Combine(result, copy);
            }

            return (TResult) (object) result;
        }
    }
}
