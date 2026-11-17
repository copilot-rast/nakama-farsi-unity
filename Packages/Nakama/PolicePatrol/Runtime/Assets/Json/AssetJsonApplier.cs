using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Assets
{
    internal sealed class AssetJsonApplier
    {
        private readonly AssetJsonOptions _options;
        private readonly List<string> _warnings = new List<string>();

        public AssetJsonApplier(AssetJsonOptions options)
        {
            _options = options ?? new AssetJsonOptions();
        }

        public string[] Warnings => _warnings.ToArray();

        public void ApplyFields(JObject json, object target, string path, int depth)
        {
            foreach (var field in AssetFieldRules.For(target.GetType()))
            {
                if (!json.TryGetValue(field.Name, StringComparison.Ordinal, out var token))
                {
                    continue;
                }

                if (TryRead(token, field.FieldType, field.GetValue(target), Join(path, field.Name), depth, out var value))
                {
                    field.SetValue(target, value);
                }
            }
        }

        private bool TryRead(JToken token, Type type, object current, string path, int depth, out object value)
        {
            value = current;
            if (depth > AssetFieldRules.MaxDepth)
            {
                return false;
            }

            try
            {
                return TryReadValue(token, type, current, path, depth, out value);
            }
            catch (Exception error) when (error is FormatException || error is InvalidCastException || error is OverflowException || error is ArgumentException || error is JsonException)
            {
                value = current;
                return Warn(path, error.Message);
            }
        }

        private bool TryReadValue(JToken token, Type type, object current, string path, int depth, out object value)
        {
            value = current;
            var converter = _options.FindConverter(type);
            if (converter != null)
            {
                value = converter.Read(token, type, current);
                return true;
            }

            if (_options.References != null && _options.References.IsReference(type))
            {
                return _options.References.TryRead(token, type, current, out value) || Warn(path, "link not found, the current value is kept");
            }

            if (token.Type == JTokenType.Null)
            {
                value = null;
                return !type.IsValueType && !AssetFieldRules.IsComposite(type);
            }

            if (type == typeof(string))
            {
                value = token is JValue raw && raw.Type != JTokenType.String ? Convert.ToString(raw.Value, CultureInfo.InvariantCulture) : (string)token;
                return true;
            }

            if (type.IsEnum)
            {
                value = token.Type == JTokenType.String ? Enum.Parse(type, (string)token) : Enum.ToObject(type, Convert.ToInt64(((JValue)token).Value, CultureInfo.InvariantCulture));
                return true;
            }

            if (AssetFieldRules.IsPrimitive(type))
            {
                value = Convert.ChangeType(((JValue)token).Value, type, CultureInfo.InvariantCulture);
                return true;
            }

            var element = AssetFieldRules.ElementType(type);
            if (element != null)
            {
                return token is JArray array ? ReadList(array, type, element, current as IList, path, depth, out value) : Warn(path, "expected a list");
            }

            if (AssetFieldRules.IsComposite(type))
            {
                if (!(token is JObject json))
                {
                    return Warn(path, "expected an object");
                }

                var instance = current ?? Create(type);
                ApplyFields(json, instance, path, depth + 1);
                value = instance;
                return true;
            }

            return false;
        }

        private bool ReadList(JArray array, Type type, Type element, IList current, string path, int depth, out object value)
        {
            var items = new object[array.Count];
            for (var i = 0; i < array.Count; i++)
            {
                var existing = current != null && i < current.Count ? current[i] : null;
                items[i] = TryRead(array[i], element, existing, path + "[" + i + "]", depth + 1, out var item) ? item : existing ?? Default(element);
            }

            if (type.IsArray)
            {
                var result = Array.CreateInstance(element, items.Length);
                for (var i = 0; i < items.Length; i++)
                {
                    result.SetValue(items[i], i);
                }

                value = result;
            }
            else
            {
                var result = (IList)Activator.CreateInstance(type);
                foreach (var item in items)
                {
                    result.Add(item);
                }

                value = result;
            }

            return true;
        }

        private bool Warn(string path, string reason)
        {
            _warnings.Add(path + ": " + reason);
            return false;
        }

        private static object Default(Type type) => type.IsValueType ? Activator.CreateInstance(type) : null;

        private static object Create(Type type) =>
            type.IsValueType || type.GetConstructor(Type.EmptyTypes) != null
                ? Activator.CreateInstance(type, true)
                : RuntimeHelpers.GetUninitializedObject(type);

        private static string Join(string path, string name) => string.IsNullOrEmpty(path) ? name : path + "." + name;
    }
}
