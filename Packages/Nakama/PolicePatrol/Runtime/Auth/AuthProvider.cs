using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Users;

namespace PolicePatrol.Sdk.Auth
{
    public static partial class AuthProvider
    {
        public static bool IsLoggedIn => PolicePatrolSdk.Client?.HasSession ?? false;

        public static void DeviceIdLogin(string deviceId, Action<ApiResult<LoginResponse>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var session = await c.Core.LoginWithDeviceAsync(deviceId).ConfigureAwait(false);
                return Mapping.Login(session);
            }, null, "device login");

        public static void Login(string username, string password, Action<ApiResult<LoginResponse>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var session = await c.Core.Session.AuthenticateEmailAsync(null, password, username, false).ConfigureAwait(false);
                c.Core.AfterLogin();
                return Mapping.Login(session);
            }, CredentialAliases, "login");

        public static void LoginWithPhone(string phoneNumber, string password, Action<ApiResult<LoginResponse>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var answer = await c.Rpc("account_password_login", new JObject { ["phone"] = phoneNumber, ["password"] = password, ["lang"] = c.Language }, false, false, true).ConfigureAwait(false);
                c.VerificationToken = null;
                c.VerificationPurpose = null;
                return await SignIn(c, answer).ConfigureAwait(false);
            }, null, "phone login");

        internal static readonly System.Collections.Generic.IReadOnlyDictionary<string, string> CredentialAliases = new System.Collections.Generic.Dictionary<string, string>
        {
            ["UNAUTHORIZED"] = "AUTH_INVALID_CREDENTIALS",
            ["NOT_FOUND"] = "AUTH_INVALID_CREDENTIALS",
        };

        internal static async Task<LoginResponse> SignIn(ApiClient c, JToken answer)
        {
            var token = J.Str(answer, "token");
            if (string.IsNullOrEmpty(token))
            {
                throw new SdkFailure(new ApiError(0, ApiError.InvalidResponseCode, answer, "the server sent no session"));
            }

            var loginKey = J.Str(answer, "loginKey");
            Nakama.ISession session;
            if (!string.IsNullOrEmpty(loginKey))
            {
                try
                {
                    session = await c.Core.Session.AuthenticateCustomAsync(loginKey, null, false).ConfigureAwait(false);
                }
                catch (NakamaFarsi.Sdk.ApiException)
                {
                    session = c.Core.Session.Adopt(token);
                }
            }
            else
            {
                session = c.Core.Session.Adopt(token);
            }

            c.Core.AfterLogin();
            return Mapping.Login(session);
        }

        public static void Signup(string username, string password, Action<ApiResult<LoginResponse>> onComplete) =>
            onComplete?.Invoke(ApiResult<LoginResponse>.Fail(ApiError.NotSupported("Username sign-up (Nakama needs an e-mail for a new password account)")));

        public static void SignupWithPhone(string phoneNumber, string password, Action<ApiResult<LoginResponse>> onComplete) =>
            onComplete?.Invoke(ApiResult<LoginResponse>.Fail(ApiError.NotSupported("Phone and password sign-up")));

        public static void Logout(Action<ApiResult<OkResponse>> onComplete = null) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                await c.Core.LogoutAsync().ConfigureAwait(false);
                c.VerificationToken = null;
                return new OkResponse(true);
            }, null, "logout");

        internal static async Task<CurrentUser> Me(ApiClient c)
        {
            var me = await c.Rpc("account_me", new JObject { ["lang"] = c.Language }, true).ConfigureAwait(false);
            return Mapping.User(me);
        }
    }
}
