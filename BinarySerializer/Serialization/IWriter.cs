using System.IO;

namespace BinarySerializer.Serialization
{
    public interface IWriter
    {
        BinaryWriter Writer { get; }

        void Write(object @object);
    }
}
