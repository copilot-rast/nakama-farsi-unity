using System;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Auth
{
    public static partial class AuthProvider
    {
        private const string PurposeLogin = "login";
        private const string PurposeRecover = "recover";
        private const string PurposeReset = "reset";

        public static bool HasPendingOtp => !string.IsNullOrEmpty(PolicePatrolSdk.Client?.VerificationToken);

        public static void RequestPhoneOtp(string phoneNumber, Action<ApiResult<OtpChallenge>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var recover = c.HasSession;
                var answer = recover
                    ? await c.Rpc("account_phone_recover_request", new JObject { ["phone"] = phoneNumber, ["lang"] = c.Language }, false).ConfigureAwait(false)
                    : await c.Rpc("publication_otp_request", new JObject { ["phone"] = phoneNumber, ["lang"] = c.Language }, false, false, true).ConfigureAwait(false);
                c.VerificationToken = J.Str(answer, "phone") ?? phoneNumber;
                c.VerificationPurpose = recover ? PurposeRecover : PurposeLogin;
                return Mapping.Challenge(answer, DateTimeOffset.UtcNow);
            }, null, "phone otp");

        public static void RequestEmailOtp(string email, Action<ApiResult<OtpChallenge>> onComplete) =>
            onComplete?.Invoke(ApiResult<OtpChallenge>.Fail(ApiError.NotSupported("E-mail codes")));

        public static void VerifyOtp(string code, OtpChannel channel, Action<ApiResult<LoginResponse>> onComplete, string deviceId = null)
        {
            if (!PolicePatrolSdk.TryGetClient(onComplete, out var client))
            {
                return;
            }

            if (string.IsNullOrEmpty(client.VerificationToken) || channel != OtpChannel.Phone || client.VerificationPurpose == PurposeReset)
            {
                onComplete?.Invoke(ApiResult<LoginResponse>.Fail(ApiError.OtpNotRequested));
                return;
            }

            client.Run(async () =>
            {
                JToken answer;
                if (client.VerificationPurpose == PurposeRecover)
                {
                    var body = new JObject { ["code"] = code, ["lang"] = client.Language };
                    if (!string.IsNullOrEmpty(deviceId))
                    {
                        body["deviceId"] = deviceId;
                    }

                    answer = await client.Rpc("account_phone_recover_verify", body, false).ConfigureAwait(false);
                }
                else
                {
                    answer = await client.Rpc("publication_otp_verify", new JObject { ["phone"] = client.VerificationToken, ["code"] = code }, false, false, true).ConfigureAwait(false);
                }

                client.VerificationToken = null;
                client.VerificationPurpose = null;
                var moved = answer?["devicesMoved"] as JArray;
                if (!string.IsNullOrEmpty(deviceId) && moved != null && moved.Count > 0 && !string.IsNullOrEmpty(J.Str(answer, "token")))
                {
                    var session = await client.Core.Session.AuthenticateDeviceAsync(deviceId, false).ConfigureAwait(false);
                    client.Core.AfterLogin();
                    return Mapping.Login(session);
                }

                return await SignIn(client, answer).ConfigureAwait(false);
            }, onComplete, null, "verify otp");
        }

        public static void ResendOtp(OtpChannel channel, Action<ApiResult<OtpChallenge>> onComplete)
        {
            var phone = PolicePatrolSdk.Client?.VerificationToken;
            if (string.IsNullOrEmpty(phone) || channel != OtpChannel.Phone)
            {
                onComplete?.Invoke(ApiResult<OtpChallenge>.Fail(PolicePatrolSdk.Client == null ? ApiError.NotInitialized : ApiError.OtpNotRequested));
                return;
            }

            if (PolicePatrolSdk.Client.VerificationPurpose == PurposeReset)
            {
                ForgotPassword(phone, onComplete);
                return;
            }

            RequestPhoneOtp(phone, onComplete);
        }
    }
}
