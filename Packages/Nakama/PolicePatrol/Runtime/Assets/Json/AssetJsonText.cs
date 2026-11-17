using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Assets
{
    public static class AssetJsonText
    {
        public static JToken ParseExact(string json)
        {
            try
            {
                return Read(json, FloatParseHandling.Decimal);
            }
            catch (JsonReaderException)
            {
                return Read(json, FloatParseHandling.Double);
            }
        }

        private static JToken Read(string json, FloatParseHandling floats)
        {
            using (var reader = new JsonTextReader(new StringReader(json)) { FloatParseHandling = floats, DateParseHandling = DateParseHandling.None })
            {
                return JToken.ReadFrom(reader);
            }
        }
    }
}
