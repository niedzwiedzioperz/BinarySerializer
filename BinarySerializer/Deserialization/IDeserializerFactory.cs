using System;

namespace BinarySerializer.Deserialization
{
    public interface IDeserializerFactory
    {
        ObjectDeserializer Create(Type objectType, IDeserializationContext context);
    }
}
