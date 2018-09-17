namespace BinarySerializer.Tests
{
    public class SingleValue<TValue>
    {
        public SingleValue()
        { }

        public SingleValue(TValue value)
        {
            Value = value;
        }

        public TValue Value { get; set; }
    }
}
