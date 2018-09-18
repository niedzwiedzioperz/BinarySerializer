using System;

namespace BinarySerializer.Deserialization
{
    public class DeserializationContext : IDeserializationContext
    {
        private readonly DeserializerCollection _deserializerCollection;

        public DeserializationContext(
            DeserializerCollection deserializerCollection,
            IReader reader)
        {
            if (deserializerCollection == null)
                throw new ArgumentNullException(nameof(deserializerCollection));
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            _deserializerCollection = deserializerCollection;
            Reader = reader;
        }

        #region IDeserializationContext

        public IReader Reader { get; }

        public object Read(Type objectType)
        {
            var deserializer = _deserializerCollection.Get(objectType, this);

            return deserializer.Deserialize(this);
        }

        #endregion
    }
}
