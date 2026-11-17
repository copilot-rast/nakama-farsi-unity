using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class StatCardScan
    {
        public JArray Stats { get; } = new JArray();

        public JArray Goals { get; } = new JArray();

        public List<string> Problems { get; } = new List<string>();
    }
}
