namespace PolicePatrol.Sdk.Stages
{
    public sealed record PlayerProgress(long Xp, int Level, long? NextLevelXp, PlayerChapter[] Chapters);
}
