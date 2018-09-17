using System;
using System.IO;

namespace BinarySerializer
{
    public class DeserializationContext : IDeserializationContext, IReader
    {
        private readonly BinaryReader _binaryReader;
        private readonly DeserializerCollection _deserializerCollection;

        public DeserializationContext(
            BinaryReader binaryReader,
            DeserializerCollection deserializerCollection)
        {
            if (binaryReader == null)
                throw new ArgumentNullException(nameof(binaryReader));
            if (deserializerCollection == null)
                throw new ArgumentNullException(nameof(deserializerCollection));

            _binaryReader = binaryReader;
            _deserializerCollection = deserializerCollection;
        }

        #region IDeserializationContext

        IReader IDeserializationContext.Reader => this;

        #endregion

        #region IReader

        BinaryReader IReader.Reader => _binaryReader;

        object IReader.Read(Type objectType)
        {
            var deserializer = _deserializerCollection.Get(objectType, this);

            return deserializer.Deserialize(this);
        }

        #endregion
    }
}
