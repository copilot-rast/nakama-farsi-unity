using System;
using System.Threading.Tasks;
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

        [Obsolete("Use VerifyPhoneChangeStep. When the panel asks for a code to the old number first, the first code only opens the second step; this method then fails with PHONE_NEW_CODE_SENT.")]
        public static void VerifyPhoneChange(string code, Action<ApiResult<CurrentUser>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var step = await PhoneChangeStepOf(c, code).ConfigureAwait(false);
                if (!step.Done)
                {
                    throw new SdkFailure(new ApiError(200, ApiError.PhoneNewCodeSentCode, new JObject { ["stage"] = step.Stage, ["codeSentTo"] = step.NextChallenge?.SentTo },
                        "The code of the old number was right; a code was sent to the new number"));
                }

                return step.User;
            }, null, "verify phone change");

        public static void VerifyPhoneChangeStep(string code, Action<ApiResult<PhoneChangeStep>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, c => PhoneChangeStepOf(c, code), null, "verify phone change");

        private static async Task<PhoneChangeStep> PhoneChangeStepOf(ApiClient c, string code)
        {
            var answer = await c.Rpc("account_phone_verify", new JObject { ["code"] = code, ["lang"] = c.Language }, false).ConfigureAwait(false);
            if (J.Bool(answer, "done"))
            {
                var user = answer["profile"] is JObject profile ? Mapping.User(profile) : await Me(c).ConfigureAwait(false);
                return new PhoneChangeStep(true, null, null, user);
            }

            return new PhoneChangeStep(false, J.Str(answer, "stage") ?? PhoneChangeStep.StageNew, Mapping.Challenge(answer, DateTimeOffset.UtcNow), null);
        }
    }
}
