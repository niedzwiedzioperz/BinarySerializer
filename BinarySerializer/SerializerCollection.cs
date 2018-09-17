using System;
using System.Collections.Generic;

namespace BinarySerializer
{
    public class SerializerCollection
    {
        private readonly ISerializerFactory _serializerFactory;

        private readonly Dictionary<Type, ObjectSerializer> _serializers = new Dictionary<Type, ObjectSerializer>();

        public SerializerCollection(
            ISerializerFactory serializerFactory)
        {
            if (serializerFactory == null)
                throw new ArgumentNullException(nameof(serializerFactory));

            _serializerFactory = serializerFactory;
        }

        public ObjectSerializer Get(Type objectType, ISerializationContext context)
        {
            if (objectType == null)
                throw new ArgumentNullException(nameof(objectType));
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            ObjectSerializer serializer;
            if (!_serializers.TryGetValue(objectType, out serializer))
            {
                serializer = Create(objectType, context);
                _serializers[objectType] = serializer;
            }

            return serializer;
        }

        private ObjectSerializer Create(Type objectType, ISerializationContext context)
            => _serializerFactory.Create(objectType, context);
    }
}
