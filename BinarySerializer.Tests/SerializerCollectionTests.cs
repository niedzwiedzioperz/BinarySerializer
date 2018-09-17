using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BinarySerializer.Tests
{
    [TestClass]
    public class SerializerCollectionTests
    {
        [TestMethod]
        public void CreateNewSerializer_Test()
        {
            var serializerMock = new DelegatingObjectSerializer((x, c) => { });
            var factoryMock = new Mock<ISerializerFactory>();

            factoryMock
                .Setup(f => f.Create(It.IsAny<Type>(), It.IsAny<ISerializationContext>()))
                .Returns(serializerMock);

            var collection = new SerializerCollection(factoryMock.Object);
            var serializer = collection.Get(typeof(SerializerCollectionTests), Mock.Of<ISerializationContext>());

            Assert.IsNotNull(serializer);
            Assert.AreSame(serializerMock, serializer);
        }

        [TestMethod]
        public void GetExistingSerializer_Test()
        {
            var serializerMock = new DelegatingObjectSerializer((x, c) => { });
            var factoryMock = new Mock<ISerializerFactory>();

            factoryMock
                .Setup(f => f.Create(It.IsAny<Type>(), It.IsAny<ISerializationContext>()))
                .Returns(serializerMock);

            var collection = new SerializerCollection(factoryMock.Object);
            var serializer1 = collection.Get(typeof(SerializerCollectionTests), Mock.Of<ISerializationContext>());
            var serializer2 = collection.Get(typeof(SerializerCollectionTests), Mock.Of<ISerializationContext>());

            Assert.IsNotNull(serializer1);
            Assert.IsNotNull(serializer2);
            Assert.AreSame(serializer1, serializer2);
        }
    }
}
