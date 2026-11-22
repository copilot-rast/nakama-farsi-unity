using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Stages
{
    public abstract class SettingsBag
    {
        protected SettingsBag(JObject raw)
        {
            Raw = raw ?? new JObject();
        }

        public JObject Raw { get; }

        public bool IsEmpty => !Raw.HasValues;

        public bool Has(string key) => Raw[key] != null && Raw[key].Type != JTokenType.Null;

        public T Get<T>(string key, T fallback = default)
        {
            var v = Raw[key];
            if (v == null || v.Type == JTokenType.Null)
            {
                return fallback;
            }

            try
            {
                return v.ToObject<T>();
            }
            catch (Exception)
            {
                return fallback;
            }
        }

        protected string Str(string key) => J.Str(Raw, key);

        protected double? Num(string key) => J.NumOrNull(Raw, key);

        protected bool? Flag(string key) => Raw[key]?.Type == JTokenType.Boolean ? (bool?)(bool)Raw[key] : null;

        protected string[] Strings(string key) => Strings(Raw, key);

        internal static string[] Strings(JToken t, string key) =>
            t?[key] is JArray a ? a.Where(x => x.Type == JTokenType.String).Select(x => (string)x).ToArray() : Array.Empty<string>();
    }
}
