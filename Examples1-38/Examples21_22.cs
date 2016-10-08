using System;

namespace Delegates
{
    //Kod umieszczony w komentarzu gdyż pokazuje skladowe delegatów. 
    //Nie jest przeznaczony do kompilacji
    //Listing 9-21
    //public Predicate(object target, IntPtr method);
    //public bool Invoke(T obj);
    //public IAsyncResult BeginInvoke(T obj, AsyncCallback callback, object state);
    //public bool EndInvoke(IAsyncInvoke result);

    class Examples21_22
    {
        //Listing 9-22
        public static void CallMeRightBack(Predicate<int> userCallback)
        {
            bool result = userCallback.Invoke(42);
            Console.WriteLine(result);
        }

        public static void DirectCall()
        {
            CallMeRightBack(x => x == 42);
        }
    }
}
