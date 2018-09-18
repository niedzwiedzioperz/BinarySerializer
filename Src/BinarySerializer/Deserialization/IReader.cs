using System;
using System.IO;

namespace BinarySerializer.Deserialization
{
    public interface IReader
    {
        BinaryReader Reader { get; }

        object Read(Type objectType);
    }
}
