namespace BinarySerializer
{
    public interface ISerializationContext
    {
        IWriter Writer { get; }
    }
}
