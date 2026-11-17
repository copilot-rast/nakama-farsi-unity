using System;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Assets
{
    public interface IAssetReferenceHandler
    {
        bool IsReference(Type type);

        JToken Write(object value);

        bool TryRead(JToken token, Type type, object current, out object value);
    }
}
