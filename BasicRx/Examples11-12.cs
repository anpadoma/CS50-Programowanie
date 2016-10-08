using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace BasicRx
{
    class Examples11_12
    {
        public static void DelegateBasedHotSourceIndefinite()
        {
            //Listing 11-11
            IObservable<char> singularHotSource = Observable.Create((Func<IObserver<char>, IDisposable>) (obs =>
            {
                while (true)
                {
                    obs.OnNext(Console.ReadKey(true).KeyChar);
                }
            }));

            IConnectableObservable<char> keySource = singularHotSource.Publish();

            keySource.Subscribe(new MySubscriber<char>());
            keySource.Subscribe(new MySubscriber<char>());

            keySource.Connect();
        }

        public static void DelegateBasedSubscriptionIndefinite()
        {
            //Listing 11-12
            var source = new KeyWatcher();
            source.Subscribe(value => Console.WriteLine("Odebrana wartość: " + value));
            source.Run();
        }
    }
}
