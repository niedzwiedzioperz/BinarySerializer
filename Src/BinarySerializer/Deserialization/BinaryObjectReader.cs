using System;
using System.IO;

namespace BinarySerializer.Deserialization
{
    public class BinaryObjectReader : IReader
    {
        private const int GuidBytesCount = 16;

        private readonly BinaryReader _reader;

        public BinaryObjectReader(
            BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            _reader = reader;
        }

        #region IReader

        public bool ReadBool()
            => _reader.ReadBoolean();

        public byte ReadByte()
            => _reader.ReadByte();

        public char ReadChar()
            => _reader.ReadChar();

        public DateTime ReadDateTime()
        {
            var ticks = ReadLong();
            return new DateTime(ticks);
        }

        public decimal ReadDecimal()
            => _reader.ReadDecimal();

        public double ReadDouble()
            => _reader.ReadDouble();

        public float ReadFloat()
            => _reader.ReadSingle();

        public Guid ReadGuid()
        {
            var bytes = _reader.ReadBytes(GuidBytesCount);
            return new Guid(bytes);
        }

        public int ReadInt()
            => _reader.ReadInt32();

        public long ReadLong()
            => _reader.ReadInt64();

        public bool? ReadNullableBool()
            => ReadBool() ? ReadBool() : (bool?)null;

        public byte? ReadNullableByte()
            => ReadBool() ? ReadByte() : (byte?)null;

        public char? ReadNullableChar()
            => ReadBool() ? ReadChar() : (char?)null;

        public DateTime? ReadNullableDateTime()
            => ReadBool() ? ReadDateTime() : (DateTime?)null;

        public decimal? ReadNullableDecimal()
            => ReadBool() ? ReadDecimal() : (decimal?)null;

        public double? ReadNullableDouble()
            => ReadBool() ? ReadDouble() : (double?)null;

        public float? ReadNullableFloat()
            => ReadBool() ? ReadFloat() : (float?)null;

        public Guid? ReadNullableGuid()
            => ReadBool() ? ReadGuid() : (Guid?)null;

        public int? ReadNullableInt()
            => ReadBool() ? ReadInt() : (int?)null;

        public long? ReadNullableLong()
            => ReadBool() ? ReadLong() : (long?)null;

        public short? ReadNullableShort()
            => ReadBool() ? ReadShort() : (short?)null;

        public short ReadShort()
            => _reader.ReadInt16();

        public string ReadString()
            => ReadBool() ? _reader.ReadString() : null;

        #endregion
    }
}
