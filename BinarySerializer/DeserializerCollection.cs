using System;
using System.Collections.Generic;

namespace BinarySerializer
{
    public class DeserializerCollection
    {
        private readonly IDeserializerFactory _deserializerFactory;

        private readonly Dictionary<Type, ObjectDeserializer> _deserializers = new Dictionary<Type, ObjectDeserializer>();

        public DeserializerCollection(
            IDeserializerFactory deserializerFactory)
        {
            if (deserializerFactory == null)
                throw new ArgumentNullException(nameof(deserializerFactory));

            _deserializerFactory = deserializerFactory;
        }

        public ObjectDeserializer Get(Type objectType, IDeserializationContext context)
        {
            if (objectType == null)
                throw new ArgumentNullException(nameof(objectType));
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            ObjectDeserializer deserializer;
            if (!_deserializers.TryGetValue(objectType, out deserializer))
            {
                deserializer = Create(objectType, context);
                _deserializers[objectType] = deserializer;
            }

            return deserializer;
        }

        private ObjectDeserializer Create(Type objectType, IDeserializationContext context)
            => _deserializerFactory.Create(objectType, context);
    }
}
