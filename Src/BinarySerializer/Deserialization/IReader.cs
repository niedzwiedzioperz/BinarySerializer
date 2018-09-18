using System;

namespace BinarySerializer.Deserialization
{
    public interface IReader
    {
        char? ReadNullableChar();
        char ReadChar();
        Guid? ReadNullableGuid();
        Guid ReadGuid();
        DateTime? ReadNullableDateTime();
        DateTime ReadDateTime();
        string ReadString();
        decimal? ReadNullableDecimal();
        decimal ReadDecimal();
        double? ReadNullableDouble();
        double ReadDouble();
        float? ReadNullableFloat();
        float ReadFloat();
        long? ReadNullableLong();
        long ReadLong();
        int? ReadNullableInt();
        int ReadInt();
        short? ReadNullableShort();
        short ReadShort();
        byte? ReadNullableByte();
        byte ReadByte();
        bool? ReadNullableBool();
        bool ReadBool();
    }
}
