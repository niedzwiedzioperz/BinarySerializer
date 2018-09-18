namespace BinarySerializer.Deserialization
{
    public abstract class ObjectDeserializer
    {
        public abstract object Deserialize(IDeserializationContext context);
    }
}
