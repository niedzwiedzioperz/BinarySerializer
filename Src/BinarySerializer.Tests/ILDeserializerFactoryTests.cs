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
            SingleValueTest(value, m => m.Setup(r => r.ReadBool()).Returns(value));
        }

        [TestMethod]
        public void ReadNullableBool_Test()
        {
            var value = (bool?)false;
            SingleValueTest(value, m => m.Setup(r => r.ReadNullableBool()).Returns(value));
        }

        [TestMethod]
        public void ReadByte_Test()
        {
            var value = (byte)122;
            SingleValueTest(value, m => m.Setup(r => r.ReadByte()).Returns(value));
        }

        [TestMethod]
        public void ReadNullableByte_Test()
        {
            var value = (byte?)122;
            SingleValueTest(value, m => m.Setup(r => r.ReadNullableByte()).Returns(value));
        }

        [TestMethod]
        public void ReadShort_Test()
        {
            var value = (short)122;
            SingleValueTest(value, m => m.Setup(r => r.ReadShort()).Returns(value));
        }

        [TestMethod]
        public void ReadNullableShort_Test()
        {
            var value = (short?)122;
            SingleValueTest(value, m => m.Setup(r => r.ReadNullableShort()).Returns(value));
        }

        [TestMethod]
        public void ReadInt_Test()
        {
            var value = 4545;
            SingleValueTest(value, m => m.Setup(r => r.ReadInt()).Returns(value));
        }

        [TestMethod]
        public void ReadNullableInt_Test()
        {
            var value = (int?)4545;
            SingleValueTest(value, m => m.Setup(r => r.ReadNullableInt()).Returns(value));
        }

        [TestMethod]
        public void ReadLong_Test()
        {
            var value = (long)122;
            SingleValueTest(value, m => m.Setup(r => r.ReadLong()).Returns(value));
        }

        [TestMethod]
        public void ReadNullableLong_Test()
        {
            var value = (long?)122;
            SingleValueTest(value, m => m.Setup(r => r.ReadNullableLong()).Returns(value));
        }

        [TestMethod]
        public void ReadChar_Test()
        {
            var value = 'c';
            SingleValueTest(value, m => m.Setup(r => r.ReadChar()).Returns(value));
        }

        [TestMethod]
        public void ReadNullableChar_Test()
        {
            var value = (char?)'c';
            SingleValueTest(value, m => m.Setup(r => r.ReadNullableChar()).Returns(value));
        }

        [TestMethod]
        public void ReadFloat_Test()
        {
            var value = (float)122;
            SingleValueTest(value, m => m.Setup(r => r.ReadFloat()).Returns(value));
        }

        [TestMethod]
        public void ReadNullableFloat_Test()
        {
            var value = (float?)122;
            SingleValueTest(value, m => m.Setup(r => r.ReadNullableFloat()).Returns(value));
        }

        [TestMethod]
        public void ReadDouble_Test()
        {
            var value = (double)122;
            SingleValueTest(value, m => m.Setup(r => r.ReadDouble()).Returns(value));
        }

        [TestMethod]
        public void ReadNullableDouble_Test()
        {
            var value = (double?)122;
            SingleValueTest(value, m => m.Setup(r => r.ReadNullableDouble()).Returns(value));
        }

        [TestMethod]
        public void ReadDecimal_Test()
        {
            var value = (decimal)122;
            SingleValueTest(value, m => m.Setup(r => r.ReadDecimal()).Returns(value));
        }

        [TestMethod]
        public void ReadNullableDecimal_Test()
        {
            var value = (decimal?)122;
            SingleValueTest(value, m => m.Setup(r => r.ReadNullableDecimal()).Returns(value));
        }

        [TestMethod]
        public void ReadString_Test()
        {
            var value = "some text";
            SingleValueTest(value, m => m.Setup(r => r.ReadString()).Returns(value));
        }

        [TestMethod]
        public void ReadGuid_Test()
        {
            var value = Guid.NewGuid();
            SingleValueTest(value, m => m.Setup(r => r.ReadGuid()).Returns(value));
        }

        [TestMethod]
        public void ReadNullableGuid_Test()
        {
            var value = (Guid?)Guid.NewGuid();
            SingleValueTest(value, m => m.Setup(r => r.ReadNullableGuid()).Returns(value));
        }

        [TestMethod]
        public void ReadDateTime_Test()
        {
            var value = DateTime.Now;
            SingleValueTest(value, m => m.Setup(r => r.ReadDateTime()).Returns(value));
        }

        [TestMethod]
        public void ReadNullableDateTime_Test()
        {
            var value = (DateTime?)DateTime.Now;
            SingleValueTest(value, m => m.Setup(r => r.ReadNullableDateTime()).Returns(value));
        }

        private void SingleValueTest<T>(T value, Action<Mock<IReader>> setup)
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
        }
    }
}
