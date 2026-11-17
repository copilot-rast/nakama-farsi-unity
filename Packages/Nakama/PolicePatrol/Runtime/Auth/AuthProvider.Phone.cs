using System;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Users;

namespace PolicePatrol.Sdk.Auth
{
    public static partial class AuthProvider
    {
        public static void RequestPhoneChange(string newPhoneNumber, Action<ApiResult<OtpChallenge>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var answer = await c.Rpc("account_phone_request", new JObject { ["phone"] = newPhoneNumber, ["lang"] = c.Language }, false).ConfigureAwait(false);
                return Mapping.Challenge(answer, DateTimeOffset.UtcNow);
            }, null, "phone change");

        public static void VerifyPhoneChange(string code, Action<ApiResult<CurrentUser>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var answer = await c.Rpc("account_phone_verify", new JObject { ["code"] = code, ["lang"] = c.Language }, false).ConfigureAwait(false);
                if (J.Bool(answer, "done") && answer["profile"] is JObject profile)
                {
                    return Mapping.User(profile);
                }

                return await Me(c).ConfigureAwait(false);
            }, null, "verify phone change");
    }
}
