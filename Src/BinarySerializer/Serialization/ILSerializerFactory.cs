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

        private static readonly Type _serializerDelegateType = typeof(Action<object, ISerializationContext>);
        private static readonly MethodInfo _getWriterMI = 
            typeof(ISerializationContext).GetProperty(WriterPropertyName, BindingFlags.Instance | BindingFlags.Public)
            .GetMethod;

        private static readonly Dictionary<Type, MethodInfo> _writeMethods = 
            typeof(IWriter)
            .GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .ToDictionary(m => m.GetParameters().Last().ParameterType);

        public ObjectSerializer Create(Type objectType, ISerializationContext context)
        {
            var method = CreateMethod(objectType);
            var il = method.GetILGenerator();

            var objectVar = DeclareObjectVariable(il, objectType);
            var writerVar = DeclareWriterVariable(il);

            SerializeProperties(il, objectVar, writerVar, objectType);

            il.Emit(OpCodes.Ret);

            var serializer = method.CreateDelegate(_serializerDelegateType) as Action<object, ISerializationContext>;
            return new DelegatingObjectSerializer(serializer);
        }

        private static void SerializeProperties(ILGenerator il, LocalBuilder objectVar, LocalBuilder writerVar, Type objectType)
        {
            var properties = SerializationHelper.GetSerializableProperties(objectType);

            MethodInfo writerMethod;
            foreach (var property in properties)
            {
                if (_writeMethods.TryGetValue(property.PropertyType, out writerMethod))
                {
                    il.Emit(OpCodes.Ldloc, writerVar);
                    il.Emit(OpCodes.Ldloc, objectVar);
                    il.EmitCall(OpCodes.Callvirt, property.GetMethod, null);
                    il.EmitCall(OpCodes.Callvirt, writerMethod, null);
                }
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
    }
}
