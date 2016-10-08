namespace Chapter05
{
    public class TypyOgolne1<T>
    {
        public T Item { get; set; }
    }

    public class GenericBase2<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }

    public class NonGenericDerived : TypyOgolne1<string>
    {
        
    }

    public class GenericDerived<T> : TypyOgolne1<T>
    {
        
    }

    public class MixedDerived<T> : GenericBase2<string, T>
    {
        
    }
}
