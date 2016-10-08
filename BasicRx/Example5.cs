using System;
using System.IO;

namespace BasicRx
{
    //Listing 11-5
    public class FilePusher : IObservable<string>
    {
        private string _path;

        public FilePusher(string path)
        {
            _path = path;
        }

        public IDisposable Subscribe(IObserver<string> observer)
        {
            using (var sr = new StreamReader(_path))
            {
                while (!sr.EndOfStream)
                {
                    observer.OnNext(sr.ReadLine());
                }
            }
            observer.OnCompleted();
            return EmptyDisposable.Instance;
        }

        private class EmptyDisposable : IDisposable
        {
            public static EmptyDisposable Instance = new EmptyDisposable();
            public void Dispose() { }
        }
    }
    class Example5
    {
        public static void UseFilePusher()
        {
            var source = new FilePusher(@"..\..\Program.cs");
            var subscriber = new MySubscriber<string>();
            source.Subscribe(subscriber);
        }
    }
}
