using System;

namespace BinarySerializer
{
    public class DelegatingObjectSerializer : ObjectSerializer
    {
        private readonly Action<object, ISerializationContext> _serializer;

        public DelegatingObjectSerializer(
            Action<object, ISerializationContext> serializer)
        {
            if (serializer == null)
                throw new ArgumentNullException(nameof(serializer));

            _serializer = serializer;
        }

        public sealed override void Serialize(object @object, ISerializationContext context)
            => _serializer(@object, context);

        public DelegatingObjectSerializer Create<T>(
            Action<T, ISerializationContext> serializer)
        {
            return new DelegatingObjectSerializer((o, c) => serializer((T)o, c));
        }
    }
}
