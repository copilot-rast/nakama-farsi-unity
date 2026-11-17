using System;

namespace PolicePatrol.Sdk.Economy
{
    public sealed record UserAchievement(
        string Id,
        string UserId,
        string AchievementId,
        Achievement Achievement,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
