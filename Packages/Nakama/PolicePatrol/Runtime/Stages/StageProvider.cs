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
        public const string FreeRideRewardsChapterKey = "freeride-rewards";
        public const string FreeRideMode = "freeride";
        private const string FreeRidePrefix = "freeride:";
        private static readonly ConcurrentDictionary<string, bool> FreeRide = new ConcurrentDictionary<string, bool>(StringComparer.Ordinal);

        public static void Get(Action<ApiResult<PlayerProgress>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, Load, ErrorAliases.Stages, "campaign_chapters");

        public const string VehicleKeyParam = "vehicleKey";

        public static void Start(string stageKey, Action<ApiResult<StageAttempt>> onComplete) => Start(stageKey, null, onComplete);

        public static void Start(string stageKey, string vehicleKey, Action<ApiResult<StageAttempt>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                if (await IsFreeRide(c, stageKey).ConfigureAwait(false))
                {
                    var now = DateTimeOffset.UtcNow;
                    return new StageAttempt(FreeRidePrefix + Guid.NewGuid().ToString("N"), stageKey, now, now.AddHours(24));
                }

                var body = new JObject { ["stageKey"] = stageKey };
                if (!string.IsNullOrEmpty(vehicleKey))
                {
                    var key = c.Items.ToServer(vehicleKey);
                    body[VehicleKeyParam] = key;
                    body["itemKey"] = key;
                }

                var a = await c.Rpc("campaign_attempt_start", body, false).ConfigureAwait(false);
                return Attempt(c, a, stageKey);
            }, ErrorAliases.Stages, "campaign_attempt_start");

        internal static StageAttempt Attempt(ApiClient c, JToken a, string stageKey)
        {
            var item = a?["item"] as JObject;
            return new StageAttempt(J.Str(a, "attemptId"), J.Str(a, "stageKey") ?? stageKey, J.TimeOr(a, "startedAt"), J.TimeOr(a, "expiresAt"))
            {
                Item = item == null ? null : new StageItem(c.Items.ToGame(J.Str(item, "itemKey")), J.Str(item, "itemType")),
                TimeLimitSeconds = J.NumOrNull(a, "timeLimitSeconds"),
            };
        }

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

                    return Result(c, stageKey, true, f);
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
                return Result(c, stageKey, success, r);
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

            var level = J.Int(r, "level");
            if (free.Count > 0)
            {
                var stages = free.Select((f, i) =>
                {
                    FreeRide[J.Str(f, "key")] = true;
                    var minLevel = J.Int(f, "minLevel");
                    return new PlayerStage(J.Str(f, "key"), J.Str(f, "name"), i, FreeRideMode, level >= minLevel, 0, 0, Rewards(f, "rewards"), J.Int(f, "xp"), null,
                        J.Str(f, "rewardGroup"), J.Int(f, "cooldownSeconds"), J.Int(f, "dailyRewardLimit"), J.Time(f, "nextRewardAt"), (int?)J.NumOrNull(f, "rewardsLeftToday"))
                    {
                        MinLevel = minLevel,
                        ChapterKey = FreeRideRewardsChapterKey,
                        Description = J.Str(f, "description"),
                        IconUrl = Blank(J.Str(f, "iconUrl")),
                    };
                }).ToArray();
                var lowest = stages.Min(s => s.MinLevel);
                chapters.Add(new PlayerChapter(FreeRideRewardsChapterKey, "Free ride", chapters.Count, level >= lowest, lowest, 0, Array.Empty<PlayerMilestone>(), stages));
            }

            return new PlayerProgress(J.Long(r, "xp"), level, (long?)J.NumOrNull(r, "nextLevelXp"), chapters.ToArray())
            {
                MaxStars = J.Int(r, "maxStars"),
                ServerTime = J.Time(r, "serverTime"),
            };
        }

        internal static PlayerChapter Chapter(JToken ch, int index)
        {
            var chapterKey = J.Str(ch, "key");
            var levelLock = Mapping.Arr(ch, "locks").FirstOrDefault(l => J.Str(l, "type") == "level");
            var stages = Mapping.Arr(ch, "stages").Select((s, i) => Stage(s, i, chapterKey)).ToArray();
            var milestones = Mapping.Arr(ch, "milestones").Select(m => new PlayerMilestone(J.Num(m, "percent"), Rewards(m, "rewards"), J.Bool(m, "claimed"))
            {
                Id = Id(m?["id"]),
                Reached = J.Bool(m, "reached"),
                PrizeKey = Blank(J.Str(m, "prizeKey")),
                PrizeGroupKey = Blank(J.Str(m, "prizeGroupKey")),
            }).ToArray();
            return new PlayerChapter(chapterKey, J.Str(ch, "name"), J.Int(ch, "sort", index), J.Bool(ch, "unlocked"), levelLock == null ? 0 : J.Int(levelLock, "value"), J.Num(ch, "starPercent"), milestones, stages)
            {
                Description = J.Str(ch, "description"),
                IconUrl = Blank(J.Str(ch, "iconUrl")),
                Address = Blank(J.Str(ch, "address")),
                Metadata = ch?["metadata"] as JObject ?? new JObject(),
                Locks = Locks(ch),
                Stars = J.Int(ch, "stars"),
                MaxStars = J.Int(ch, "maxStars"),
                Settings = new ChapterSettings(ch?["settings"] as JObject),
            };
        }

        internal static PlayerStage Stage(JToken s, int i, string chapterKey) => new PlayerStage(
            J.Str(s, "key"), J.Str(s, "name"), J.Int(s, "sort", i), J.Str(s, "mode"), J.Bool(s, "unlocked"), J.Int(s, "bestStars"), J.Int(s, "completions"),
            Rewards(s, "rewards"), J.Int(s, "xp"), J.NumOrNull(s, "timeLimitSeconds"), J.Str(s, "rewardGroup"), J.Int(s, "cooldownSeconds"),
            J.Int(s, "dailyRewardLimit"), J.Time(s, "nextRewardAt"), (int?)J.NumOrNull(s, "rewardsLeftToday"))
        {
            ChapterKey = chapterKey,
            Description = J.Str(s, "description"),
            IconUrl = Blank(J.Str(s, "iconUrl")),
            Address = Blank(J.Str(s, "address")),
            Metadata = s?["metadata"] as JObject ?? new JObject(),
            Locks = Locks(s),
            Wins = J.Int(s, "wins"),
            BestSeconds = J.NumOrNull(s, "bestSeconds"),
            Claimed = Rewards(s, "claimed"),
            ClaimedXp = J.Int(s, "claimedXp"),
            StarMultipliers = Mapping.Arr(s, "starMultipliers").Where(x => x.Type == JTokenType.Integer || x.Type == JTokenType.Float).Select(x => (double)x).ToArray(),
            StarRules = StarRules(s),
            StarTemplate = Blank(J.Str(s, "starTemplate")),
            MinSeconds = J.NumOrNull(s, "minSeconds"),
            NoReplayAfterWin = J.Bool(s, "noReplayAfterWin"),
            Replayable = J.Bool(s, "replayable", true),
            Settings = new StageSettings(s?["settings"] as JObject),
        };

        internal static StarRule[] StarRules(JToken t) => Mapping.Each(t, "starRules", r => new StarRule(
            J.Int(r, "stars"),
            Mapping.Each(r, "conditions", x => new StageCondition(J.Str(x, "field"), J.Str(x, "op"), J.Num(x, "value"), J.Str(x, "missing")))));

        private static StageLock[] Locks(JToken t) => Mapping.Each(t, "locks", l => new StageLock(J.Str(l, "type"), J.Str(l, "key"), J.Str(l, "table"), J.Num(l, "value")));

        private static string Id(JToken t) => t == null || t.Type == JTokenType.Null ? null : t.Type == JTokenType.String ? (string)t : t.ToString(Newtonsoft.Json.Formatting.None);

        private static string Blank(string s) => string.IsNullOrEmpty(s) ? null : s;

        private static StageReward[] Rewards(JToken t, string name) => Mapping.Each(t, name, x => new StageReward(Mapping.CurrencyKey(x), Mapping.Amount(x)));

        private static GrantedReward[] Granted(JToken t, string name) => Mapping.Each(t, name, x => new GrantedReward(Mapping.CurrencyKey(x), Mapping.CurrencyKey(x), Mapping.Amount(x)));

        internal static Trophy[] Trophies(JToken t) => Mapping.Each(t, "trophies", u =>
        {
            var step = J.Str(u, "stepName");
            var name = J.Str(u, "trophyName") ?? J.Str(u, "trophyKey");
            return new Trophy(J.Str(u, "trophyKey"), string.IsNullOrEmpty(step) || J.Int(u, "stepCount") <= 1 ? name : name + " · " + step, step, J.Str(u?["rewards"], "prizeKey"));
        });

        internal static StageResult Result(ApiClient c, string stageKey, bool success, JToken r)
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
                Prizes = Mapping.Each(r, "prizes", p => new StagePrize(J.Str(p, "key"), null, J.Str(p, "for"), PrizeItems(c, p))),
                PendingPrizes = Mapping.Each(r, "pendingPrizes", p => new StagePrize(J.Str(p, "prizeKey"), J.Str(p, "prizeGroupKey"), J.Str(p, "for"), Array.Empty<Prizes.PrizeItem>())),
                ChapterKey = J.Str(r, "chapterKey"),
                PreviousBestStars = J.Int(r, "previousBestStars"),
                Criteria = Mapping.Each(r, "criteria", x => new StageCriterion(J.Str(x, "field"), J.NumOrNull(x, "value"), J.Int(x, "stars"))),
                MilestoneIds = Mapping.Arr(r, "milestoneIds").Select(Id).Where(x => x != null).ToArray(),
                TimeSavedPercent = J.NumOrNull(r, "timeSavedPercent"),
                MinSeconds = J.NumOrNull(r, "minSeconds"),
                Replayable = r?["replayable"]?.Type == JTokenType.Boolean ? (bool?)(bool)r["replayable"] : null,
                StarRules = StarRules(r),
                ServerSeconds = J.NumOrNull(r, "serverSeconds"),
                Unlocks = TrophyUnlock.List(r?["trophies"]),
            };
        }

        private static Prizes.PrizeItem[] PrizeItems(ApiClient c, JToken prize) => Mapping.Each(prize, "items", i =>
        {
            var type = J.Str(i, "type");
            var item = type == "item" || type == Prizes.PrizeItemTypes.InventoryItem;
            return new Prizes.PrizeItem(item ? Prizes.PrizeItemTypes.InventoryItem : type, item ? c.Items.ToGame(J.Str(i, "key")) : J.Str(i, "key"), null, J.Str(i, "action") ?? "add", i["value"]);
        });
    }
}
