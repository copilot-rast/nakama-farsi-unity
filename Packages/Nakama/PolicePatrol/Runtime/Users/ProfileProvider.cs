using System;
using System.Threading.Tasks;
using Nakama;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Auth;
using NF = NakamaFarsi.Sdk;

namespace PolicePatrol.Sdk.Users
{
    public static class ProfileProvider
    {
        public static void GetMe(Action<ApiResult<CurrentUser>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, AuthProvider.Me, null, "account_me");

        public static void Update(string name, string lastName, DateTime? born, JToken metadata, Action<ApiResult<CurrentUser>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var display = string.Join(" ", new[] { name, lastName }).Trim();
                await Account(c, s => c.Core.Client.UpdateAccountAsync(s, null, display)).ConfigureAwait(false);
                return await AuthProvider.Me(c).ConfigureAwait(false);
            }, null, "update profile");

        public static void SetDeviceId(string deviceId, Action<ApiResult<CurrentUser>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                await Account(c, s => c.Core.Client.LinkDeviceAsync(s, deviceId)).ConfigureAwait(false);
                return await AuthProvider.Me(c).ConfigureAwait(false);
            }, null, "link device");

        public static void SetFirebaseId(string firebaseId, Action<ApiResult<CurrentUser>> onComplete) =>
            onComplete?.Invoke(ApiResult<CurrentUser>.Fail(ApiError.NotSupported("Firebase id")));

        public static void SetLanguage(string languageId, Action<ApiResult<CurrentUser>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                await c.Rpc("base_set_language", new JObject { ["lang"] = languageId }, false).ConfigureAwait(false);
                return await AuthProvider.Me(c).ConfigureAwait(false);
            }, null, "set language");

        public static void AccountRules(Action<ApiResult<AccountRules>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var r = await c.Rpc("account_rules", new JObject(), true).ConfigureAwait(false);
                return new AccountRules(J.Int(r, "usernameMin", 3), J.Int(r, "usernameMax", 20), J.Int(r, "passwordMin", 7), J.Int(r, "passwordMax", 72));
            }, null, "account_rules");

        public static void SetUsername(string username, Action<ApiResult<CurrentUser>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                await Account(c, s => c.Core.Client.UpdateAccountAsync(s, username?.Trim())).ConfigureAwait(false);
                var me = await AuthProvider.Me(c).ConfigureAwait(false);
                return me with { Username = me.Username ?? username?.Trim(), HasUsername = true };
            }, null, "set username");

        public static void GetPublic(string userId, Action<ApiResult<PublicProfile>> onComplete) =>
            onComplete?.Invoke(ApiResult<PublicProfile>.Fail(ApiError.NotSupported("Public profile (use the social plugin)")));

        private static async Task Account(ApiClient c, Func<ISession, Task> call)
        {
            var session = await c.Core.Session.EnsureAsync().ConfigureAwait(false);
            try
            {
                await call(session).ConfigureAwait(false);
            }
            catch (ApiResponseException e)
            {
                throw new NF.ApiException(NF.ErrorParser.Parse(e.Message, e.StatusCode, c.Core.Errors, c.Language), e);
            }
            catch (Exception e) when (!(e is NF.ApiException))
            {
                throw new NF.ApiException(NF.ApiError.Network(e.Message), e);
            }
        }
    }
}
