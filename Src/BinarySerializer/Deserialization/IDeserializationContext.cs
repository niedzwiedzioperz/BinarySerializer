using System;

namespace BinarySerializer.Deserialization
{
    public interface IDeserializationContext
    {
        IReader Reader { get; }

        object Read(Type objectType);
    }
}
