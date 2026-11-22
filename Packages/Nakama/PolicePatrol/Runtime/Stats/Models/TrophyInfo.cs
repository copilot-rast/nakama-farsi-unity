using System.Linq;

namespace PolicePatrol.Sdk.Stats
{
    public sealed record TrophyInfo(
        string Key,
        string Name,
        string Description,
        string IconUrl,
        string ContextKey,
        string UnlockOrder,
        int Unlocked,
        int StepCount,
        bool Completed,
        TrophyStep[] Steps)
    {
        public TrophyStep NextStep => Steps?.FirstOrDefault(s => !s.Unlocked);

        public TrophyStep LastUnlocked => Steps?.LastOrDefault(s => s.Unlocked);

        public double Progress => Completed ? 1 : NextStep?.Progress ?? 0;

        public bool HasClaimable => Steps != null && Steps.Any(s => s.Claimable);
    }
}
