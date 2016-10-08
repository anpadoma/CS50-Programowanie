using System;
using System.IO;
using System.Reactive.Linq;

namespace BasicRx
{
    class Example10
    {
        //Listing 11-10
        public static IObservable<string> GetFilePusher(string path)
        {
            return Observable.Create<string>(async (observer, cancel) =>
            {
                using (var sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream && !cancel.IsCancellationRequested)
                    {
                        observer.OnNext(await sr.ReadLineAsync());
                    }
                }
                observer.OnCompleted();
                return () => { };
            });
        }

        public static void UseFilePusher()
        {
            var source = GetFilePusher(@"..\..\Program.cs");
            var subscriber = new MySubscriber<string>();
            source.Subscribe(subscriber);
        }
    }
}
