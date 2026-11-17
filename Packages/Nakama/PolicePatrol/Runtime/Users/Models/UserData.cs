using System;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Users
{
    public sealed record UserData(string Id, string Key, JToken Data, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt)
    {
        public T As<T>() => Data == null || Data.Type == JTokenType.Null ? default : Data.ToObject<T>(SdkJson.Serializer);
    }
}
