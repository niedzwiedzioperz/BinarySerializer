using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace BinarySerializer.Deserialization
{
    public class ILDeserializerFactory : IDeserializerFactory
    {
        private const string MethodName = "Deserialize";
        private const string ReaderPropertyName = "Reader";

        private static readonly Type _deserializerDelegateType = typeof(Func<IDeserializationContext, object>);
        private static readonly MethodInfo _getReaderMI =
            typeof(IDeserializationContext).GetProperty(ReaderPropertyName, BindingFlags.Instance | BindingFlags.Public)
            .GetMethod;

        private static readonly Dictionary<Type, MethodInfo> _readMethods =
            typeof(IReader)
            .GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .ToDictionary(m => m.ReturnType);

        #region IDeserializerFactory

        public ObjectDeserializer Create(Type objectType, IDeserializationContext context)
        {
            if (objectType == null)
                throw new ArgumentNullException(nameof(objectType));
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var method = CreateMethod(objectType);
            var il = method.GetILGenerator();

            var objectVar = DeclareObjectVariable(il, objectType);
            var readerVar = DeclareReaderVariable(il);

            DeserializeProperties(il, objectVar, readerVar, objectType);

            il.Emit(OpCodes.Ldloc, objectVar);
            il.Emit(OpCodes.Ret);

            var serializer = method.CreateDelegate(_deserializerDelegateType) as Func<IDeserializationContext, object>;
            return new DelegatingObjectDeserializer(serializer);
        }

        private class X
        {
            public int? XX { get; set; }
        }

        public object Deserialize(IDeserializationContext ctx)
        {
            var obj = new X();
            var reader = ctx.Reader;

            obj.XX = reader.ReadNullableInt();

            return obj;
        }

        #endregion

        private static void DeserializeProperties(ILGenerator il, LocalBuilder objectVar, LocalBuilder readerVar, Type objectType)
        {
            var properties = SerializationHelper.GetSerializableProperties(objectType);

            MethodInfo readerMethod;
            foreach (var property in properties)
            {
                if (_readMethods.TryGetValue(property.PropertyType, out readerMethod))
                {
                    il.Emit(OpCodes.Ldloc, objectVar);
                    il.Emit(OpCodes.Ldloc, readerVar);
                    il.EmitCall(OpCodes.Callvirt, readerMethod, null);
                    il.EmitCall(OpCodes.Callvirt, property.SetMethod, null);
                }
            }
        }

        private static DynamicMethod CreateMethod(Type objectType)
            => new DynamicMethod(
                MethodName,
                typeof(object),
                new[] { typeof(IDeserializationContext) },
                true);

        private static LocalBuilder DeclareObjectVariable(ILGenerator il, Type objectType)
        {
            var ctor = GetDefaultConstructor(objectType);

            var objectVar = il.DeclareLocal(objectType);

            il.Emit(OpCodes.Newobj, ctor);
            il.Emit(OpCodes.Stloc, objectVar);

            return objectVar;
        }

        private static LocalBuilder DeclareReaderVariable(ILGenerator il)
        {
            var readerVar = il.DeclareLocal(typeof(IReader));

            il.Emit(OpCodes.Ldarg_0);
            il.EmitCall(OpCodes.Callvirt, _getReaderMI, null);
            il.Emit(OpCodes.Stloc, readerVar);

            return readerVar;
        }

        private static ConstructorInfo GetDefaultConstructor(Type objectType)
            => objectType
            .GetConstructors(BindingFlags.Instance | BindingFlags.Public)
            .Single(c => c.GetParameters().Length == 0);
    }
}
