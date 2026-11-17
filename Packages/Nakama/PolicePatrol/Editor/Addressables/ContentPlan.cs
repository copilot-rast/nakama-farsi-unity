using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class ContentPlan
    {
        public ContentPlan(IReadOnlyList<string> missing, int reusedCount, long reusedBytes)
        {
            Missing = missing;
            ReusedCount = reusedCount;
            ReusedBytes = reusedBytes;
        }

        public IReadOnlyList<string> Missing { get; }

        public int ReusedCount { get; }

        public long ReusedBytes { get; }

        public string PackId { get; set; }

        public long PartBytes { get; set; }

        public IReadOnlyList<JObject> Parts { get; set; } = new List<JObject>();
    }
}
