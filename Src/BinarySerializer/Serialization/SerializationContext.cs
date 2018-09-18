using System;

namespace BinarySerializer.Serialization
{
    public class SerializationContext : ISerializationContext
    {
        private readonly SerializerCollection _serializerCollection;

        public SerializationContext(
            SerializerCollection serializerCollection,
            IWriter writer)
        {
            if (serializerCollection == null)
                throw new ArgumentNullException(nameof(serializerCollection));
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            _serializerCollection = serializerCollection;
            Writer = writer;
        }

        #region ISerializationContext

        public IWriter Writer { get; }

        public void Write(object @object)
        {
            var serializer = _serializerCollection.Get(@object.GetType(), this);

            serializer.Serialize(@object, this);
        }

        #endregion
    }
}
