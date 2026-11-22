using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Stages;

namespace PolicePatrol.Sdk.Inventory
{
    public sealed class PartProfile : SettingsBag
    {
        public PartProfile(JObject raw, Func<string, string> toGame = null) : base(raw)
        {
            toGame = toGame ?? (k => k);
            CarKey = toGame(Str("carKey"));
            Parameters = (Raw["parameters"] as JObject ?? new JObject()).Properties().ToDictionary(p => p.Name, p => p.Value, StringComparer.Ordinal);
            ConstParameters = (Raw["constParameters"] as JObject ?? new JObject()).Properties()
                .ToDictionary(p => p.Name, p => p.Value.Type == JTokenType.String ? (string)p.Value : p.Value.ToString(Newtonsoft.Json.Formatting.None), StringComparer.Ordinal);
            Requires = Strings("requires").Select(toGame).ToArray();
        }

        public string Car => Str("car");

        public string CarKey { get; }

        public string CardId => Str("cardId");

        public string CollectionId => Str("collectionId");

        public string Slot => Str("slot");

        public string SlotName => Str("slotName");

        public string Group => Str("group");

        public int Level => (int)(Num("level") ?? 0);

        public double Health => Num("health") ?? 0;

        public double Expire => Num("expire") ?? 0;

        public bool Sellable => Flag("sellable") ?? false;

        public string[] Tags => Strings("tags");

        public string[] Requires { get; }

        public IReadOnlyDictionary<string, JToken> Parameters { get; }

        public IReadOnlyDictionary<string, string> ConstParameters { get; }

        public string EquipSlot => string.IsNullOrEmpty(Slot) ? null : "part:" + (Str("carKey") ?? string.Empty) + ":" + Slot;

        public double? Parameter(string name) => Parameters.TryGetValue(name, out var v) && (v.Type == JTokenType.Integer || v.Type == JTokenType.Float) ? (double?)(double)v : null;
    }
}
