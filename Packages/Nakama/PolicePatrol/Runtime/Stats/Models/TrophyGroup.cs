namespace PolicePatrol.Sdk.Stats
{
    public sealed record TrophyGroup(string Key, string Name, string Description, string IconUrl, int Unlocked, int StepCount, TrophyInfo[] Trophies);
}
