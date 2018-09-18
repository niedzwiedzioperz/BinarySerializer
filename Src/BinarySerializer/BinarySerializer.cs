using BinarySerializer.Deserialization;
using BinarySerializer.Serialization;
using System;
using System.IO;

namespace BinarySerializer
{
    public class BinarySerializer
    {
        private readonly SerializerCollection _serializerCollection;
        private readonly DeserializerCollection _deserializerCollection;

        public BinarySerializer(
            ISerializerFactory serializerFactory,
            IDeserializerFactory deserializerFactory)
        {
            if (serializerFactory == null)
                throw new ArgumentNullException(nameof(serializerFactory));
            if (deserializerFactory == null)
                throw new ArgumentNullException(nameof(deserializerFactory));

            _serializerCollection = new SerializerCollection(serializerFactory);
            _deserializerCollection = new DeserializerCollection(deserializerFactory);
        }

        public byte[] Serialize(object @object)
        {
            using (var ms = new MemoryStream())
            {
                using (var writer = new BinaryWriter(ms))
                {
                    var objectWriter = new BinaryObjectWriter(writer);
                    var context = NewContext(objectWriter);

                    context.Write(@object);
                }

                return ms.GetBuffer();
            }
        }

        public object Deserialize(byte[] bytes, Type objectType)
        {
            using (var ms = new MemoryStream(bytes))
            {
                using (var reader = new BinaryReader(ms))
                {
                    var objectReader = new BinaryObjectReader(reader);
                    var context = NewContext(objectReader);

                    return context.Read(objectType);
                }
            }
        }

        private SerializationContext NewContext(IWriter writer)
            => new SerializationContext(_serializerCollection, writer);

        private DeserializationContext NewContext(IReader reader)
            => new DeserializationContext(_deserializerCollection, reader);

        public static BinarySerializer Create()
            => new BinarySerializer(
                new ILSerializerFactory(),
                new ILDeserializerFactory());
    }
}
