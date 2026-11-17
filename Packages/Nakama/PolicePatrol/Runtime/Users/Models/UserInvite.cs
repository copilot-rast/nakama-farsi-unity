using System;

namespace PolicePatrol.Sdk.Users
{
    public sealed record UserInvite(string Id, string UserId, string InviterId, string InviteCode, int InvitedCount, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
}
