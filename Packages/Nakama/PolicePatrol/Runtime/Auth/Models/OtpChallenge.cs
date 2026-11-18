using System;

namespace PolicePatrol.Sdk.Auth
{
    public sealed record OtpChallenge(OtpChannel Channel, DateTimeOffset? CanResendAt)
    {
        public string Stage { get; init; }

        public string SentTo { get; init; }

        public TimeSpan WaitBeforeResend(DateTimeOffset now) =>
            CanResendAt.HasValue && CanResendAt.Value > now ? CanResendAt.Value - now : TimeSpan.Zero;
    }
}
