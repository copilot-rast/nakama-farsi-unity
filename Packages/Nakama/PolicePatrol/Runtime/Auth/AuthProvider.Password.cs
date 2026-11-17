using System;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Auth
{
    public static partial class AuthProvider
    {
        public static void ForgotPassword(string phoneNumber, Action<ApiResult<OtpChallenge>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var answer = await c.Rpc("account_password_forgot", new JObject { ["phone"] = phoneNumber, ["lang"] = c.Language }, false, false, true).ConfigureAwait(false);
                c.VerificationToken = J.Str(answer, "phone") ?? phoneNumber;
                c.VerificationPurpose = PurposeReset;
                return Mapping.Challenge(answer, DateTimeOffset.UtcNow);
            }, null, "forgot password");

        public static void ResetPassword(string code, string newPassword, Action<ApiResult<LoginResponse>> onComplete)
        {
            if (!PolicePatrolSdk.TryGetClient(onComplete, out var client))
            {
                return;
            }

            if (string.IsNullOrEmpty(client.VerificationToken) || client.VerificationPurpose != PurposeReset)
            {
                onComplete?.Invoke(ApiResult<LoginResponse>.Fail(ApiError.OtpNotRequested));
                return;
            }

            client.Run(async () =>
            {
                var answer = await client.Rpc("account_password_reset", new JObject
                {
                    ["phone"] = client.VerificationToken, ["code"] = code, ["newPassword"] = newPassword, ["lang"] = client.Language,
                }, false, false, true).ConfigureAwait(false);
                client.VerificationToken = null;
                client.VerificationPurpose = null;
                return await SignIn(client, answer).ConfigureAwait(false);
            }, onComplete, null, "reset password");
        }

        public static void SetPassword(string newPassword, Action<ApiResult<OkResponse>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                await c.Rpc("account_password_set", new JObject { ["newPassword"] = newPassword }, false).ConfigureAwait(false);
                return new OkResponse(true);
            }, null, "set password");

        public static void UpdatePassword(string currentPassword, string newPassword, Action<ApiResult<OkResponse>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                await c.Rpc("account_password_change", new JObject { ["currentPassword"] = currentPassword, ["newPassword"] = newPassword }, false).ConfigureAwait(false);
                return new OkResponse(true);
            }, null, "update password");
    }
}
