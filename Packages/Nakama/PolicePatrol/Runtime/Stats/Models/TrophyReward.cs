using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Stats
{
    public sealed record TrophyReward(IReadOnlyDictionary<string, long> Currencies, string PrizeKey, string PrizeGroupKey)
    {
        public static readonly TrophyReward None = new TrophyReward(new Dictionary<string, long>(), null, null);

        public bool IsEmpty => (Currencies == null || Currencies.Count == 0) && string.IsNullOrEmpty(PrizeKey) && string.IsNullOrEmpty(PrizeGroupKey);

        internal static TrophyReward From(JToken t)
        {
            if (!(t is JObject o))
            {
                return None;
            }

            var currencies = (o["currencies"] as JObject)?.Properties()
                .Where(p => p.Value.Type == JTokenType.Integer || p.Value.Type == JTokenType.Float)
                .ToDictionary(p => p.Name, p => (long)(double)p.Value) ?? new Dictionary<string, long>();
            var prize = J.Str(o, "prizeKey");
            var group = J.Str(o, "prizeGroupKey");
            return new TrophyReward(currencies, string.IsNullOrEmpty(prize) ? null : prize, string.IsNullOrEmpty(group) ? null : group);
        }
    }
}
