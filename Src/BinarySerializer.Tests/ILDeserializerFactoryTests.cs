using BinarySerializer.Deserialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BinarySerializer.Tests
{
    [TestClass]
    public class ILDeserializerFactoryTests
    {
        [TestMethod]
        public void ReadBool_Test()
        {
            var value = true;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadBool()).Returns(value));
            mock.Verify(r => r.ReadBool());
        }

        [TestMethod]
        public void ReadNullableBool_Test()
        {
            var value = (bool?)false;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadNullableBool()).Returns(value));
            mock.Verify(r => r.ReadNullableBool());
        }

        [TestMethod]
        public void ReadByte_Test()
        {
            var value = (byte)122;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadByte()).Returns(value));
            mock.Verify(r => r.ReadByte());
        }

        [TestMethod]
        public void ReadNullableByte_Test()
        {
            var value = (byte?)122;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadNullableByte()).Returns(value));
            mock.Verify(r => r.ReadNullableByte());
        }

        [TestMethod]
        public void ReadShort_Test()
        {
            var value = (short)122;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadShort()).Returns(value));
            mock.Verify(r => r.ReadShort());
        }

        [TestMethod]
        public void ReadNullableShort_Test()
        {
            var value = (short?)122;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadNullableShort()).Returns(value));
            mock.Verify(r => r.ReadNullableShort());
        }

        [TestMethod]
        public void ReadInt_Test()
        {
            var value = 4545;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadInt()).Returns(value));
            mock.Verify(r => r.ReadInt());
        }

        [TestMethod]
        public void ReadNullableInt_Test()
        {
            var value = (int?)4545;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadNullableInt()).Returns(value));
            mock.Verify(r => r.ReadNullableInt());
        }

        [TestMethod]
        public void ReadLong_Test()
        {
            var value = (long)122;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadLong()).Returns(value));
            mock.Verify(r => r.ReadLong());
        }

        [TestMethod]
        public void ReadNullableLong_Test()
        {
            var value = (long?)122;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadNullableLong()).Returns(value));
            mock.Verify(r => r.ReadNullableLong());
        }

        [TestMethod]
        public void ReadChar_Test()
        {
            var value = 'c';
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadChar()).Returns(value));
            mock.Verify(r => r.ReadChar());
        }

        [TestMethod]
        public void ReadNullableChar_Test()
        {
            var value = (char?)'c';
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadNullableChar()).Returns(value));
            mock.Verify(r => r.ReadNullableChar());
        }

        [TestMethod]
        public void ReadFloat_Test()
        {
            var value = (float)122;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadFloat()).Returns(value));
            mock.Verify(r => r.ReadFloat());
        }

        [TestMethod]
        public void ReadNullableFloat_Test()
        {
            var value = (float?)122;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadNullableFloat()).Returns(value));
            mock.Verify(r => r.ReadNullableFloat());
        }

        [TestMethod]
        public void ReadDouble_Test()
        {
            var value = (double)122;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadDouble()).Returns(value));
            mock.Verify(r => r.ReadDouble());
        }

        [TestMethod]
        public void ReadNullableDouble_Test()
        {
            var value = (double?)122;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadNullableDouble()).Returns(value));
            mock.Verify(r => r.ReadNullableDouble());
        }

        [TestMethod]
        public void ReadDecimal_Test()
        {
            var value = (decimal)122;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadDecimal()).Returns(value));
            mock.Verify(r => r.ReadDecimal());
        }

        [TestMethod]
        public void ReadNullableDecimal_Test()
        {
            var value = (decimal?)122;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadNullableDecimal()).Returns(value));
            mock.Verify(r => r.ReadNullableDecimal());
        }

        [TestMethod]
        public void ReadString_Test()
        {
            var value = "some text";
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadString()).Returns(value));
            mock.Verify(r => r.ReadString());
        }

        [TestMethod]
        public void ReadGuid_Test()
        {
            var value = Guid.NewGuid();
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadGuid()).Returns(value));
            mock.Verify(r => r.ReadGuid());
        }

        [TestMethod]
        public void ReadNullableGuid_Test()
        {
            var value = (Guid?)Guid.NewGuid();
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadNullableGuid()).Returns(value));
            mock.Verify(r => r.ReadNullableGuid());
        }

        [TestMethod]
        public void ReadDateTime_Test()
        {
            var value = DateTime.Now;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadDateTime()).Returns(value));
            mock.Verify(r => r.ReadDateTime());
        }

        [TestMethod]
        public void ReadNullableDateTime_Test()
        {
            var value = (DateTime?)DateTime.Now;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadNullableDateTime()).Returns(value));
            mock.Verify(r => r.ReadNullableDateTime());
        }

        [TestMethod]
        public void ReadByteEnum_Test()
        {
            var value = ByteEnum.Value;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadByte()).Returns((byte)value));
            mock.Verify(r => r.ReadByte());
        }

        [TestMethod]
        public void ReadNullableByteEnum_Null_Test()
        {
            var value = (ByteEnum?)null;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadBool()).Returns(false));
            mock.Verify(r => r.ReadBool());
            mock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ReadNullableByteEnum_NotNull_Test()
        {
            var value = (ByteEnum?)ByteEnum.Value;
            var mock = SingleValueTest(value, m =>
            {
                m.Setup(r => r.ReadBool()).Returns(true);
                m.Setup(r => r.ReadByte()).Returns((byte)value.Value);
            });
            mock.Verify(r => r.ReadBool());
            mock.Verify(r => r.ReadByte());
        }

        [TestMethod]
        public void ReadShortEnum_Test()
        {
            var value = ShortEnum.Value;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadShort()).Returns((short)value));
            mock.Verify(r => r.ReadShort());
        }

        [TestMethod]
        public void ReadNullableShortEnum_Null_Test()
        {
            var value = (ShortEnum?)null;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadBool()).Returns(false));
            mock.Verify(r => r.ReadBool());
            mock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ReadNullableShortEnum_NotNull_Test()
        {
            var value = (ShortEnum?)ShortEnum.Value;
            var mock = SingleValueTest(value, m =>
            {
                m.Setup(r => r.ReadBool()).Returns(true);
                m.Setup(r => r.ReadShort()).Returns((short)value.Value);
            });
            mock.Verify(r => r.ReadBool());
            mock.Verify(r => r.ReadShort());
        }

        [TestMethod]
        public void ReadIntEnum_Test()
        {
            var value = IntEnum.Value;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadInt()).Returns((int)value));
            mock.Verify(r => r.ReadInt());
        }

        [TestMethod]
        public void ReadNullableIntEnum_Null_Test()
        {
            var value = (IntEnum?)null;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadBool()).Returns(false));
            mock.Verify(r => r.ReadBool());
            mock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ReadNullableIntEnum_NotNull_Test()
        {
            var value = (IntEnum?)IntEnum.Value;
            var mock = SingleValueTest(value, m =>
            {
                m.Setup(r => r.ReadBool()).Returns(true);
                m.Setup(r => r.ReadInt()).Returns((int)value.Value);
            });
            mock.Verify(r => r.ReadBool());
            mock.Verify(r => r.ReadInt());
        }

        [TestMethod]
        public void ReadLongEnum_Test()
        {
            var value = LongEnum.Value;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadLong()).Returns((long)value));
            mock.Verify(r => r.ReadLong());
        }

        [TestMethod]
        public void ReadNullableLongEnum_Null_Test()
        {
            var value = (LongEnum?)null;
            var mock = SingleValueTest(value, m => m.Setup(r => r.ReadBool()).Returns(false));
            mock.Verify(r => r.ReadBool());
            mock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ReadNullableLongEnum_NotNull_Test()
        {
            var value = (LongEnum?)LongEnum.Value;
            var mock = SingleValueTest(value, m =>
            {
                m.Setup(r => r.ReadBool()).Returns(true);
                m.Setup(r => r.ReadLong()).Returns((long)value.Value);
            });
            mock.Verify(r => r.ReadBool());
            mock.Verify(r => r.ReadLong());
        }

        private Mock<IReader> SingleValueTest<T>(T value, Action<Mock<IReader>> setup)
        {
            var factory = new ILDeserializerFactory();

            var ctxMock = new Mock<IDeserializationContext>();
            var readerMock = new Mock<IReader>(MockBehavior.Strict);
            ctxMock.Setup(c => c.Reader)
               .Returns(readerMock.Object);

            setup(readerMock);

            var deserializer = factory.Create(typeof(SingleValue<T>), ctxMock.Object);
            var obj = deserializer.Deserialize(ctxMock.Object) as SingleValue<T>;

            Assert.IsNotNull(obj);
            Assert.AreEqual(value, obj.Value);

            return readerMock;
        }
    }
}
