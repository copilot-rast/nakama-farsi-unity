using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class AssetRoutingChange
    {
        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("before")]
        public JToken Before { get; set; }

        [JsonProperty("after")]
        public JToken After { get; set; }
    }

    public sealed class AssetRoutingRow
    {
        [JsonProperty("assetId")]
        public string AssetId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("itemKey")]
        public string ItemKey { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("parents")]
        public string[] Parents { get; set; } = Array.Empty<string>();

        [JsonProperty("changes")]
        public AssetRoutingChange[] Changes { get; set; } = Array.Empty<AssetRoutingChange>();
    }

    public static class AssetRoutingActions
    {
        public const string Created = "created";
        public const string Updated = "updated";
        public const string Linked = "linked";
        public const string Unchanged = "unchanged";
        public const string Pending = "pending";
        public const string Deactivated = "deactivated";
        public const string Dependency = "dependency";
        public const string Stored = "stored";
        public const string Skipped = "skipped";
        public const string Error = "error";
    }

    public sealed class AssetRouting
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("dryRun")]
        public bool DryRun { get; set; }

        [JsonProperty("summary")]
        public Dictionary<string, int> Summary { get; set; } = new Dictionary<string, int>();

        [JsonProperty("rows")]
        public AssetRoutingRow[] Rows { get; set; } = Array.Empty<AssetRoutingRow>();

        [JsonProperty("runId")]
        public long? RunId { get; set; }

        [JsonIgnore]
        public AssetRoutingRow[] Pending => With(AssetRoutingActions.Pending);

        [JsonIgnore]
        public AssetRoutingRow[] Skipped => With(AssetRoutingActions.Skipped, AssetRoutingActions.Deactivated);

        [JsonIgnore]
        public AssetRoutingRow[] Errors => With(AssetRoutingActions.Error);

        [JsonIgnore]
        public AssetRoutingRow[] Items => (Rows ?? Array.Empty<AssetRoutingRow>()).Where(r => !string.IsNullOrEmpty(r.Kind)).ToArray();

        public AssetRoutingRow[] With(params string[] actions) => (Rows ?? Array.Empty<AssetRoutingRow>()).Where(r => actions.Contains(r.Action)).ToArray();

        public int Count(string action) => Summary != null && Summary.TryGetValue(action, out var n) ? n : 0;

        public static AssetRouting Merge(IEnumerable<AssetRouting> parts)
        {
            var list = (parts ?? Enumerable.Empty<AssetRouting>()).Where(p => p != null).ToList();
            if (list.Count == 0)
            {
                return null;
            }

            var summary = new Dictionary<string, int>(StringComparer.Ordinal);
            foreach (var kv in list.SelectMany(p => p.Summary ?? new Dictionary<string, int>()))
            {
                summary[kv.Key] = (summary.TryGetValue(kv.Key, out var n) ? n : 0) + kv.Value;
            }

            return new AssetRouting
            {
                Enabled = list.Any(p => p.Enabled),
                DryRun = list.All(p => p.DryRun),
                Summary = summary,
                Rows = list.SelectMany(p => p.Rows ?? Array.Empty<AssetRoutingRow>()).ToArray(),
                RunId = list.Select(p => p.RunId).LastOrDefault(id => id.HasValue),
            };
        }

        public string Describe()
        {
            var parts = (Summary ?? new Dictionary<string, int>()).OrderBy(kv => kv.Key, StringComparer.Ordinal).Select(kv => kv.Value + " " + kv.Key);
            return "Routing" + (DryRun ? " (dry run)" : string.Empty) + ": " + string.Join(", ", parts) + ".";
        }
    }
}
