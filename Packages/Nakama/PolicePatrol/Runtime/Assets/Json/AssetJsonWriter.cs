using System;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Assets
{
    internal sealed class AssetJsonWriter
    {
        private readonly AssetJsonOptions _options;

        public AssetJsonWriter(AssetJsonOptions options)
        {
            _options = options ?? new AssetJsonOptions();
        }

        public JObject WriteFields(object source, int depth)
        {
            var json = new JObject();
            foreach (var field in AssetFieldRules.For(source.GetType()))
            {
                if (TryWrite(field.GetValue(source), field.FieldType, depth, out var token))
                {
                    json[field.Name] = token;
                }
            }

            return json;
        }

        private bool TryWrite(object value, Type type, int depth, out JToken token)
        {
            token = null;
            if (depth > AssetFieldRules.MaxDepth)
            {
                return false;
            }

            var converter = _options.FindConverter(type);
            if (converter != null)
            {
                token = converter.Write(value) ?? JValue.CreateNull();
                return true;
            }

            if (_options.References != null && _options.References.IsReference(type))
            {
                token = _options.References.Write(value) ?? JValue.CreateNull();
                return true;
            }

            if (type == typeof(string))
            {
                token = value == null ? JValue.CreateNull() : new JValue((string)value);
                return true;
            }

            if (type.IsEnum)
            {
                token = Enum.IsDefined(type, value) ? new JValue(value.ToString()) : new JValue(Convert.ToInt64(value));
                return true;
            }

            if (AssetFieldRules.IsPrimitive(type))
            {
                token = type == typeof(char) ? new JValue((long)(char)value) : new JValue(value);
                return true;
            }

            var element = AssetFieldRules.ElementType(type);
            if (element != null)
            {
                return TryWriteList(value as IEnumerable, element, depth, out token);
            }

            if (AssetFieldRules.IsComposite(type))
            {
                token = value == null ? (JToken)JValue.CreateNull() : WriteFields(value, depth + 1);
                return true;
            }

            return false;
        }

        private bool TryWriteList(IEnumerable items, Type element, int depth, out JToken token)
        {
            var array = new JArray();
            token = array;
            if (items == null)
            {
                return true;
            }

            foreach (var item in items)
            {
                if (!TryWrite(item, element, depth + 1, out var itemToken))
                {
                    return false;
                }

                array.Add(itemToken);
            }

            return true;
        }
    }
}
