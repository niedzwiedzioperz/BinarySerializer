using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BinarySerializer.Tests
{
    [TestClass]
    public class DeserializerCollectionTests
    {
        [TestMethod]
        public void CreateNewDeserializer_Test()
        {
            var deserializerMock = new DelegatingObjectDeserializer(c => null);
            var factoryMock = new Mock<IDeserializerFactory>();

            factoryMock
                .Setup(f => f.Create(It.IsAny<Type>(), It.IsAny<IDeserializationContext>()))
                .Returns(deserializerMock);

            var collection = new DeserializerCollection(factoryMock.Object);
            var deserializer = collection.Get(typeof(DeserializerCollectionTests), Mock.Of<IDeserializationContext>());

            Assert.IsNotNull(deserializer);
            Assert.AreSame(deserializerMock, deserializer);
        }

        [TestMethod]
        public void GetExistingDeserializer_Test()
        {
            var deserializerMock = new DelegatingObjectDeserializer(c => null);
            var factoryMock = new Mock<IDeserializerFactory>();

            factoryMock
                .Setup(f => f.Create(It.IsAny<Type>(), It.IsAny<IDeserializationContext>()))
                .Returns(deserializerMock);

            var collection = new DeserializerCollection(factoryMock.Object);
            var deserializer1 = collection.Get(typeof(DeserializerCollectionTests), Mock.Of<IDeserializationContext>());
            var deserializer2 = collection.Get(typeof(DeserializerCollectionTests), Mock.Of<IDeserializationContext>());

            Assert.IsNotNull(deserializer1);
            Assert.IsNotNull(deserializer2);
            Assert.AreSame(deserializer1, deserializer2);
        }
    }
}
