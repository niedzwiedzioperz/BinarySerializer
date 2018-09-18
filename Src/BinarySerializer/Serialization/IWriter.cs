using System;

namespace BinarySerializer.Serialization
{
    public interface IWriter
    {
        void Write(char? value);
        void Write(char value);
        void Write(Guid? value);
        void Write(Guid value);
        void Write(DateTime? value);
        void Write(DateTime value);
        void Write(string value);
        void Write(decimal? value);
        void Write(decimal value);
        void Write(double? value);
        void Write(double value);
        void Write(float? value);
        void Write(float value);
        void Write(long? value);
        void Write(long value);
        void Write(int? value);
        void Write(int value);
        void Write(short? value);
        void Write(short value);
        void Write(byte? value);
        void Write(byte value);
        void Write(bool? value);
        void Write(bool value);
    }
}
