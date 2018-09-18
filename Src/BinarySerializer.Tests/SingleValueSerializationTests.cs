using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BinarySerializer.Tests
{
    [TestClass]
    public class SingleValueSerializationTests
    {
        [TestMethod]
        public void SerializeBool_True_Test()
            => SerializeSingleValue_Test(true);

        [TestMethod]
        public void SerializeBool_False_Test()
            => SerializeSingleValue_Test(false);

        [TestMethod]
        public void SerializeNullableBool_Null_Test()
            => SerializeSingleValue_Test((bool?)null);

        [TestMethod]
        public void SerializeNullableBool_True_Test()
            => SerializeSingleValue_Test((bool?)true);

        [TestMethod]
        public void SerializeNullableBool_False_Test()
            => SerializeSingleValue_Test((bool?)false);

        [TestMethod]
        public void SerializeByte_Test()
            => SerializeSingleValue_Test((byte)122);

        [TestMethod]
        public void SerializeNullableByte_Null_Test()
            => SerializeSingleValue_Test((byte?)null);

        [TestMethod]
        public void SerializeNullableByte_NotNull_Test()
            => SerializeSingleValue_Test((byte?)122);

        [TestMethod]
        public void SerializeShort_Test()
            => SerializeSingleValue_Test((short)1055);

        [TestMethod]
        public void SerializeNullableShort_Null_Test()
            => SerializeSingleValue_Test((short?)null);

        [TestMethod]
        public void SerializeNullableShort_NotNull_Test()
            => SerializeSingleValue_Test((short?)1055);

        [TestMethod]
        public void SerializeInt_Test()
            => SerializeSingleValue_Test(8743957);

        [TestMethod]
        public void SerializeNullableInt_Null_Test()
            => SerializeSingleValue_Test((int?)null);

        [TestMethod]
        public void SerializeNullableInt_NotNull_Test()
            => SerializeSingleValue_Test((int?)8743957);

        [TestMethod]
        public void SerializeLong_Test()
            => SerializeSingleValue_Test(5147000000);

        [TestMethod]
        public void SerializeNullableLong_Null_Test()
            => SerializeSingleValue_Test((long?)null);

        [TestMethod]
        public void SerializeNullableLong_NotNull_Test()
            => SerializeSingleValue_Test((long?)5147000000);

        [TestMethod]
        public void SerializeGuid_Test()
            => SerializeSingleValue_Test(Guid.NewGuid());

        [TestMethod]
        public void SerializeNullableGuid_Null_Test()
            => SerializeSingleValue_Test((Guid?)null);

        [TestMethod]
        public void SerializeNullableGuid_NotNull_Test()
            => SerializeSingleValue_Test((Guid?)Guid.NewGuid());

        [TestMethod]
        public void SerializeString_NotNull_Test()
            => SerializeSingleValue_Test("Some text");

        [TestMethod]
        public void SerializeString_Null_Test()
            => SerializeSingleValue_Test((string)null);

        [TestMethod]
        public void SerializeString_Empty_Test()
            => SerializeSingleValue_Test(string.Empty);

        [TestMethod]
        public void SerializeDateTime_Test()
            => SerializeSingleValue_Test(DateTime.Now);

        [TestMethod]
        public void SerializeNullableDateTime_Null_Test()
            => SerializeSingleValue_Test((DateTime?)null);

        [TestMethod]
        public void SerializeNullableDateTime_NotNull_Test()
            => SerializeSingleValue_Test((DateTime?)DateTime.Now);

        [TestMethod]
        public void SerializeFloat_Test()
            => SerializeSingleValue_Test((float)5.55);

        [TestMethod]
        public void SerializeNullableFloat_Null_Test()
            => SerializeSingleValue_Test((float?)null);

        [TestMethod]
        public void SerializeNullableFloat_NotNull_Test()
            => SerializeSingleValue_Test((float?)5.55);

        [TestMethod]
        public void SerializeDouble_Test()
            => SerializeSingleValue_Test(5.55);

        [TestMethod]
        public void SerializeNullableDouble_Null_Test()
            => SerializeSingleValue_Test((double?)null);

        [TestMethod]
        public void SerializeNullableDouble_NotNull_Test()
            => SerializeSingleValue_Test((double?)5.55);

        [TestMethod]
        public void SerializeDecimal_Test()
            => SerializeSingleValue_Test((decimal)5.55);

        [TestMethod]
        public void SerializeNullableDecimal_Null_Test()
            => SerializeSingleValue_Test((decimal?)null);

        [TestMethod]
        public void SerializeNullableDecimal_NotNull_Test()
            => SerializeSingleValue_Test((decimal?)5.55);

        [TestMethod]
        public void SerializeChar_Test()
            => SerializeSingleValue_Test('c');

        [TestMethod]
        public void SerializeNullableChar_Null_Test()
            => SerializeSingleValue_Test((char?)null);

        [TestMethod]
        public void SerializeNullableChar_NotNull_Test()
            => SerializeSingleValue_Test((char?)'c');

        private void SerializeSingleValue_Test<TValue>(TValue value)
        {
            var @object = new SingleValue<TValue>(value);
            var serializer = BinarySerializer.Create();

            var bytes = serializer.Serialize(@object);
            var deserialized = serializer.Deserialize(bytes, @object.GetType()) as SingleValue<TValue>;

            Assert.IsNotNull(deserialized);
            Assert.AreEqual(@object.Value, deserialized.Value);
        }
    }
}
