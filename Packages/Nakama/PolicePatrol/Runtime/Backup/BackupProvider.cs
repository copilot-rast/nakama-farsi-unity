using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Backup
{
    public static class BackupProvider
    {
        public static void List(Action<ApiResult<BackupList>> onComplete) => List(null, null, onComplete);

        public static void List(string attemptId, string mission, Action<ApiResult<BackupList>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var body = new JObject { ["lang"] = c.Language };
                if (!string.IsNullOrEmpty(attemptId))
                {
                    body["attemptId"] = attemptId;
                }

                if (!string.IsNullOrEmpty(mission))
                {
                    body["mission"] = mission;
                }

                return Read(await c.Rpc("pp_backup_list", body, true).ConfigureAwait(false));
            }, null, "pp_backup_list");

        public static void Use(string key, string attemptId, string requestId, Action<ApiResult<BackupList>> onComplete) =>
            Use(key, attemptId, requestId, null, null, onComplete);

        public static void Use(string key, string attemptId, string requestId, string unitId, string mission, Action<ApiResult<BackupList>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var body = new JObject { ["key"] = key, ["attemptId"] = attemptId, ["requestId"] = string.IsNullOrEmpty(requestId) ? NewRequestId() : requestId, ["lang"] = c.Language };
                if (!string.IsNullOrEmpty(unitId))
                {
                    body["unitId"] = unitId;
                }

                if (!string.IsNullOrEmpty(mission))
                {
                    body["mission"] = mission;
                }

                return Read(await c.Rpc("pp_backup_use", body, false, true).ConfigureAwait(false));
            }, null, "pp_backup_use");

        public static void Refund(string requestId, Action<ApiResult<BackupList>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
                Read(await c.Rpc("pp_backup_refund", new JObject { ["requestId"] = requestId, ["lang"] = c.Language }, false, true).ConfigureAwait(false)), null, "pp_backup_refund");

        public static string NewRequestId() => Guid.NewGuid().ToString("N");

        internal static BackupList Read(JToken r)
        {
            var units = J.Arr(r, "items").Select(Unit).ToArray();
            var use = r?["use"] as JObject;
            return new BackupList(units)
            {
                Enabled = J.Bool(r, "enabled", true),
                Unlimited = J.Bool(r, "unlimited"),
                DebitOn = J.Str(r, "debitOn") ?? BackupDebitModes.Arrival,
                RefundSeconds = J.Int(r, "refundSeconds"),
                RequireRun = J.Bool(r, "requireRun", true),
                EnforceCap = J.Bool(r, "enforceCap", true),
                CallsPerMission = J.Int(r, "callsPerMission", 3),
                EnforceCooldown = J.Bool(r, "enforceCooldown", true),
                SecondsBetweenCalls = J.Int(r, "secondsBetweenCalls", 60),
                CarsOutAtOnce = J.Int(r, "carsOutAtOnce", 1),
                LimitsPer = J.Str(r, "limitsPer") ?? "kind",
                AttemptId = J.Str(r, "attemptId"),
                Mission = J.Str(r, "mission"),
                ServerTime = J.Time(r, "serverTime"),
                Use = use == null ? null : new BackupUse(J.Str(use, "requestId"), J.Str(use, "key"), J.Str(use, "kind"), J.Str(use, "attemptId"), J.Str(use, "status"))
                {
                    Mission = J.Str(use, "mission"),
                    UnitId = J.Str(use, "unitId"),
                    Debited = J.Long(use, "debited"),
                    At = J.Time(use, "at"),
                    Replayed = J.Bool(use, "replayed"),
                },
            };
        }

        private static BackupUnit Unit(JToken t) =>
            new BackupUnit(J.Str(t, "key"), J.Str(t, "kind"), J.Str(t, "title"), J.Str(t, "icon"), J.Long(t, "count"))
            {
                UnityIds = J.Arr(t, "unityIds").Select(x => (string)x).Where(x => !string.IsNullOrEmpty(x)).ToArray(),
                Sort = J.Int(t, "sort"),
                CallsPerMission = J.Int(t, "callsPerMission"),
                SecondsBetweenCalls = J.Int(t, "secondsBetweenCalls"),
                Used = J.Int(t, "used"),
                CallsLeft = (int?)J.NumOrNull(t, "callsLeft"),
                NextCallAt = J.Time(t, "nextCallAt"),
                SecondsUntilNextCall = J.Int(t, "secondsUntilNextCall"),
            };
    }
}
