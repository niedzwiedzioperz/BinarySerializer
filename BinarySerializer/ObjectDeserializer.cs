namespace BinarySerializer
{
    public abstract class ObjectDeserializer
    {
        public abstract object Deserialize(IDeserializationContext context);
    }
}
