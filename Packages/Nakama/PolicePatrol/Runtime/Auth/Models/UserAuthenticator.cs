using System;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Auth
{
    public sealed record UserAuthenticator(
        string Id,
        string ProviderType,
        string ProviderUserId,
        string ProviderEmail,
        bool HasAccessToken,
        JToken Data,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
}
