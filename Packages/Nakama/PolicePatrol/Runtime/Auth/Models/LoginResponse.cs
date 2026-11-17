using System;

namespace PolicePatrol.Sdk.Auth
{
    public sealed record LoginResponse(
        string AccessToken,
        DateTimeOffset? AccessTokenExpiresAt,
        string RefreshToken,
        DateTimeOffset? RefreshTokenExpiresAt,
        DateTimeOffset? CanResendAt);
}
