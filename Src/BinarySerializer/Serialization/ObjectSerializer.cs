namespace BinarySerializer.Serialization
{
    public abstract class ObjectSerializer
    {
        public abstract void Serialize(object @object, ISerializationContext context);
    }
}
