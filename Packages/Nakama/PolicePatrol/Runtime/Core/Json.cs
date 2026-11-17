using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk
{
    internal static class J
    {
        public static string Str(JToken t, string name) => t?[name] == null || t[name].Type == JTokenType.Null ? null : (string)t[name];

        public static string Str(JToken t, params string[] names) => names.Select(n => Str(t, n)).FirstOrDefault(v => v != null);

        public static double Num(JToken t, string name, double fallback = 0) =>
            t?[name] != null && (t[name].Type == JTokenType.Integer || t[name].Type == JTokenType.Float) ? (double)t[name] : fallback;

        public static double? NumOrNull(JToken t, string name) =>
            t?[name] != null && (t[name].Type == JTokenType.Integer || t[name].Type == JTokenType.Float) ? (double?)(double)t[name] : null;

        public static int Int(JToken t, string name, int fallback = 0) => (int)Math.Round(Num(t, name, fallback));

        public static long Long(JToken t, string name, long fallback = 0) => (long)Math.Round(Num(t, name, fallback));

        public static bool Bool(JToken t, string name, bool fallback = false) =>
            t?[name] != null && t[name].Type == JTokenType.Boolean ? (bool)t[name] : fallback;

        public static IEnumerable<JToken> Arr(JToken t, string name) => t?[name] as JArray ?? new JArray();

        public static DateTimeOffset? Time(JToken t, string name)
        {
            var v = t?[name];
            if (v == null || v.Type == JTokenType.Null)
            {
                return null;
            }

            if (v.Type == JTokenType.Integer)
            {
                return DateTimeOffset.FromUnixTimeSeconds((long)v);
            }

            return DateTimeOffset.TryParse((string)v, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var d) ? (DateTimeOffset?)d : null;
        }

        public static DateTimeOffset TimeOr(JToken t, string name) => Time(t, name) ?? DateTimeOffset.MinValue;
    }
}
