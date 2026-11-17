using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PolicePatrol.Sdk
{
    public static class QueryString
    {
        public static string Append(string path, params (string Name, object Value)[] parameters) =>
            Append(path, (IEnumerable<(string Name, object Value)>)parameters);

        public static string Append(string path, IEnumerable<(string Name, object Value)> parameters)
        {
            var builder = new StringBuilder(path);
            var separator = path.IndexOf('?') >= 0 ? '&' : '?';
            foreach (var (name, value) in parameters)
            {
                var text = Format(value);
                if (text == null)
                {
                    continue;
                }

                builder.Append(separator).Append(Uri.EscapeDataString(name)).Append('=').Append(Uri.EscapeDataString(text));
                separator = '&';
            }

            return builder.ToString();
        }

        public static string FormatDate(DateTimeOffset value) =>
            value.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.InvariantCulture);

        private static string Format(object value)
        {
            switch (value)
            {
                case null:
                    return null;
                case string text:
                    return text.Length == 0 ? null : text;
                case bool flag:
                    return flag ? "true" : "false";
                case DateTimeOffset moment:
                    return FormatDate(moment);
                case DateTime moment:
                    return FormatDate(new DateTimeOffset(moment.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(moment, DateTimeKind.Utc) : moment));
                case IFormattable formattable:
                    return formattable.ToString(null, CultureInfo.InvariantCulture);
                case IEnumerable<string> items:
                    var joined = string.Join(",", items);
                    return joined.Length == 0 ? null : joined;
                default:
                    return value.ToString();
            }
        }
    }
}
