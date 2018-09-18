namespace BinarySerializer.Serialization
{
    public interface ISerializationContext
    {
        IWriter Writer { get; }

        void Write(object @object);
    }
}
