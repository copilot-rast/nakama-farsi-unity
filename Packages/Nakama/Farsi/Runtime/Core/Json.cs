using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace NakamaFarsi.Sdk
{
    public interface IRawResponse
    {
        JObject Raw { get; set; }
    }

    public static class SdkJson
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            MissingMemberHandling = MissingMemberHandling.Ignore,
        };

        public static readonly JsonSerializerSettings Lenient = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            Error = (sender, args) =>
            {
                if (args.CurrentObject != null && args.CurrentObject != args.ErrorContext.OriginalObject)
                {
                    return;
                }

                if (args.ErrorContext.Member != null)
                {
                    MemberSkipped?.Invoke(args.ErrorContext.Path, args.ErrorContext.Error.Message);
                    args.ErrorContext.Handled = true;
                }
            },
        };

        public static event Action<string, string> MemberSkipped;

        public static readonly JsonSerializer Serializer = JsonSerializer.Create(Settings);

        public static readonly JsonSerializer LenientSerializer = JsonSerializer.Create(Lenient);

        public static string Serialize(object value) => value is string s ? s : JsonConvert.SerializeObject(value ?? new object(), Settings);

        public static T Deserialize<T>(string json) => string.IsNullOrEmpty(json) ? default : JsonConvert.DeserializeObject<T>(json, Settings);

        public static T Response<T>(string body)
        {
            if (string.IsNullOrWhiteSpace(body))
            {
                return default;
            }

            var token = JToken.Parse(body);
            var value = token.ToObject<T>(LenientSerializer);
            if (value is IRawResponse raw && token is JObject obj)
            {
                raw.Raw = obj;
            }

            return value;
        }
    }
}
