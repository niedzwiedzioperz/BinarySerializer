using System;

namespace BinarySerializer.Serialization
{
    public interface ISerializerFactory
    {
        ObjectSerializer Create(Type objectType, ISerializationContext context);
    }
}
