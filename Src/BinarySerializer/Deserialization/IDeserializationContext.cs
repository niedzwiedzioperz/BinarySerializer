namespace BinarySerializer.Deserialization
{
    public interface IDeserializationContext
    {
        IReader Reader { get; }
    }
}
