using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Stats
{
    public static class StatsProvider
    {
        public const int DefaultTrophyNotificationCode = 1501;

        public static int TrophyNotificationCode { get; set; } = DefaultTrophyNotificationCode;

        public static event Action<TrophyUnlock> TrophyStepUnlocked;

        public static void Config(Action<ApiResult<StatsConfig>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var r = await c.Rpc("analytics_config", new JObject { ["lang"] = c.Language }, true).ConfigureAwait(false);
                var config = ParseConfig(r);
                TrophyNotificationCode = config.NotificationCode;
                return config;
            }, null, "analytics_config");

        internal static StatsConfig ParseConfig(JToken r)
        {
            var interval = J.Int(r, "sendIntervalSeconds", 60);
            var thresholds = (r?["thresholds"] as JObject)?.Properties()
                .Where(p => p.Value.Type == JTokenType.Integer || p.Value.Type == JTokenType.Float)
                .ToDictionary(p => p.Name, p => (double)p.Value, StringComparer.Ordinal) ?? new Dictionary<string, double>();
            return new StatsConfig(interval, Mapping.Each(r, "stats", s => new StatConfig(J.Str(s, "key"), J.Str(s, "kind") ?? StatKinds.Sum, J.Int(s, "sendIntervalSeconds", interval))
            {
                Period = J.Str(s, "period") ?? StatPeriods.Total,
                SplitBy = Strings(s, "splitBy"),
            }))
            {
                Thresholds = thresholds,
                NotificationCode = J.Int(r, "notificationCode", DefaultTrophyNotificationCode),
                ClaimMode = J.Str(r, "claimMode"),
                Day = J.Str(r, "day"),
                Events = Mapping.Each(r, "events", e => new StatEventConfig(J.Str(e, "name"), Mapping.Each(e, "fields", f => f.Type == JTokenType.String ? new StatEventField((string)f, null) : new StatEventField(J.Str(f, "name"), J.Str(f, "type"))))),
            };
        }

        public static void Mine(Action<ApiResult<PlayerStat[]>> onComplete) => Mine(null, onComplete);

        public static void Mine(IEnumerable<string> keys, Action<ApiResult<PlayerStat[]>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var body = new JObject { ["lang"] = c.Language };
                var list = keys?.Where(k => !string.IsNullOrEmpty(k)).Distinct().ToArray();
                if (list != null && list.Length > 0)
                {
                    body["keys"] = new JArray(list);
                }

                var r = await c.Rpc("analytics_stats", body, true).ConfigureAwait(false);
                return ParseStats(r);
            }, null, "analytics_stats");

        internal static PlayerStat[] ParseStats(JToken r) => Mapping.Each(r, "items", i => new PlayerStat(J.Str(i, "key"), J.Str(i, "name"), J.Str(i, "kind"), J.Num(i, "total"), J.Num(i, "best"), J.Time(i, "updatedAt"))
        {
            Period = J.Str(i, "period") ?? StatPeriods.Total,
            SplitBy = Strings(i, "splitBy"),
            Value = J.Num(i, "value", J.Num(i, "total")),
            Current = J.Num(i, "current", J.Num(i, "total")),
            Tags = Mapping.Each(i, "tags", g => new StatTag(J.Str(g, "tag"), J.Str(g, "key"), J.Str(g, "label"), J.Num(g, "value"), J.Num(g, "current"), J.Num(g, "total"), J.Num(g, "best"))),
        });

        public static void Trophies(Action<ApiResult<TrophyPage>> onComplete) => Trophies(null, onComplete);

        public static void Trophies(string group, Action<ApiResult<TrophyPage>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var body = new JObject { ["lang"] = c.Language };
                if (!string.IsNullOrEmpty(group))
                {
                    body["group"] = group;
                }

                var r = await c.Rpc("analytics_trophies", body, true).ConfigureAwait(false);
                return ParseTrophies(r);
            }, null, "analytics_trophies");

        internal static TrophyPage ParseTrophies(JToken r)
        {
            var totals = r?["totals"];
            return new TrophyPage(
                J.Str(r, "claimMode"),
                J.Str(r, "unlockOrder"),
                Mapping.Each(r, "groups", g => new TrophyGroup(J.Str(g, "key"), J.Str(g, "name"), J.Str(g, "description"), Blank(J.Str(g, "iconUrl")), J.Int(g, "unlocked"), J.Int(g, "stepCount"),
                    Mapping.Each(g, "trophies", ParseTrophy))),
                new TrophyTotals(J.Int(totals, "steps"), J.Int(totals, "unlocked"), J.Int(totals, "claimable")),
                TrophyUnlock.List(r?["unlocked"]));
        }

        private static TrophyInfo ParseTrophy(JToken t) => new TrophyInfo(
            J.Str(t, "key"), J.Str(t, "name"), J.Str(t, "description"), Blank(J.Str(t, "iconUrl")), Blank(J.Str(t, "contextKey")), J.Str(t, "unlockOrder"),
            J.Int(t, "unlocked"), J.Int(t, "stepCount"), J.Bool(t, "completed"),
            Mapping.Each(t, "steps", s => new TrophyStep(
                J.Str(s, "id"), J.Int(s, "step"), J.Str(s, "name"), Blank(J.Str(s, "iconUrl")), J.Bool(s, "unlocked"), J.Time(s, "unlockedAt"), J.Bool(s, "available", true), J.Num(s, "progress"),
                Mapping.Each(s, "conditions", x => new TrophyCondition(Blank(J.Str(x, "stat")), Blank(J.Str(x, "tag")), Blank(J.Str(x, "statName")), Blank(J.Str(x, "event")), Blank(J.Str(x, "field")), J.Str(x, "op"), x?["value"],
                    J.NumOrNull(x, "current"), x?["met"]?.Type == JTokenType.Boolean ? (bool?)(bool)x["met"] : null)),
                TrophyReward.From(s?["rewards"]), J.Str(s, "claimMode"), J.Str(s, "claimStatus"), J.Bool(s, "claimable"))));

        public static void Claim(string trophyKey, int step, Action<ApiResult<TrophyClaim>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var r = await c.Rpc("analytics_trophy_claim", new JObject { ["trophy"] = trophyKey, ["step"] = step, ["lang"] = c.Language }, false, true).ConfigureAwait(false);
                return ParseClaim(r);
            }, null, "analytics_trophy_claim");

        public static void ClaimStep(string stepId, Action<ApiResult<TrophyClaim>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var r = await c.Rpc("analytics_trophy_claim", new JObject { ["stepId"] = stepId, ["lang"] = c.Language }, false, true).ConfigureAwait(false);
                return ParseClaim(r);
            }, null, "analytics_trophy_claim");

        internal static TrophyClaim ParseClaim(JToken r) =>
            new TrophyClaim(J.Str(r, "stepId"), J.Str(r, "trophyKey"), J.Int(r, "step"), J.Str(r, "status"), TrophyReward.From(r?["rewards"]));

        internal static void OnNotification(int code, JObject content)
        {
            var unlock = TrophyUnlock.FromNotification(code, content, TrophyNotificationCode);
            if (unlock != null)
            {
                TrophyStepUnlocked?.Invoke(unlock);
            }
        }

        private static string[] Strings(JToken t, string name) => Mapping.Arr(t, name).Where(x => x.Type == JTokenType.String).Select(x => (string)x).ToArray();

        private static string Blank(string s) => string.IsNullOrEmpty(s) ? null : s;

        public static void Goals(Action<ApiResult<PlayerGoal[]>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var r = await c.Rpc("analytics_trophies", new JObject { ["lang"] = c.Language }, true).ConfigureAwait(false);
                var goals = new List<PlayerGoal>();
                var order = 0;
                foreach (var g in Mapping.Arr(r, "groups"))
                {
                    foreach (var t in Mapping.Arr(g, "trophies"))
                    {
                        var steps = Mapping.Arr(t, "steps");
                        foreach (var s in steps)
                        {
                            var multi = steps.Count > 1;
                            goals.Add(new PlayerGoal(
                                multi ? J.Str(t, "key") + ":" + J.Int(s, "step") : J.Str(t, "key"),
                                multi ? J.Str(t, "name") + " · " + J.Str(s, "name") : J.Str(t, "name"),
                                J.Str(t, "description"),
                                order++,
                                J.Str(t, "contextKey"),
                                J.Str(s?["rewards"], "prizeKey"),
                                J.Bool(s, "unlocked"),
                                J.Time(s, "unlockedAt"),
                                Mapping.Each(s, "conditions", x => new GoalCondition(J.Str(x, "stat"), J.Str(x, "field"), J.Str(x, "op"), x?["value"], J.NumOrNull(x, "current"), J.Bool(x, "met")))));
                        }
                    }
                }

                return goals.ToArray();
            }, null, "analytics_trophies");

        public static void Report(IEnumerable<StatValue> stats, Action<ApiResult<StatsReport>> onComplete) =>
            Report(stats, null, onComplete);

        public static void Report(IEnumerable<StatValue> stats, string reportId, Action<ApiResult<StatsReport>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, c => Send(c, (stats ?? Enumerable.Empty<StatValue>()).ToArray(), reportId ?? Guid.NewGuid().ToString("N")), null, "analytics_track");

        internal static async Task<StatsReport> Send(ApiClient c, StatValue[] stats, string reportId)
        {
            var now = DateTimeOffset.UtcNow.ToString("o");
            var analytics = c.Core.Analytics;
            var body = new JObject
            {
                ["batchId"] = reportId,
                ["appVersion"] = analytics.Options.AppVersion ?? string.Empty,
                ["platform"] = analytics.Options.Platform ?? string.Empty,
                ["lang"] = c.Language,
                ["events"] = new JArray(stats.Select(s => new JObject { ["type"] = "design", ["id"] = s.Key, ["value"] = s.Value, ["time"] = now })),
            };
            if (analytics.SessionId != null)
            {
                body["session"] = new JObject { ["id"] = analytics.SessionId, ["num"] = analytics.SessionNum };
            }

            var context = analytics.Context;
            if (context.Count > 0)
            {
                body["context"] = JObject.FromObject(context);
            }

            var r = await c.Rpc("analytics_track", body, false, true).ConfigureAwait(false);
            return ParseReport(r, stats);
        }

        internal static StatsReport ParseReport(JToken r, StatValue[] stats)
        {
            var rows = Mapping.Each(r, "stats", s => new StatReportRow(J.Str(s, "key"), J.Num(s, "sent"), J.Num(s, "accepted"), J.Num(s, "value"), J.Num(s, "value"), J.Str(s, "status"))
            {
                Tag = Blank(J.Str(s, "tag")),
                Current = J.Num(s, "current", J.Num(s, "value")),
            });
            var seen = new HashSet<string>(rows.Select(x => x.Key), StringComparer.Ordinal);
            var unknown = (stats ?? Array.Empty<StatValue>()).Where(s => !seen.Contains(s.Key)).Select(s => new StatReportRow(s.Key, s.Value, 0, 0, 0, StatReportStatuses.Unknown));
            return new StatsReport(rows.Concat(unknown).ToArray(), Stages.StageProvider.Trophies(new JObject { ["trophies"] = r?["unlocked"] ?? new JArray() }))
            {
                Unlocks = TrophyUnlock.List(r?["unlocked"]),
                Duplicate = J.Bool(r, "duplicate"),
            };
        }
    }
}
