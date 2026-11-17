using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PolicePatrol.Sdk.Assets
{
    internal static class AssetFieldRules
    {
        public const int MaxDepth = 10;

        private const BindingFlags Declared = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;

        private static readonly HashSet<string> UnityRoots = new HashSet<string>(StringComparer.Ordinal)
        {
            "UnityEngine.Object", "UnityEngine.ScriptableObject", "UnityEngine.Component", "UnityEngine.Behaviour", "UnityEngine.MonoBehaviour",
        };

        private static readonly ConcurrentDictionary<Type, FieldInfo[]> Cache = new ConcurrentDictionary<Type, FieldInfo[]>();

        public static FieldInfo[] For(Type type) => Cache.GetOrAdd(type, Collect);

        public static Type ElementType(Type type)
        {
            Type element = null;
            if (type.IsArray && type.GetArrayRank() == 1)
            {
                element = type.GetElementType();
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                element = type.GetGenericArguments()[0];
            }

            return element == null || element.IsArray || (element.IsGenericType && element.GetGenericTypeDefinition() == typeof(List<>)) ? null : element;
        }

        public static bool IsComposite(Type type) =>
            !type.IsPrimitive && !type.IsEnum && type != typeof(string) && type != typeof(decimal) && !type.IsArray
            && !type.IsAbstract && !type.IsInterface && !typeof(Delegate).IsAssignableFrom(type)
            && ElementType(type) == null
            && !IsSystemType(type)
            && (type.IsSerializable || (type.IsValueType && type.Namespace == "UnityEngine"));

        public static bool IsPrimitive(Type type) =>
            (type.IsPrimitive && type != typeof(IntPtr) && type != typeof(UIntPtr)) || type == typeof(decimal);

        private static bool IsSystemType(Type type) =>
            type.Namespace != null && (type.Namespace == "System" || type.Namespace.StartsWith("System.", StringComparison.Ordinal));

        private static FieldInfo[] Collect(Type type)
        {
            var chain = new List<Type>();
            for (var current = type; current != null && current != typeof(object) && !UnityRoots.Contains(current.FullName ?? string.Empty); current = current.BaseType)
            {
                chain.Insert(0, current);
            }

            return chain.SelectMany(t => t.GetFields(Declared)).Where(IsSerialized).ToArray();
        }

        private static bool IsSerialized(FieldInfo field) =>
            !field.IsStatic && !field.IsInitOnly && !field.IsNotSerialized
            && (field.IsPublic || Has(field, "SerializeField"))
            && !Has(field, "SerializeReference");

        private static bool Has(MemberInfo member, string name) =>
            member.GetCustomAttributes(false).Any(attribute => attribute.GetType().Name == name + "Attribute");
    }
}
