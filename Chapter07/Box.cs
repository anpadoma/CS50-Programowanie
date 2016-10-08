namespace Chapter07
{
    public class Box<T> where T : struct
    {
        public readonly T Value;

        public Box(T v)
        {
            Value = v;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            return Value.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
