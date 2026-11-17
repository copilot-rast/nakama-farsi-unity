using System;

namespace PolicePatrol.Sdk.Users
{
    public sealed record PublicProfile(string Id, string Username, string Name, string LastName, string AvatarId, string Country, bool IsGuest, DateTimeOffset CreatedAt);
}
