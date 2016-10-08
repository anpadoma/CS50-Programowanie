using System;

namespace BasicRx
{
    class MySubscriber<T> : IObserver<T>
    {
        public void OnNext(T value)
        {
            Console.WriteLine("Odebrana wartość: " + value);
        }

        public void OnCompleted()
        {
            Console.WriteLine("Zakończono");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Błąd: " + error);
        }
    }
}
