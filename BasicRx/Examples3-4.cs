using System;

namespace BasicRx
{
    //Listing 11-3
    public class SimpleColdSource : IObservable<string>
    {
        public IDisposable Subscribe(IObserver<string> observer)
        {
            observer.OnNext("Witaj, ");
            observer.OnNext("świecie!");
            observer.OnCompleted();
            return EmptyDisposable.Instance;
        }

        private class EmptyDisposable : IDisposable
        {
             public static EmptyDisposable Instance = new EmptyDisposable();
             public void Dispose() { }
        }
    }

    public class Example4
    {
        public static void AttachObserverToObservable()
        {
            //Listing 11-4
            var sub = new MySubscriber<string>();
            var source = new SimpleColdSource();
            source.Subscribe(sub);
        }
    }
}
