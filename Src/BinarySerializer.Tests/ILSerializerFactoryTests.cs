using BinarySerializer.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BinarySerializer.Tests
{
    [TestClass]
    public class ILSerializerFactoryTests
    {
        [TestMethod]
        public void WriteBool_Test()
        {
            var value = true;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteNullableBool_Test()
        {
            var value = (bool?)false;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteByte_Test()
        {
            var value = (byte)122;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteNullableByte_Test()
        {
            var value = (byte?)122;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteShort_Test()
        {
            var value = (short)122;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteNullableShort_Test()
        {
            var value = (short?)122;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteInt_Test()
        {
            var value = 4545;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteNullableInt_Test()
        {
            var value = (int?)4545;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteLong_Test()
        {
            var value = (long)122;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteNullableLong_Test()
        {
            var value = (long?)122;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteChar_Test()
        {
            var value = 'c';
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteNullableChar_Test()
        {
            var value = (char?)'c';
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteFloat_Test()
        {
            var value = (float)122;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteNullableFloat_Test()
        {
            var value = (float?)122;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteDouble_Test()
        {
            var value = (double)122;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteNullableDouble_Test()
        {
            var value = (double?)122;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteDecimal_Test()
        {
            var value = (decimal)122;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteNullableDecimal_Test()
        {
            var value = (decimal?)122;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteString_Test()
        {
            var value = "some text";
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteGuid_Test()
        {
            var value = Guid.NewGuid();
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteNullableGuid_Test()
        {
            var value = (Guid?)Guid.NewGuid();
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteDateTime_Test()
        {
            var value = DateTime.Now;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteNullableDateTime_Test()
        {
            var value = (DateTime?)DateTime.Now;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(value));
        }

        [TestMethod]
        public void WriteByteEnum_Test()
        {
            var value = ByteEnum.Value;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write((byte)value));
        }

        [TestMethod]
        public void WriteNullableByteEnum_Null_Test()
        {
            var value = (ByteEnum?)null;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(false));
            mock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void WriteNullableByteEnum_NotNull_Test()
        {
            var value = (ByteEnum?)ByteEnum.Value;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(true));
            mock.Verify(w => w.Write((byte)value.Value));
        }

        [TestMethod]
        public void WriteShortEnum_Test()
        {
            var value = ShortEnum.Value;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write((short)value));
        }

        [TestMethod]
        public void WriteNullableShortEnum_Null_Test()
        {
            var value = (ShortEnum?)null;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(false));
            mock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void WriteNullableShortEnum_NotNull_Test()
        {
            var value = (ShortEnum?)ShortEnum.Value;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(true));
            mock.Verify(w => w.Write((short)value.Value));
        }

        [TestMethod]
        public void WriteIntEnum_Test()
        {
            var value = IntEnum.Value;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write((int)value));
        }

        [TestMethod]
        public void WriteNullableIntEnum_Null_Test()
        {
            var value = (IntEnum?)null;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(false));
            mock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void WriteNullableIntEnum_NotNull_Test()
        {
            var value = (IntEnum?)IntEnum.Value;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(true));
            mock.Verify(w => w.Write((int)value.Value));
        }

        [TestMethod]
        public void WriteLongEnum_Test()
        {
            var value = LongEnum.Value;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write((long)value));
        }

        [TestMethod]
        public void WriteNullableLongEnum_Null_Test()
        {
            var value = (LongEnum?)null;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(false));
            mock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void WriteNullableLongEnum_NotNull_Test()
        {
            var value = (LongEnum?)LongEnum.Value;
            var mock = SingleValueTest(value);
            mock.Verify(w => w.Write(true));
            mock.Verify(w => w.Write((long)value.Value));
        }

        private Mock<IWriter> SingleValueTest<T>(T value)
        {
            var obj = new SingleValue<T>(value);
            var factory = new ILSerializerFactory();

            var ctxMock = new Mock<ISerializationContext>();
            var writerMock = new Mock<IWriter>();
            ctxMock.Setup(c => c.Writer)
               .Returns(writerMock.Object);

            var serializer = factory.Create(obj.GetType(), ctxMock.Object);
            serializer.Serialize(obj, ctxMock.Object);

            return writerMock;
        }
    }
}
