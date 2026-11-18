using System;
using System.Linq;
using Nakama;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Auth;
using PolicePatrol.Sdk.Economy;
using PolicePatrol.Sdk.Users;

namespace PolicePatrol.Sdk
{
    internal static class Mapping
    {
        private static readonly System.Text.RegularExpressions.Regex AutoUsername = new System.Text.RegularExpressions.Regex("^[A-Za-z]{10}$");

        public static LoginResponse Login(ISession s) => new LoginResponse(
            s.AuthToken,
            DateTimeOffset.FromUnixTimeSeconds(s.ExpireTime),
            s.RefreshToken,
            string.IsNullOrEmpty(s.RefreshToken) ? (DateTimeOffset?)null : DateTimeOffset.FromUnixTimeSeconds(s.RefreshExpireTime),
            null);

        public static CurrentUser User(JToken me)
        {
            var username = J.Str(me, "username");
            var guest = J.Bool(me, "isGuest");
            var hasUsername = !string.IsNullOrEmpty(username) && !(guest && AutoUsername.IsMatch(username) && me?["usernameSet"]?.Type != JTokenType.Boolean)
                || J.Bool(me, "usernameSet");
            var created = J.TimeOr(me, "createdAt");
            return new CurrentUser(
                J.Str(me, "id"),
                hasUsername ? username : null,
                hasUsername,
                J.Str(me, "phone"),
                J.Bool(me, "phoneVerified"),
                J.Str(me, "deviceId"),
                null,
                J.Str(me, "lang"),
                guest,
                null,
                null,
                J.Str(me, "displayName"),
                null,
                null,
                null,
                null,
                J.Str(me, "location"),
                me,
                created,
                J.Time(me, "updatedAt") ?? created);
        }

        public static Currency Currency(string key, string name = null, string type = null) =>
            new Currency(key, name ?? key, type, key, null, Array.Empty<string>(), Array.Empty<string>(), 0, 0, null, null, null, null, false, DateTimeOffset.MinValue, DateTimeOffset.MinValue);

        public static UserCurrency UserCurrency(string userId, string key, double value, DateTimeOffset? at) =>
            new UserCurrency(key, userId, key, value, Currency(key), at ?? DateTimeOffset.MinValue, at ?? DateTimeOffset.MinValue);

        public static UserMeta UserMeta(string userId, string key, double value) =>
            new UserMeta(key, userId, key, value, new Meta(key, key, key, null, Array.Empty<string>(), Array.Empty<string>(), 0, null, null, null, null, null, true, DateTimeOffset.MinValue, DateTimeOffset.MinValue), DateTimeOffset.MinValue, DateTimeOffset.MinValue);

        public static OtpChallenge Challenge(JToken answer, DateTimeOffset now) =>
            new OtpChallenge(OtpChannel.Phone, answer?["resendAfter"] != null && answer["resendAfter"].Type == JTokenType.Integer ? now.AddSeconds((int)answer["resendAfter"]) : (DateTimeOffset?)null)
            {
                Stage = J.Str(answer, "stage"),
                SentTo = J.Str(answer, "codeSentTo", "phone"),
            };

        public static double Amount(JToken t) => J.NumOrNull(t, "amount") ?? J.Num(t, "value");

        public static string CurrencyKey(JToken t) => J.Str(t, "currencyKey", "currency", "currencyId", "key");

        public static JArray Arr(JToken t, string name) => t?[name] as JArray ?? new JArray();

        public static T[] Each<T>(JToken t, string name, Func<JToken, T> map) => Arr(t, name).Select(map).ToArray();
    }
}
