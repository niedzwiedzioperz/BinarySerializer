using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace BinarySerializer.Serialization
{
    public class ILSerializerFactory : ISerializerFactory
    {
        private const string MethodName = "Serialize";
        private const string WriterPropertyName = "Writer";
        private const string HasValuePropertyName = "HasValue";
        private const string ValuePropertyName = "Value";

        private static readonly Type _serializerDelegateType = typeof(Action<object, ISerializationContext>);
        private static readonly MethodInfo _getWriterMI = 
            typeof(ISerializationContext).GetProperty(WriterPropertyName, BindingFlags.Instance | BindingFlags.Public)
            .GetMethod;

        private static readonly Dictionary<Type, MethodInfo> _writeMethods = 
            typeof(IWriter)
            .GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .ToDictionary(m => m.GetParameters().Last().ParameterType);

        #region ISerializerFactory

        public ObjectSerializer Create(Type objectType, ISerializationContext context)
        {
            if (objectType == null)
                throw new ArgumentNullException(nameof(objectType));
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var method = CreateMethod(objectType);
            var il = method.GetILGenerator();

            var objectVar = DeclareObjectVariable(il, objectType);
            var writerVar = DeclareWriterVariable(il);

            SerializeProperties(il, objectVar, writerVar, objectType);

            il.Emit(OpCodes.Ret);

            var serializer = method.CreateDelegate(_serializerDelegateType) as Action<object, ISerializationContext>;
            return new DelegatingObjectSerializer(serializer);
        }

        #endregion

        private static void SerializeProperties(ILGenerator il, LocalBuilder objectVar, LocalBuilder writerVar, Type objectType)
        {
            var properties = SerializationHelper.GetSerializableProperties(objectType);

            foreach (var property in properties)
            {
                if (SerializationHelper.IsEnumProperty(property))
                    SerializeEnumProperty(il, objectVar, writerVar, property);
                else
                    SerializeValueProperty(il, objectVar, writerVar, property);
            }
        }

        private static void SerializeEnumProperty(ILGenerator il, LocalBuilder objectVar, LocalBuilder writerVar, PropertyInfo property)
        {
            var isNullable = Nullable.GetUnderlyingType(property.PropertyType) != null;
            if (isNullable)
            {
                var hasValueProp = property.PropertyType.GetProperty(HasValuePropertyName, BindingFlags.Instance | BindingFlags.Public);
                var valueProp = property.PropertyType.GetProperty(ValuePropertyName, BindingFlags.Instance | BindingFlags.Public);
                var underlyingType = Enum.GetUnderlyingType(valueProp.PropertyType);

                var valueVar = il.DeclareLocal(property.PropertyType);
                var skipValueLabel = il.DefineLabel();

                il.Emit(OpCodes.Ldloc, writerVar);
                il.Emit(OpCodes.Ldloc, objectVar);
                il.EmitCall(OpCodes.Callvirt, property.GetMethod, null);
                il.Emit(OpCodes.Stloc, valueVar); //store property value as local

                il.Emit(OpCodes.Ldloca, valueVar);
                il.EmitCall(OpCodes.Call, hasValueProp.GetMethod, null);
                il.EmitCall(OpCodes.Callvirt, _writeMethods[typeof(bool)], null); //write HasValue

                il.Emit(OpCodes.Ldloca, valueVar);
                il.EmitCall(OpCodes.Call, hasValueProp.GetMethod, null);
                il.Emit(OpCodes.Brfalse_S, skipValueLabel);

                il.Emit(OpCodes.Ldloc, writerVar);
                il.Emit(OpCodes.Ldloca, valueVar);
                il.EmitCall(OpCodes.Call, valueProp.GetMethod, null);
                il.EmitCall(OpCodes.Callvirt, _writeMethods[underlyingType], null); //if HasValue then write Value

                il.MarkLabel(skipValueLabel);
            }
            else
            {
                SerializeValueProperty(il, objectVar, writerVar, property);
            }
        }

        private static void SerializeValueProperty(ILGenerator il, LocalBuilder objectVar, LocalBuilder writerVar, PropertyInfo property)
        {
            var propretyType = GetPropertyType(property);
            if (_writeMethods.TryGetValue(propretyType, out MethodInfo writerMethod))
            {
                il.Emit(OpCodes.Ldloc, writerVar);
                il.Emit(OpCodes.Ldloc, objectVar);
                il.EmitCall(OpCodes.Callvirt, property.GetMethod, null);
                il.EmitCall(OpCodes.Callvirt, writerMethod, null);
            }
        }

        private static DynamicMethod CreateMethod(Type objectType)
            => new DynamicMethod(
                MethodName,
                typeof(void),
                new[] { typeof(object), typeof(ISerializationContext) },
                true);

        private static LocalBuilder DeclareObjectVariable(ILGenerator il, Type objectType)
        {
            var objectVar = il.DeclareLocal(objectType);

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Castclass, objectType);
            il.Emit(OpCodes.Stloc, objectVar);

            return objectVar;
        }

        private static LocalBuilder DeclareWriterVariable(ILGenerator il)
        {
            var writerVar = il.DeclareLocal(typeof(IWriter));

            il.Emit(OpCodes.Ldarg_1);
            il.EmitCall(OpCodes.Callvirt, _getWriterMI, null);
            il.Emit(OpCodes.Stloc, writerVar);

            return writerVar;
        }

        private static Type GetPropertyType(PropertyInfo property)
            => SerializationHelper.IsEnumProperty(property) ? SerializationHelper.GetUnderlyingEnumType(property) : property.PropertyType;
    }
}
