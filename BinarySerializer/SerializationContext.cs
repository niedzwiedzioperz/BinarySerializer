using System;
using System.IO;

namespace BinarySerializer
{
    public class SerializationContext : ISerializationContext, IWriter
    {
        private readonly BinaryWriter _binaryWriter;
        private readonly SerializerCollection _serializerCollection;

        public SerializationContext(
            BinaryWriter binaryWriter,
            SerializerCollection serializerCollection)
        {
            if (binaryWriter == null)
                throw new ArgumentNullException(nameof(binaryWriter));
            if (serializerCollection == null)
                throw new ArgumentNullException(nameof(serializerCollection));

            _binaryWriter = binaryWriter;
            _serializerCollection = serializerCollection;
        }

        #region ISerializationContext

        IWriter ISerializationContext.Writer => this;

        #endregion

        #region IWriter

        BinaryWriter IWriter.Writer => _binaryWriter;

        void IWriter.Write(object @object)
        {
            var serializer = _serializerCollection.Get(@object.GetType(), this);

            serializer.Serialize(@object, this);
        }

        #endregion
    }
}
