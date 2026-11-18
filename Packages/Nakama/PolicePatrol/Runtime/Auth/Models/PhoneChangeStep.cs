using PolicePatrol.Sdk.Users;

namespace PolicePatrol.Sdk.Auth
{
    public sealed record PhoneChangeStep(bool Done, string Stage, OtpChallenge NextChallenge, CurrentUser User)
    {
        public const string StageOld = "old";
        public const string StageNew = "new";

        public bool WaitingForNewPhoneCode => !Done && Stage == StageNew;
    }
}
