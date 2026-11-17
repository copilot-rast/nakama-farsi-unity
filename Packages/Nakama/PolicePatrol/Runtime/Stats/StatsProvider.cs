using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Stats
{
    public static class StatsProvider
    {
        public static void Config(Action<ApiResult<StatsConfig>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var r = await c.Rpc("analytics_config", new JObject { ["lang"] = c.Language }, true).ConfigureAwait(false);
                var interval = J.Int(r, "sendIntervalSeconds", 60);
                return new StatsConfig(interval, Mapping.Each(r, "stats", s => new StatConfig(J.Str(s, "key"), J.Str(s, "kind") ?? StatKinds.Sum, J.Int(s, "sendIntervalSeconds", interval))));
            }, null, "analytics_config");

        public static void Mine(Action<ApiResult<PlayerStat[]>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var r = await c.Rpc("analytics_stats", new JObject { ["lang"] = c.Language }, true).ConfigureAwait(false);
                return Mapping.Each(r, "items", i => new PlayerStat(J.Str(i, "key"), J.Str(i, "name"), J.Str(i, "kind"), J.Num(i, "total"), J.Num(i, "best"), J.Time(i, "updatedAt")));
            }, null, "analytics_stats");

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
            var rows = Mapping.Each(r, "stats", s => new StatReportRow(J.Str(s, "key"), J.Num(s, "sent"), J.Num(s, "accepted"), J.Num(s, "value"), J.Num(s, "value"), J.Str(s, "status")));
            var seen = new HashSet<string>(rows.Select(x => x.Key), StringComparer.Ordinal);
            var unknown = stats.Where(s => !seen.Contains(s.Key)).Select(s => new StatReportRow(s.Key, s.Value, 0, 0, 0, StatReportStatuses.Unknown));
            return new StatsReport(rows.Concat(unknown).ToArray(), Stages.StageProvider.Trophies(new JObject { ["trophies"] = r?["unlocked"] ?? new JArray() }));
        }
    }
}
