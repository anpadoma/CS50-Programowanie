//Przykład jest umieszczony w innej przestrzeni nazw niż pozostałe przykłady
//należące do tego samego projektu, ponieważ ma jedynie pokazywać jak powinny
//wyglądać rzeczywiste interfejsy. Nie używamy tej definicji - używamy rzeczywistych
//typów z biblioteki klas.

using System;

namespace BasicRx.ForIllustrationOnly
{
    //Listing 11-1
    public interface IObservable<out T>
    {
        IDisposable Subscribe(IObserver<T> observer);
    }

    public interface IObserver<in T>
    {
        void OnCompleted();
        void OnError(Exception error);
        void OnNext(T value);
    }
}
