using System;
using System.Linq;
using System.Reflection;

namespace BinarySerializer
{
    internal static class SerializationHelper
    {
        private static readonly Type _nullableType = typeof(Nullable<>);

        public static PropertyInfo[] GetSerializableProperties(Type objectType)
            => objectType
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(p => p.CanRead && p.CanWrite)
            .ToArray();

        public static bool IsEnumProperty(PropertyInfo property)
        {
            var propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

            return propertyType.IsEnum;
        }

        public static Type GetUnderlyingEnumType(PropertyInfo property)
        {
            var enumType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
            var underlyingType = Enum.GetUnderlyingType(enumType);
            var isNullable = enumType != property.PropertyType;

            return isNullable ? _nullableType.MakeGenericType(underlyingType) : underlyingType;
        }

        public static bool IsNullable(Type type)
            => Nullable.GetUnderlyingType(type) != null;
    }
}
