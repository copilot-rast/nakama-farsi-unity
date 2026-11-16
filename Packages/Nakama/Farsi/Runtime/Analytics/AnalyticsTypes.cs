using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace NakamaFarsi.Sdk.Analytics
{
    public enum ProgressionStatus
    {
        Start,
        Complete,
        Fail,
    }

    public enum ResourceFlow
    {
        Source,
        Sink,
    }

    public enum ErrorSeverity
    {
        Debug,
        Info,
        Warning,
        Error,
        Critical,
    }

    public sealed class AnalyticsOptions
    {
        public string AppVersion { get; set; } = string.Empty;

        public string Platform { get; set; } = string.Empty;

        public string Build { get; set; } = string.Empty;

        public string Os { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public string Manufacturer { get; set; } = string.Empty;

        public int MaxQueuedEvents { get; set; } = 5000;

        public int DefaultSendIntervalSeconds { get; set; } = 60;

        public int DefaultMaxBatch { get; set; } = 50;

        public int DefaultSessionTimeoutSeconds { get; set; } = 30;

        public bool WarnUnknown { get; set; } = true;

        public int PersistEverySeconds { get; set; } = 2;
    }

    public sealed class AllowedValues
    {
        public string Key { get; set; }

        public string[] Values { get; set; } = Array.Empty<string>();

        public bool Allows(string value) => Values == null || Values.Length == 0 || Values.Contains(value, StringComparer.Ordinal);
    }

    public sealed class DesignRoot
    {
        public string Root { get; set; }

        public AllowedValues[] Levels { get; set; } = Array.Empty<AllowedValues>();
    }

    public sealed class AnalyticsConfig
    {
        public int MaxBatch { get; set; } = 50;

        public int SendIntervalSeconds { get; set; } = 60;

        public int SessionTimeoutSeconds { get; set; } = 30;

        public int MaxDimensions { get; set; } = 3;

        public AllowedValues[] Dimensions { get; set; } = Array.Empty<AllowedValues>();

        public AllowedValues[] ContextKeys { get; set; } = Array.Empty<AllowedValues>();

        public DesignRoot[] DesignRoots { get; set; } = Array.Empty<DesignRoot>();

        public string[] ResourceCurrencies { get; set; } = Array.Empty<string>();

        public string[] ResourceItemTypes { get; set; } = Array.Empty<string>();

        public string UnknownDesign { get; set; } = "flag";

        public string UnknownDimension { get; set; } = "flag";

        public string UnknownContext { get; set; } = "flag";

        public Dictionary<string, (string Kind, int SendIntervalSeconds)> Stats { get; set; } = new Dictionary<string, (string, int)>(StringComparer.Ordinal);

        public static AnalyticsConfig Parse(JObject json)
        {
            var c = new AnalyticsConfig();
            if (json == null)
            {
                return c;
            }

            c.MaxBatch = Int(json["maxBatch"], c.MaxBatch);
            c.SendIntervalSeconds = Int(json["sendIntervalSeconds"], c.SendIntervalSeconds);
            if (json["stats"] is JArray stats)
            {
                foreach (var s in stats.OfType<JObject>())
                {
                    var key = (string)s["key"];
                    if (!string.IsNullOrEmpty(key))
                    {
                        c.Stats[key] = ((string)s["kind"] ?? "sum", Int(s["sendIntervalSeconds"], c.SendIntervalSeconds));
                    }
                }
            }

            if (json["typed"] is JObject t)
            {
                c.MaxDimensions = Int(t["maxDimensions"], c.MaxDimensions);
                c.SessionTimeoutSeconds = Int(t["sessionTimeoutSeconds"], c.SessionTimeoutSeconds);
                c.Dimensions = Allowed(t["dimensions"]);
                c.ContextKeys = Allowed(t["contextKeys"]);
                c.DesignRoots = (t["designRoots"] as JArray ?? new JArray()).OfType<JObject>()
                    .Select(r => new DesignRoot { Root = (string)r["root"], Levels = Allowed(r["levels"], "name") })
                    .Where(r => !string.IsNullOrEmpty(r.Root)).ToArray();
                c.ResourceCurrencies = Strings(t["resourceCurrencies"]);
                c.ResourceItemTypes = Strings(t["resourceItemTypes"]);
                c.UnknownDesign = (string)t["unknownDesign"] ?? c.UnknownDesign;
                c.UnknownDimension = (string)t["unknownDimension"] ?? c.UnknownDimension;
                c.UnknownContext = (string)t["unknownContext"] ?? c.UnknownContext;
            }

            return c;
        }

        private static int Int(JToken t, int fallback) => t != null && (t.Type == JTokenType.Integer || t.Type == JTokenType.Float) && (int)t > 0 ? (int)t : fallback;

        private static string[] Strings(JToken t) => (t as JArray ?? new JArray()).Select(x => (string)x).Where(x => !string.IsNullOrEmpty(x)).ToArray();

        private static AllowedValues[] Allowed(JToken t, string keyName = "key") => (t as JArray ?? new JArray()).OfType<JObject>()
            .Select(o => new AllowedValues { Key = (string)o[keyName] ?? (string)o["key"], Values = Strings(o["values"]) })
            .Where(a => !string.IsNullOrEmpty(a.Key)).ToArray();
    }

    public sealed class TrackAnswer
    {
        public string BatchId { get; set; }

        public bool Duplicate { get; set; }

        public int Received { get; set; }

        public int Stored { get; set; }

        public int Flagged { get; set; }

        public int Rejected { get; set; }

        public JArray Results { get; set; } = new JArray();

        public JArray Stats { get; set; } = new JArray();

        public JArray Unlocked { get; set; } = new JArray();

        public JObject Raw { get; set; }

        public static TrackAnswer Parse(string json)
        {
            var o = string.IsNullOrWhiteSpace(json) ? new JObject() : JObject.Parse(json);
            return new TrackAnswer
            {
                BatchId = (string)o["batchId"],
                Duplicate = (bool?)o["duplicate"] ?? false,
                Received = (int?)o["received"] ?? 0,
                Stored = (int?)o["stored"] ?? 0,
                Flagged = (int?)o["flagged"] ?? 0,
                Rejected = (int?)o["rejected"] ?? 0,
                Results = o["results"] as JArray ?? new JArray(),
                Stats = o["stats"] as JArray ?? new JArray(),
                Unlocked = o["unlocked"] as JArray ?? new JArray(),
                Raw = o,
            };
        }
    }
}
