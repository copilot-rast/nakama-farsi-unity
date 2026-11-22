using System.Linq;

namespace PolicePatrol.Sdk.Stats
{
    public sealed record TrophyPage(string ClaimMode, string UnlockOrder, TrophyGroup[] Groups, TrophyTotals Totals, TrophyUnlock[] Unlocked)
    {
        public TrophyInfo Find(string trophyKey) => Groups?.SelectMany(g => g.Trophies).FirstOrDefault(t => t.Key == trophyKey);

        public TrophyGroup Group(string groupKey) => Groups?.FirstOrDefault(g => g.Key == groupKey);
    }
}
