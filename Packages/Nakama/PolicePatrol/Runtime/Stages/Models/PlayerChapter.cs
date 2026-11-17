namespace PolicePatrol.Sdk.Stages
{
    public sealed record PlayerChapter(
        string Key,
        string Name,
        int Order,
        bool Unlocked,
        int UnlockLevel,
        double StarPercent,
        PlayerMilestone[] Milestones,
        PlayerStage[] Stages);
}
