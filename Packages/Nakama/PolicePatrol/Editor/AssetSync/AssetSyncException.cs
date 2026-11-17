using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class AssetSyncException : Exception
    {
        public AssetSyncException(int status, string code, JToken meta)
            : base(Describe(status, code, meta))
        {
            Status = status;
            Code = code;
            Meta = meta;
        }

        public int Status { get; }

        public string Code { get; }

        public JToken Meta { get; }

        public static AssetSyncException From(int status, string body)
        {
            JObject json = null;
            try
            {
                json = JObject.Parse(body);
            }
            catch (Newtonsoft.Json.JsonException)
            {
            }

            return new AssetSyncException(status, (string)json?["code"] ?? "HTTP_" + status, json?["meta"]);
        }

        private static string Describe(int status, string code, JToken meta)
        {
            switch (code)
            {
                case "ASSET_ID_DUPLICATED":
                    var duplicates = (meta?["duplicates"] as JArray ?? new JArray()).Select(d =>
                        "• id \"" + d["assetId"] + "\": " + string.Join(" and ", (d["assets"] as JArray ?? new JArray()).Select(a =>
                            a["folder"] + "/" + a["name"] + ((bool?)a["onServer"] == true ? " (on the server)" : string.Empty))));
                    return "Two assets use the same id. Change the id of one of them:\n" + string.Join("\n", duplicates);
                case "ASSET_SOURCE_ID_CHANGED":
                    var changes = (meta?["changes"] as JArray ?? new JArray()).Select(c =>
                        "• " + c["folder"] + "/" + c["name"] + " was pushed before as \"" + c["previousAssetId"] + "\", now \"" + c["assetId"] + "\"");
                    return "A file's id changed. Delete the old id on the server (Delete server-only) in the same push:\n" + string.Join("\n", changes);
                case "ASSET_VERSION_CONFLICT":
                    var conflicts = (meta?["conflicts"] as JArray ?? new JArray()).Select(c => (string)c["assetId"]).Take(20);
                    return "Someone changed these on the server after your last sync. Compare again and pull them first:\n" + string.Join(", ", conflicts);
                case "ASSET_DELETE_NOT_ALLOWED":
                    return "This API key cannot delete assets. Give it the Assets → delete feature in the panel.";
                default:
                    if (status == 401)
                    {
                        return "The API key is wrong, expired or revoked.";
                    }

                    if (status == 403)
                    {
                        return "This API key has no access to assets. Give it the Assets feature (view, create, edit) in the panel.";
                    }

                    return "The server refused the request: " + code + (meta != null && meta.Type != JTokenType.Null ? " " + meta.ToString(Newtonsoft.Json.Formatting.None) : string.Empty);
            }
        }
    }
}
