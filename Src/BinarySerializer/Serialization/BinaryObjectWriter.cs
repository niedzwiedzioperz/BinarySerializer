using System;
using System.IO;

namespace BinarySerializer.Serialization
{
    public class BinaryObjectWriter : IWriter
    {
        private readonly BinaryWriter _writer;

        public BinaryObjectWriter(
            BinaryWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            _writer = writer;
        }

        #region IWriter

        public void Write(char? value)
        {
            Write(value.HasValue);
            if (value.HasValue)
                Write(value.Value);
        }

        public void Write(char value)
            => _writer.Write(value);

        public void Write(Guid? value)
        {
            Write(value.HasValue);
            if (value.HasValue)
                Write(value.Value);
        }

        public void Write(Guid value)
            => WriteBytes(value.ToByteArray());

        public void Write(DateTime? value)
        {
            Write(value.HasValue);
            if (value.HasValue)
                Write(value.Value);
        }

        public void Write(DateTime value)
            => _writer.Write(value.Ticks);

        public void Write(string value)
        {
            Write(value != null);
            if (value != null)
                Write(value);
        }

        public void Write(decimal? value)
        {
            Write(value.HasValue);
            if (value.HasValue)
                Write(value.Value);
        }

        public void Write(decimal value)
            => _writer.Write(value);

        public void Write(double? value)
        {
            Write(value.HasValue);
            if (value.HasValue)
                Write(value.Value);
        }

        public void Write(double value)
            => _writer.Write(value);

        public void Write(float? value)
        {
            Write(value.HasValue);
            if (value.HasValue)
                Write(value.Value);
        }

        public void Write(float value)
            => _writer.Write(value);

        public void Write(long? value)
        {
            Write(value.HasValue);
            if (value.HasValue)
                Write(value.Value);
        }

        public void Write(long value)
            => _writer.Write(value);

        public void Write(int? value)
        {
            Write(value.HasValue);
            if (value.HasValue)
                Write(value.Value);
        }

        public void Write(int value)
            => _writer.Write(value);

        public void Write(short? value)
        {
            Write(value.HasValue);
            if (value.HasValue)
                Write(value.Value);
        }

        public void Write(short value)
            => _writer.Write(value);

        public void Write(byte? value)
        {
            Write(value.HasValue);
            if (value.HasValue)
                Write(value.Value);
        }

        public void Write(byte value)
            => _writer.Write(value);

        public void Write(bool? value)
        {
            Write(value.HasValue);
            if (value.HasValue)
                Write(value.Value);
        }

        public void Write(bool value)
            => _writer.Write(value);

        #endregion

        private void WriteBytes(byte[] bytes)
            => _writer.Write(bytes, 0, bytes.Length);
    }
}
