using System;

namespace BinarySerializer
{
    public interface IDeserializerFactory
    {
        ObjectDeserializer Create(Type objectType, IDeserializationContext context);
    }
}
