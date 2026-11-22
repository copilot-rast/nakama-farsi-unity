using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Stats
{
    public sealed record TrophyUnlock(
        string StepId,
        string TrophyKey,
        string TrophyName,
        string GroupKey,
        int Step,
        int StepCount,
        string StepName,
        string IconUrl,
        TrophyReward Rewards,
        string ClaimMode,
        string Status)
    {
        public const string NotificationType = "trophy_step";

        public bool Claimable => ClaimMode == TrophyClaimModes.Claim && (Status == TrophyClaimStatuses.Ready || Status == TrophyClaimStatuses.Failed);

        public string Title => string.IsNullOrEmpty(StepName) || StepCount <= 1 ? TrophyName ?? TrophyKey : (TrophyName ?? TrophyKey) + " · " + StepName;

        public static TrophyUnlock From(JToken u)
        {
            if (!(u is JObject))
            {
                return null;
            }

            var icon = J.Str(u, "iconUrl");
            return new TrophyUnlock(
                J.Str(u, "stepId"),
                J.Str(u, "trophyKey"),
                J.Str(u, "trophyName"),
                J.Str(u, "groupKey"),
                J.Int(u, "step"),
                J.Int(u, "stepCount"),
                J.Str(u, "stepName"),
                string.IsNullOrEmpty(icon) ? null : icon,
                TrophyReward.From(u["rewards"]),
                J.Str(u, "claimMode"),
                J.Str(u, "status"));
        }

        public static TrophyUnlock FromNotification(int code, JObject content, int expectedCode = StatsProvider.DefaultTrophyNotificationCode)
        {
            var type = J.Str(content, "type");
            if (type != null ? type != NotificationType : code != expectedCode)
            {
                return null;
            }

            return From(content);
        }

        internal static TrophyUnlock[] List(JToken t) =>
            t is JArray a ? a.Select(From).Where(x => x != null).ToArray() : Array.Empty<TrophyUnlock>();
    }
}
