using System;
using System.Linq;
using System.Reflection;

namespace BinarySerializer
{
    internal static class SerializationHelper
    {
        public static PropertyInfo[] GetSerializableProperties(Type objectType)
            => objectType
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(p => p.CanRead && p.CanWrite)
            .ToArray();
    }
}
