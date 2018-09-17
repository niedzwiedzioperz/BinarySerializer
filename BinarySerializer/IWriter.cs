using System.IO;

namespace BinarySerializer
{
    public interface IWriter
    {
        BinaryWriter Writer { get; }

        void Write(object @object);
    }
}
