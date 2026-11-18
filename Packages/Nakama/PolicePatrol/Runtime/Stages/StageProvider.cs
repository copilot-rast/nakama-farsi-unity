using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Stats;

namespace PolicePatrol.Sdk.Stages
{
    public static class StageProvider
    {
        public const string FreeRideChapterKey = "freeride";
        private const string FreeRidePrefix = "freeride:";
        private static readonly ConcurrentDictionary<string, bool> FreeRide = new ConcurrentDictionary<string, bool>(StringComparer.Ordinal);

        public static void Get(Action<ApiResult<PlayerProgress>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, Load, ErrorAliases.Stages, "campaign_chapters");

        public static void Start(string stageKey, Action<ApiResult<StageAttempt>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                if (await IsFreeRide(c, stageKey).ConfigureAwait(false))
                {
                    var now = DateTimeOffset.UtcNow;
                    return new StageAttempt(FreeRidePrefix + Guid.NewGuid().ToString("N"), stageKey, now, now.AddHours(24));
                }

                var a = await c.Rpc("campaign_attempt_start", new JObject { ["stageKey"] = stageKey }, false).ConfigureAwait(false);
                return new StageAttempt(J.Str(a, "attemptId"), J.Str(a, "stageKey") ?? stageKey, J.TimeOr(a, "startedAt"), J.TimeOr(a, "expiresAt"));
            }, ErrorAliases.Stages, "campaign_attempt_start");

        public static void Complete(string stageKey, string attemptId, bool success, double elapsedSeconds, double? healthPercent, Action<ApiResult<StageResult>> onComplete) =>
            Complete(stageKey, attemptId, success, elapsedSeconds, healthPercent, null, onComplete);

        public static void Complete(
            string stageKey,
            string attemptId,
            bool success,
            double elapsedSeconds,
            double? healthPercent,
            IDictionary<string, object> fields,
            Action<ApiResult<StageResult>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                if (attemptId != null && attemptId.StartsWith(FreeRidePrefix, StringComparison.Ordinal))
                {
                    if (!success)
                    {
                        return new StageResult(stageKey, false, 0, 0, Array.Empty<GrantedReward>(), 0, 0, 0, false, null, Array.Empty<GrantedReward>(), null, Array.Empty<Trophy>());
                    }

                    JToken f;
                    try
                    {
                        f = await c.Rpc("campaign_freeride_claim", new JObject { ["key"] = stageKey, ["requestId"] = attemptId.Substring(FreeRidePrefix.Length), ["lang"] = c.Language }, false, true).ConfigureAwait(false);
                    }
                    catch (NakamaFarsi.Sdk.ApiException e) when (e.Error.Code == StageErrorCodes.RewardLimitedCode)
                    {
                        var meta = e.Error.Meta ?? new JObject();
                        return new StageResult(stageKey, true, 0, 0, Array.Empty<GrantedReward>(), 0, 0, 0, false, null, Array.Empty<GrantedReward>(), J.Str(meta, "reason") ?? StageErrorCodes.LimitedCooldown, Array.Empty<Trophy>())
                        {
                            NextRewardAt = J.Time(meta, "nextRewardAt"),
                            RewardsLeftToday = (int?)J.NumOrNull(meta, "rewardsLeftToday"),
                        };
                    }

                    return Result(stageKey, true, f);
                }

                var body = new JObject { ["stageKey"] = stageKey, ["attemptId"] = attemptId, ["success"] = success, ["elapsedSeconds"] = elapsedSeconds, ["lang"] = c.Language };
                if (healthPercent.HasValue)
                {
                    body["healthPercent"] = healthPercent.Value;
                }

                if (fields != null && fields.Count > 0)
                {
                    body["fields"] = JObject.FromObject(fields);
                }

                var r = await c.Rpc("campaign_attempt_complete", body, false, true).ConfigureAwait(false);
                return Result(stageKey, success, r);
            }, ErrorAliases.Stages, "campaign_attempt_complete");

        private static async Task<bool> IsFreeRide(ApiClient c, string key)
        {
            if (FreeRide.TryGetValue(key ?? string.Empty, out var known))
            {
                return known;
            }

            try
            {
                await Load(c).ConfigureAwait(false);
            }
            catch (Exception)
            {
                return false;
            }

            return FreeRide.TryGetValue(key ?? string.Empty, out known) && known;
        }

        internal static async Task<PlayerProgress> Load(ApiClient c)
        {
            var r = await c.Rpc("campaign_chapters", new JObject { ["lang"] = c.Language }, true).ConfigureAwait(false);
            var chapters = Mapping.Arr(r, "chapters").Select((ch, i) => Chapter(ch, i)).ToList();
            var free = Mapping.Arr(r, "freeride").ToList();
            foreach (var s in chapters.SelectMany(ch => ch.Stages))
            {
                FreeRide[s.Key] = false;
            }

            if (free.Count > 0)
            {
                var stages = free.Select((f, i) =>
                {
                    FreeRide[J.Str(f, "key")] = true;
                    return new PlayerStage(J.Str(f, "key"), J.Str(f, "name"), i, FreeRideChapterKey, true, 0, 0, Rewards(f, "rewards"), J.Int(f, "xp"), null,
                        J.Str(f, "rewardGroup"), J.Int(f, "cooldownSeconds"), J.Int(f, "dailyRewardLimit"), J.Time(f, "nextRewardAt"), (int?)J.NumOrNull(f, "rewardsLeftToday"));
                }).ToArray();
                chapters.Add(new PlayerChapter(FreeRideChapterKey, "Free ride", chapters.Count, true, 0, 0, Array.Empty<PlayerMilestone>(), stages));
            }

            return new PlayerProgress(J.Long(r, "xp"), J.Int(r, "level"), (long?)J.NumOrNull(r, "nextLevelXp"), chapters.ToArray());
        }

        private static PlayerChapter Chapter(JToken ch, int index)
        {
            var levelLock = Mapping.Arr(ch, "locks").FirstOrDefault(l => J.Str(l, "type") == "level");
            var stages = Mapping.Arr(ch, "stages").Select((s, i) => new PlayerStage(
                J.Str(s, "key"), J.Str(s, "name"), J.Int(s, "sort", i), J.Str(s, "mode"), J.Bool(s, "unlocked"), J.Int(s, "bestStars"), J.Int(s, "completions"),
                Rewards(s, "rewards"), J.Int(s, "xp"), J.NumOrNull(s, "timeLimitSeconds"), J.Str(s, "rewardGroup"), J.Int(s, "cooldownSeconds"),
                J.Int(s, "dailyRewardLimit"), J.Time(s, "nextRewardAt"), (int?)J.NumOrNull(s, "rewardsLeftToday"))).ToArray();
            var milestones = Mapping.Arr(ch, "milestones").Select(m => new PlayerMilestone(J.Num(m, "percent"), Rewards(m, "rewards"), J.Bool(m, "claimed"))).ToArray();
            return new PlayerChapter(J.Str(ch, "key"), J.Str(ch, "name"), J.Int(ch, "sort", index), J.Bool(ch, "unlocked"), levelLock == null ? 0 : J.Int(levelLock, "value"), J.Num(ch, "starPercent"), milestones, stages);
        }

        private static StageReward[] Rewards(JToken t, string name) => Mapping.Each(t, name, x => new StageReward(Mapping.CurrencyKey(x), Mapping.Amount(x)));

        private static GrantedReward[] Granted(JToken t, string name) => Mapping.Each(t, name, x => new GrantedReward(Mapping.CurrencyKey(x), Mapping.CurrencyKey(x), Mapping.Amount(x)));

        internal static Trophy[] Trophies(JToken t) => Mapping.Each(t, "trophies", u =>
        {
            var step = J.Str(u, "stepName");
            var name = J.Str(u, "trophyName") ?? J.Str(u, "trophyKey");
            return new Trophy(J.Str(u, "trophyKey"), string.IsNullOrEmpty(step) || J.Int(u, "stepCount") <= 1 ? name : name + " · " + step, step, J.Str(u?["rewards"], "prizeKey"));
        });

        private static StageResult Result(string stageKey, bool success, JToken r)
        {
            var levels = r?["levels"] as JArray;
            var leveledUp = levels != null && levels.Any(l => J.Int(l, "to") > J.Int(l, "from"));
            var limited = r?["rewardLimited"];
            string limitedText = limited == null || limited.Type == JTokenType.Null || (limited.Type == JTokenType.Boolean && !(bool)limited) ? null
                : limited.Type == JTokenType.String ? (string)limited : StageErrorCodes.LimitedDaily;
            return new StageResult(
                J.Str(r, "stageKey") ?? J.Str(r, "key") ?? stageKey,
                J.Bool(r, "success", success),
                J.Int(r, "stars"),
                J.Int(r, "bestStars"),
                Granted(r, "rewards"),
                J.Int(r, "xpGained"),
                J.Long(r, "xp"),
                J.Int(r, "level"),
                leveledUp,
                (long?)J.NumOrNull(r, "nextLevelXp"),
                Granted(r, "milestoneRewards"),
                limitedText,
                Trophies(r))
            {
                NextRewardAt = J.Time(r, "nextRewardAt"),
                RewardsLeftToday = (int?)J.NumOrNull(r, "rewardsLeftToday"),
            };
        }
    }
}
