using System;
using System.IO;

namespace BinarySerializer
{
    public interface IReader
    {
        BinaryReader Reader { get; }

        object Read(Type objectType);
    }
}
