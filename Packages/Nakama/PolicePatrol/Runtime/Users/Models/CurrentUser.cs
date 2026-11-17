using System;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Users
{
    public sealed record CurrentUser(
        string Id,
        string Username,
        bool HasUsername,
        string PhoneNumber,
        bool PhoneNumberVerified,
        string DeviceId,
        string FirebaseId,
        string LanguageId,
        bool IsGuest,
        string InviterId,
        string ReferralCode,
        string Name,
        string LastName,
        string Born,
        string Gender,
        string AvatarId,
        string Country,
        JToken Metadata,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
