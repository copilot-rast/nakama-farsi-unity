using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Assets
{
    public static class AssetCanonicalJson
    {
        public static string Canonical(JToken token)
        {
            var builder = new StringBuilder();
            Write(token, builder);
            return builder.ToString();
        }

        public static string Hash(JToken token)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(Canonical(token)));
                var builder = new StringBuilder(bytes.Length * 2);
                foreach (var value in bytes)
                {
                    builder.Append(value.ToString("x2", CultureInfo.InvariantCulture));
                }

                return builder.ToString();
            }
        }

        private static void Write(JToken token, StringBuilder builder)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    builder.Append('{');
                    var first = true;
                    foreach (var property in ((JObject)token).Properties().OrderBy(p => p.Name, System.StringComparer.Ordinal))
                    {
                        if (!first)
                        {
                            builder.Append(',');
                        }

                        first = false;
                        WriteString(property.Name, builder);
                        builder.Append(':');
                        Write(property.Value, builder);
                    }

                    builder.Append('}');
                    break;
                case JTokenType.Array:
                    builder.Append('[');
                    var index = 0;
                    foreach (var item in (JArray)token)
                    {
                        if (index++ > 0)
                        {
                            builder.Append(',');
                        }

                        Write(item, builder);
                    }

                    builder.Append(']');
                    break;
                case JTokenType.String:
                    var text = (string)token;
                    if (text == null)
                    {
                        builder.Append("null");
                    }
                    else
                    {
                        WriteString(text, builder);
                    }

                    break;
                case JTokenType.Null:
                case JTokenType.Undefined:
                    builder.Append("null");
                    break;
                default:
                    var raw = token.ToString(Formatting.None);
                    if (raw.Length > 0 && raw[0] == '"')
                    {
                        WriteString(token.ToObject<string>(), builder);
                    }
                    else
                    {
                        builder.Append(raw);
                    }

                    break;
            }
        }

        private static void WriteString(string value, StringBuilder builder)
        {
            builder.Append('"');
            foreach (var c in value)
            {
                switch (c)
                {
                    case '"':
                        builder.Append("\\\"");
                        break;
                    case '\\':
                        builder.Append("\\\\");
                        break;
                    case '\b':
                        builder.Append("\\b");
                        break;
                    case '\f':
                        builder.Append("\\f");
                        break;
                    case '\n':
                        builder.Append("\\n");
                        break;
                    case '\r':
                        builder.Append("\\r");
                        break;
                    case '\t':
                        builder.Append("\\t");
                        break;
                    default:
                        if (c < ' ')
                        {
                            builder.Append("\\u").Append(((int)c).ToString("x4", CultureInfo.InvariantCulture));
                        }
                        else
                        {
                            builder.Append(c);
                        }

                        break;
                }
            }

            builder.Append('"');
        }
    }
}
