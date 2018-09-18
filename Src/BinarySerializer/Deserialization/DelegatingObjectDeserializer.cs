using System;

namespace BinarySerializer.Deserialization
{
    public class DelegatingObjectDeserializer : ObjectDeserializer
    {
        private readonly Func<IDeserializationContext, object> _deserializer;

        public DelegatingObjectDeserializer(
            Func<IDeserializationContext, object> deserializer)
        {
            if (deserializer == null)
                throw new ArgumentNullException(nameof(deserializer));

            _deserializer = deserializer;
        }

        public sealed override object Deserialize(IDeserializationContext context)
            => _deserializer(context);

        public static DelegatingObjectDeserializer Create<T>(
            Func<IDeserializationContext, T> deserializer)
        {
            return new DelegatingObjectDeserializer(c => deserializer(c));
        }
    }
}
