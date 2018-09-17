using System;

namespace BinarySerializer
{
    public interface ISerializerFactory
    {
        ObjectSerializer Create(Type objectType, ISerializationContext context);
    }
}
