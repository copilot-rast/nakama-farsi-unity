using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Cars
{
    public static class CarProvider
    {
        private static readonly ConcurrentDictionary<string, string> Retries = new ConcurrentDictionary<string, string>(StringComparer.Ordinal);

        public static void Condition(Action<ApiResult<CarConditions>> onComplete) => Condition(null, null, onComplete);

        public static void Condition(string vehicleKey, string route, Action<ApiResult<CarConditions>> onComplete) => Condition(vehicleKey, route, false, onComplete);

        public static void Condition(string vehicleKey, string route, bool noQuotes, Action<ApiResult<CarConditions>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var body = new JObject();
                if (!string.IsNullOrEmpty(vehicleKey))
                {
                    body["vehicleKey"] = c.Items.ToServer(vehicleKey);
                }

                if (!string.IsNullOrEmpty(route))
                {
                    body["route"] = route;
                }

                if (noQuotes)
                {
                    body["noQuotes"] = true;
                }

                var r = await c.Rpc("pp_car_condition", body, true).ConfigureAwait(false);
                var at = DateTimeOffset.UtcNow;
                var serverTime = J.Time(r, "serverTime");
                return new CarConditions(serverTime, J.Str(r, "route"), J.Bool(r, "adopted"), Mapping.Each(r, "cars", x => Car(c, x, serverTime, at))) { ReceivedAt = at };
            }, null, "pp_car_condition");

        public static void StartService(string vehicleKey, string slot, string route, Action<ApiResult<CarServiceResult>> onComplete, string requestId = null)
        {
            var wire = CarSlots.Normalize(slot) ?? slot;
            var id = Reuse("start|" + vehicleKey + "|" + wire + "|" + route, requestId, ref onComplete);
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var body = new JObject { ["vehicleKey"] = c.Items.ToServer(vehicleKey), ["slot"] = wire, ["requestId"] = id };
                if (!string.IsNullOrEmpty(route))
                {
                    body["route"] = route;
                }

                var r = await c.Rpc("pp_service_start", body, false, true).ConfigureAwait(false);
                return ServiceResult(c, r);
            }, null, "pp_service_start");
        }

        public static void FinishService(string vehicleKey, string slot, bool skip, Action<ApiResult<CarServiceResult>> onComplete, string requestId = null)
        {
            var wire = CarSlots.Normalize(slot) ?? slot;
            var id = Reuse("finish|" + vehicleKey + "|" + wire + "|" + skip, requestId, ref onComplete);
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var body = new JObject { ["vehicleKey"] = c.Items.ToServer(vehicleKey), ["slot"] = wire, ["requestId"] = id };
                if (skip)
                {
                    body["skip"] = true;
                }

                var r = await c.Rpc("pp_service_finish", body, false, true).ConfigureAwait(false);
                return ServiceResult(c, r);
            }, null, "pp_service_finish");
        }

        public static void Report(string vehicleKey, CarConditionReport condition, Action<ApiResult<CarReportResult>> onComplete) => Report(vehicleKey, condition, null, onComplete);

        public static void Report(string vehicleKey, CarConditionReport condition, string parkedPoi, Action<ApiResult<CarReportResult>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var body = new JObject { ["vehicleKey"] = c.Items.ToServer(vehicleKey), ["condition"] = ConditionJson(condition) };
                if (parkedPoi != null)
                {
                    body["parkedPoi"] = parkedPoi;
                }

                var r = await c.Rpc("pp_car_report", body, false, true).ConfigureAwait(false);
                var at = DateTimeOffset.UtcNow;
                var serverTime = J.Time(r, "serverTime");
                return new CarReportResult(serverTime, J.Bool(r, "changed"), Car(c, r?["car"], serverTime, at)) { ReceivedAt = at };
            }, null, "pp_car_report");

        public static void Adopt(IEnumerable<CarAdoptEntry> cars, Action<ApiResult<CarAdoptResult>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var list = new JArray();
                foreach (var car in cars ?? Enumerable.Empty<CarAdoptEntry>())
                {
                    if (car == null)
                    {
                        continue;
                    }

                    list.Add(new JObject
                    {
                        ["vehicleKey"] = c.Items.ToServer(car.VehicleKey),
                        ["condition"] = ConditionJson(car.Condition),
                        ["services"] = new JArray((car.Services ?? Array.Empty<CarAdoptTicket>()).Where(t => t != null).Select(t => new JObject
                        {
                            ["slot"] = CarSlots.Normalize(t.Slot) ?? t.Slot,
                            ["startedAtTicks"] = t.StartedAtTicks,
                            ["seconds"] = t.Seconds,
                            ["gem"] = t.Gem,
                        })),
                    });
                }

                var r = await c.Rpc("pp_car_adopt", new JObject { ["cars"] = list }, false, true).ConfigureAwait(false);
                var at = DateTimeOffset.UtcNow;
                var serverTime = J.Time(r, "serverTime");
                return new CarAdoptResult(
                    serverTime,
                    J.Bool(r, "adopted"),
                    J.Bool(r, "alreadyAdopted"),
                    J.Str(r, "mode"),
                    J.Bool(r, "ticketsTrusted"),
                    Mapping.Each(r, "applied", a => new CarAdoptApplied(c.Items.ToGame(J.Str(a, "vehicleKey")), Condition(a?["before"]), Condition(a?["after"]), Strings(a, "services"))),
                    Strings(r, "skipped").Select(c.Items.ToGame).ToArray(),
                    J.Int(r, "ignoredServices"),
                    Mapping.Each(r, "cars", x => Car(c, x, serverTime, at))) { ReceivedAt = at };
            }, null, "pp_car_adopt");

        public static bool IsRetryable(ApiError error) =>
            error != null && (error.IsNetworkError || error.Status == 429 || error.Status >= 500);

        private static string Reuse<T>(string action, string requestId, ref Action<ApiResult<T>> onComplete)
        {
            if (!string.IsNullOrEmpty(requestId))
            {
                return requestId;
            }

            var id = Retries.GetOrAdd(action, _ => Guid.NewGuid().ToString("N"));
            var done = onComplete;
            onComplete = result =>
            {
                if (result.IsSuccess || !IsRetryable(result.Error))
                {
                    ((ICollection<KeyValuePair<string, string>>)Retries).Remove(new KeyValuePair<string, string>(action, id));
                }

                done?.Invoke(result);
            };
            return id;
        }

        private static CarServiceResult ServiceResult(ApiClient c, JToken r)
        {
            var at = DateTimeOffset.UtcNow;
            var serverTime = J.Time(r, "serverTime");
            var service = r?["service"] is JObject s ? Service(s, serverTime, at) : null;
            return new CarServiceResult(serverTime, J.Bool(r, "replayed"), J.Bool(r, "alreadyDone"), J.Bool(r, "completed"), Price(r?["charged"]), service, Car(c, r?["car"], serverTime, at)) { ReceivedAt = at };
        }

        internal static JObject ConditionJson(CarConditionReport condition)
        {
            var o = new JObject();
            foreach (var p in (condition ?? new CarConditionReport()).ToDictionary())
            {
                o[p.Key] = p.Value;
            }

            return o;
        }

        internal static CarCondition Condition(JToken t) => t is JObject
            ? new CarCondition(J.Int(t, "health", 100), J.Int(t, "fuel", 100), J.Int(t, "tire", 100), J.Int(t, "oil", 100), J.Int(t, "brake", 100), J.Int(t, "carWash", 100))
            : null;

        internal static CarPrice Price(JToken t) => t is JObject ? new CarPrice(J.Str(t, "currency", "currencyKey"), Mapping.Amount(t)) : null;

        internal static string[] Strings(JToken t, string name) => Mapping.Arr(t, name).Where(x => x.Type == JTokenType.String).Select(x => (string)x).ToArray();

        internal static CarService Service(JToken s, DateTimeOffset? serverTime, DateTimeOffset receivedAt) => new CarService(
            J.Str(s, "serviceId"),
            J.Str(s, "slot"),
            J.Str(s, "state"),
            J.Str(s, "route"),
            J.Time(s, "startedAt"),
            J.Time(s, "endsAt"),
            J.Num(s, "seconds"),
            J.Num(s, "secondsLeft"),
            J.Num(s, "gem"),
            J.Num(s, "gemToFinish"),
            Price(s?["charged"]),
            J.Num(s, "skipGem"),
            J.Str(s, "source"))
        {
            FinishedAt = J.Time(s, "finishedAt"),
            FinishedBy = string.IsNullOrEmpty(J.Str(s, "finishedBy")) ? null : J.Str(s, "finishedBy"),
            ServerTime = serverTime,
            ReceivedAt = receivedAt,
        };

        internal static CarView Car(ApiClient c, JToken t, DateTimeOffset? serverTime, DateTimeOffset receivedAt)
        {
            if (!(t is JObject))
            {
                return null;
            }

            var serverKey = J.Str(t, "vehicleKey");
            var gameId = J.Str(t, "gameId");
            c.Items.Learn(serverKey, gameId);
            return new CarView(
                c.Items.ToGame(serverKey),
                string.IsNullOrEmpty(gameId) ? null : gameId,
                J.Str(t, "itemId"),
                J.Bool(t, "equipped"),
                Condition(t["condition"]) ?? CarCondition.Full,
                Strings(t, "critical"),
                J.Bool(t, "needsCriticalService"),
                J.Bool(t, "inService"),
                J.Bool(t, "repairing"),
                J.Bool(t, "canDrive", true),
                string.IsNullOrEmpty(J.Str(t, "parkedPoi")) ? null : J.Str(t, "parkedPoi"),
                Mapping.Each(t, "services", s => Service(s, serverTime, receivedAt)),
                Mapping.Each(t, "quotes", q => new CarQuote(J.Str(q, "slot"), J.Int(q, "percent"), J.Bool(q, "available"), J.Bool(q, "full"), J.Num(q, "coin"), J.Num(q, "gem"), J.Num(q, "seconds"), Price(q?["price"]))))
            {
                ServerKey = serverKey,
                UpdatedAt = J.Time(t, "updatedAt"),
            };
        }

        internal static CarWear Wear(ApiClient c, JToken t) => t is JObject
            ? new CarWear(
                c.Items.ToGame(J.Str(t, "vehicleKey")),
                J.Bool(t, "applied"),
                J.Bool(t, "replayed"),
                Condition(t["before"]),
                Condition(t["after"]),
                (t["wear"] as JObject)?.Properties().Where(p => p.Value.Type == JTokenType.Integer || p.Value.Type == JTokenType.Float)
                    .ToDictionary(p => p.Name, p => (double)p.Value, StringComparer.Ordinal) ?? new Dictionary<string, double>(StringComparer.Ordinal),
                J.Bool(t, "needsCriticalService"),
                Strings(t, "critical"))
            : null;
    }
}
