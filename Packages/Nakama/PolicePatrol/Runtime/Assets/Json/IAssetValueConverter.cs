using System;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Assets
{
    public interface IAssetValueConverter
    {
        bool CanConvert(Type type);

        JToken Write(object value);

        object Read(JToken token, Type type, object current);
    }
}
