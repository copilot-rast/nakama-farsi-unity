using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class ShopCardScan
    {
        public JArray Items { get; } = new JArray();

        public List<string> Problems { get; } = new List<string>();

        public List<string> Warnings { get; } = new List<string>();
    }
}
