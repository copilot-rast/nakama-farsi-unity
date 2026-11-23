using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Cars;
using PolicePatrol.Sdk.Stages;
using NF = NakamaFarsi.Sdk;
using Xunit;

namespace PolicePatrol.Sdk.Tests
{
    public class CarTests
    {
        private enum GameSlot
        {
            Fuel,
            Tire,
            Oil,
            Brake,
            CarWash,
            Health,
        }

        private static string Fixture(string name) => File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Fixtures", name + ".json"));

        private static string RequestId(string payload) => (string)JObject.Parse(payload)["requestId"];

        private const string ServiceOut = "{\"serverTime\":\"2026-11-23T10:00:00.000Z\",\"replayed\":false,\"alreadyDone\":false,\"completed\":false,\"charged\":{\"currency\":\"coin\",\"amount\":92},"
            + "\"service\":{\"serviceId\":\"s-1\",\"slot\":\"fuel\",\"state\":\"running\",\"route\":\"garage\",\"startedAt\":\"2026-11-23T10:00:00.000Z\",\"endsAt\":\"2026-11-23T10:00:46.000Z\",\"seconds\":46,\"secondsLeft\":46,\"gem\":2,\"gemToFinish\":2,\"charged\":{\"currency\":\"coin\",\"amount\":92},\"skipGem\":0,\"source\":\"player\"},"
            + "\"car\":{\"vehicleKey\":\"pp-car-tiggo8\",\"gameId\":\"Tiggo8\",\"condition\":{\"health\":42,\"fuel\":8,\"tire\":77,\"oil\":64,\"brake\":90,\"carWash\":30},\"inService\":true,\"canDrive\":false,\"services\":[],\"quotes\":[]}}";

        [Fact]
        public async Task ConditionAnswerIsReadIntoTypedCars()
        {
            var t = Harness.Start();
            t.Routes["pp_car_condition"] = p => Fixture("pp_car_condition");
            var r = await Harness.Call<CarConditions>(CarProvider.Condition);
            Assert.True(r.IsSuccess);
            Assert.Equal("garage", r.Data.Route);
            Assert.True(r.Data.Adopted);
            Assert.Equal(new DateTimeOffset(2026, 11, 23, 10, 0, 0, TimeSpan.Zero), r.Data.ServerTime);
            Assert.True(Math.Abs((r.Data.ServerOffset - (r.Data.ServerTime.Value - r.Data.ReceivedAt)).TotalSeconds) < 0.001);

            var car = r.Data.Equipped;
            Assert.Equal("Tiggo8", car.VehicleKey);
            Assert.Equal("pp-car-tiggo8", car.ServerKey);
            Assert.Equal(8, car.Condition.Fuel);
            Assert.Equal(8, car.Percent(CarSlots.Of(GameSlot.Fuel)));
            Assert.Equal(42, car.Condition.Get(CarSlots.Repair));
            Assert.True(car.IsCritical("fuel"));
            Assert.True(car.NeedsCriticalService);
            Assert.True(car.Repairing);
            Assert.False(car.CanDrive);
            Assert.Equal("gas-station-3", car.ParkedPoi);
            Assert.Equal(6, car.Quotes.Length);
            Assert.Equal(92, car.Quote("fuel").Price.Amount);
            Assert.Equal("coin", car.Quote("fuel").Price.Currency);
            Assert.False(car.Quote("health").Available);

            var repair = car.Running(CarSlots.Health);
            Assert.Equal("c2a3b4d5-0000-4000-8000-000000000001", repair.ServiceId);
            Assert.True(repair.IsRunning);
            Assert.Equal(180, repair.SecondsLeft);
            Assert.Equal(8, repair.GemToFinish);
            Assert.Equal(580, repair.Charged.Amount);
            Assert.Equal(new DateTimeOffset(2026, 11, 23, 10, 3, 0, TimeSpan.Zero), repair.EndsAt);
            Assert.Equal(120, repair.SecondsLeftAt(repair.ReceivedAt.AddSeconds(60)), 3);
            Assert.Equal(0, repair.SecondsLeftAt(repair.ReceivedAt.AddMinutes(10)));
            Assert.Equal(180, repair.SecondsLeftAt(repair.ReceivedAt.AddSeconds(-30)), 3);
            Assert.Equal(repair.ReceivedAt.AddSeconds(180), repair.LocalEndsAt);
            Assert.True(repair.IsReadyAt(repair.ReceivedAt.AddSeconds(181)));

            var pride = r.Data.Find("pp-car-pride");
            Assert.Null(pride.GameId);
            Assert.True(pride.CanDrive);
            Assert.Null(pride.ParkedPoi);
            Assert.Same(car, r.Data.Find("tiggo8"));

            await Harness.Call<CarConditions>(cb => CarProvider.Condition("Tiggo8", CarRoutes.Poi, true, cb));
            var body = JObject.Parse(t.Calls.Last().Payload);
            Assert.Equal("pp-car-tiggo8", (string)body["vehicleKey"]);
            Assert.Equal("poi", (string)body["route"]);
            Assert.True((bool)body["noQuotes"]);
        }

        [Fact]
        public void SlotsFollowTheGameEnumOrder()
        {
            Assert.Equal(new[] { "fuel", "tire", "oil", "brake", "carWash", "health" }, CarSlots.All);
            Assert.Equal("carWash", CarSlots.FromIndex(4));
            Assert.Equal(5, CarSlots.ToIndex("repair"));
            Assert.Equal(5, CarSlots.ToIndex("Health"));
            Assert.Equal(-1, CarSlots.ToIndex("wheels"));
            Assert.Null(CarSlots.FromIndex(6));
            Assert.Equal(GameSlot.CarWash, CarSlots.ToEnum<GameSlot>("CARWASH"));
            Assert.Equal("brake", CarSlots.Of(GameSlot.Brake));
        }

        [Fact]
        public async Task StartSendsTheSlotAndKeepsTheRequestIdForRetries()
        {
            var t = Harness.Start();
            t.Routes["pp_car_condition"] = p => Fixture("pp_car_condition");
            await Harness.Call<CarConditions>(CarProvider.Condition);

            t.Routes["pp_service_start"] = p => new NF.RpcTransportException("reset", true);
            var down = await Harness.Call<CarServiceResult>(cb => CarProvider.StartService("Tiggo8", CarSlots.Of(GameSlot.Fuel), CarRoutes.Garage, cb));
            Assert.True(down.Error.IsNetworkError);
            var body = JObject.Parse(t.Calls.Last().Payload);
            Assert.Equal("pp-car-tiggo8", (string)body["vehicleKey"]);
            Assert.Equal("fuel", (string)body["slot"]);
            Assert.Equal("garage", (string)body["route"]);
            var first = RequestId(t.Calls.Last().Payload);
            Assert.False(string.IsNullOrEmpty(first));

            t.Routes["pp_service_start"] = p => new NF.RpcServerException("{\"code\":\"INTERNAL\",\"status\":500}", 500);
            await Harness.Call<CarServiceResult>(cb => CarProvider.StartService("Tiggo8", "fuel", CarRoutes.Garage, cb));
            Assert.Equal(first, RequestId(t.Calls.Last().Payload));

            t.Routes["pp_service_start"] = p => ServiceOut;
            var ok = await Harness.Call<CarServiceResult>(cb => CarProvider.StartService("Tiggo8", "fuel", CarRoutes.Garage, cb));
            Assert.True(ok.IsSuccess);
            Assert.Equal(first, RequestId(t.Calls.Last().Payload));
            Assert.Equal(92, ok.Data.Charged.Amount);
            Assert.Equal("s-1", ok.Data.Service.ServiceId);
            Assert.Equal(46, ok.Data.Service.SecondsLeft);
            Assert.Equal("Tiggo8", ok.Data.Car.VehicleKey);
            Assert.False(ok.Data.Car.CanDrive);

            await Harness.Call<CarServiceResult>(cb => CarProvider.StartService("Tiggo8", "fuel", CarRoutes.Garage, cb));
            Assert.NotEqual(first, RequestId(t.Calls.Last().Payload));

            await Harness.Call<CarServiceResult>(cb => CarProvider.StartService("Tiggo8", "fuel", null, cb, "game-7"));
            Assert.Equal("game-7", RequestId(t.Calls.Last().Payload));
            Assert.Null(JObject.Parse(t.Calls.Last().Payload)["route"]);
        }

        [Fact]
        public async Task FinishWithSkipAndAFinalErrorGetsANewId()
        {
            var t = Harness.Start();
            t.Routes["pp_service_finish"] = p => new NF.RpcServerException("{\"code\":\"SERVICE_NOT_READY\",\"status\":409,\"meta\":{\"secondsLeft\":31,\"endsAt\":\"2026-11-23T10:00:46.000Z\",\"gemToFinish\":2}}", 409);
            var r = await Harness.Call<CarServiceResult>(cb => CarProvider.FinishService("Tiggo8", "fuel", false, cb));
            Assert.Equal(CarErrorCodes.ServiceNotReady, r.Error.Code);
            Assert.Equal(31, (int)r.Error.Meta["secondsLeft"]);
            Assert.Equal(2, (int)r.Error.Meta["gemToFinish"]);
            var first = RequestId(t.Calls.Last().Payload);
            Assert.Null(JObject.Parse(t.Calls.Last().Payload)["skip"]);

            t.Routes["pp_service_finish"] = p => ServiceOut.Replace("\"completed\":false", "\"completed\":true").Replace("\"state\":\"running\"", "\"state\":\"skipped\"");
            var done = await Harness.Call<CarServiceResult>(cb => CarProvider.FinishService("Tiggo8", "repair", true, cb));
            Assert.True(done.IsSuccess);
            var body = JObject.Parse(t.Calls.Last().Payload);
            Assert.True((bool)body["skip"]);
            Assert.Equal("health", (string)body["slot"]);
            Assert.NotEqual(first, RequestId(t.Calls.Last().Payload));
            Assert.True(done.Data.Completed);
            Assert.Equal(CarServiceStates.Skipped, done.Data.Service.State);
            Assert.False(done.Data.Service.IsRunning);
            Assert.Equal(0, done.Data.Service.SecondsLeftNow);
        }

        [Theory]
        [InlineData("SERVICE_ALREADY_RUNNING", 409, CarErrorCodes.ServiceAlreadyRunning)]
        [InlineData("INSUFFICIENT_BALANCE", 402, CarErrorCodes.InsufficientBalance)]
        [InlineData("ITEM_NOT_OWNED", 409, CarErrorCodes.ItemNotOwned)]
        [InlineData("ITEM_NOT_FOUND", 404, CarErrorCodes.ItemNotFound)]
        [InlineData("REQUEST_ID_REUSED", 409, CarErrorCodes.RequestIdReused)]
        [InlineData("CAR_CONDITION_OFF", 403, CarErrorCodes.ConditionOff)]
        [InlineData("SERVICE_SLOT_INVALID", 400, CarErrorCodes.SlotInvalid)]
        public async Task ServerCodesArriveAsIs(string server, int status, string expected)
        {
            var t = Harness.Start();
            t.Routes["pp_service_start"] = p => new NF.RpcServerException("{\"code\":\"" + server + "\",\"status\":" + status + ",\"meta\":{\"currency\":\"coin\",\"required\":92}}", status);
            var r = await Harness.Call<CarServiceResult>(cb => CarProvider.StartService("Tiggo8", "fuel", null, cb));
            Assert.Equal(expected, r.Error.Code);
            Assert.Equal(status, r.Error.Status);
            Assert.Equal(server, r.Error.ServerCode);
        }

        [Fact]
        public async Task StageStartGateCodesKeepTheirMeta()
        {
            var t = Harness.Start();
            t.Routes["campaign_chapters"] = p => "{\"xp\":0,\"level\":1,\"chapters\":[]}";
            t.Routes["campaign_attempt_start"] = p => new NF.RpcServerException("{\"code\":\"CAR_NEEDS_SERVICE\",\"status\":403,\"meta\":{\"vehicleKey\":\"pp-car-tiggo8\",\"slots\":[\"fuel\"]}}", 403);
            var r = await Harness.Call<StageAttempt>(cb => StageProvider.Start("level-03", "Tiggo8", cb));
            Assert.Equal(StageErrorCodes.CarNeedsService, r.Error.Code);
            Assert.Equal(CarErrorCodes.NeedsService, r.Error.Code);
            Assert.Equal("fuel", (string)r.Error.Meta["slots"][0]);

            t.Routes["campaign_attempt_start"] = p => new NF.RpcServerException("{\"code\":\"CAR_IN_SERVICE\",\"status\":403,\"meta\":{\"slot\":\"health\",\"secondsLeft\":120}}", 403);
            var busy = await Harness.Call<StageAttempt>(cb => StageProvider.Start("level-03", "Tiggo8", cb));
            Assert.Equal(StageErrorCodes.CarInService, busy.Error.Code);
            Assert.Equal(120, (int)busy.Error.Meta["secondsLeft"]);

            t.Routes["campaign_attempt_start"] = p => new NF.RpcServerException("{\"code\":\"ITEM_NOT_OWNED\",\"status\":409}", 409);
            var owned = await Harness.Call<StageAttempt>(cb => StageProvider.Start("level-03", "Tiggo8", cb));
            Assert.Equal(StageErrorCodes.ItemNotOwned, owned.Error.Code);
        }

        [Fact]
        public async Task StageResultCarriesCarWearAndWearFieldsAreSent()
        {
            var t = Harness.Start();
            t.Routes["campaign_attempt_complete"] = p => Fixture("campaign_attempt_complete.pp_car");
            var fields = CarWearFields.Build(12.5, 2, 1.25, new CarConditionReport { Fuel = 51.5, Health = 80 });
            fields[StageFields.TimesSeen] = 0;
            var r = await Harness.Call<StageResult>(cb => StageProvider.Complete("level-03", "a-1", true, 90, 81, fields, cb));
            Assert.True(r.IsSuccess);
            Assert.Equal(2, r.Data.Stars);
            var wear = r.Data.CarWear;
            Assert.Equal("pp-car-tiggo8", wear.VehicleKey);
            Assert.True(wear.Applied);
            Assert.False(wear.Replayed);
            Assert.Equal(60, wear.Before.Fuel);
            Assert.Equal(52, wear.After.Fuel);
            Assert.Equal(81, wear.After.Health);
            Assert.Equal(8.25, wear.WearOf("fuel"));
            Assert.Equal(0, wear.WearOf("health"));
            Assert.False(wear.NeedsCriticalService);

            var sent = JObject.Parse(t.Calls.Last().Payload)["fields"];
            Assert.Equal(12.5, (double)sent["distanceKm"]);
            Assert.Equal(2, (double)sent["offroadKm"]);
            Assert.Equal(1.25, (double)sent["brakeKm"]);
            Assert.Equal(51.5, (double)sent["vehicleCondition"]["fuel"]);
            Assert.Equal(80, (double)sent["vehicleCondition"]["health"]);
            Assert.Null(sent["vehicleCondition"]["tire"]);
            Assert.Equal(0, (int)sent["timesSeen"]);

            t.Routes["campaign_attempt_complete"] = p => Fixture("campaign_attempt_complete");
            var plain = await Harness.Call<StageResult>(cb => StageProvider.Complete("level-03", "a-2", true, 90, 81, cb));
            Assert.Null(plain.Data.CarWear);
        }

        [Fact]
        public async Task ReportAndAdoptPayloads()
        {
            var t = Harness.Start();
            t.Routes["pp_car_condition"] = p => Fixture("pp_car_condition");
            await Harness.Call<CarConditions>(CarProvider.Condition);

            t.Routes["pp_car_report"] = p => "{\"serverTime\":\"2026-11-23T10:00:00.000Z\",\"changed\":true,\"car\":{\"vehicleKey\":\"pp-car-tiggo8\",\"gameId\":\"Tiggo8\",\"condition\":{\"health\":42,\"fuel\":5,\"tire\":77,\"oil\":64,\"brake\":90,\"carWash\":30},\"services\":[],\"quotes\":[]}}";
            var rep = await Harness.Call<CarReportResult>(cb => CarProvider.Report("Tiggo8", new CarConditionReport().With(CarSlots.Of(GameSlot.Fuel), 5.4), "poi-9", cb));
            Assert.True(rep.Data.Changed);
            Assert.Equal(5, rep.Data.Car.Condition.Fuel);
            Assert.Equal("Tiggo8", rep.Data.Car.VehicleKey);
            var body = JObject.Parse(t.Calls.Last().Payload);
            Assert.Equal("pp-car-tiggo8", (string)body["vehicleKey"]);
            Assert.Equal(5.4, (double)body["condition"]["fuel"]);
            Assert.Single(((JObject)body["condition"]).Properties());
            Assert.Equal("poi-9", (string)body["parkedPoi"]);

            t.Routes["pp_car_adopt"] = p => "{\"serverTime\":\"2026-11-23T10:00:00.000Z\",\"adopted\":true,\"alreadyAdopted\":false,\"mode\":\"lower\",\"ticketsTrusted\":true,"
                + "\"applied\":[{\"vehicleKey\":\"pp-car-tiggo8\",\"before\":{\"health\":100,\"fuel\":100,\"tire\":100,\"oil\":100,\"brake\":100,\"carWash\":100},\"after\":{\"health\":70,\"fuel\":20,\"tire\":100,\"oil\":100,\"brake\":100,\"carWash\":100},\"services\":[\"health\"]}],"
                + "\"skipped\":[\"pp-car-pride\"],\"ignoredServices\":1,\"cars\":[]}";
            var started = new DateTime(2026, 11, 23, 9, 59, 0, DateTimeKind.Utc);
            var adopt = await Harness.Call<CarAdoptResult>(cb => CarProvider.Adopt(new[]
            {
                new CarAdoptEntry("Tiggo8", new CarConditionReport { Fuel = 20, Health = 70 }, new[] { CarAdoptTicket.From(CarSlots.Repair, started, 300, 12) }),
            }, cb));
            Assert.True(adopt.Data.Adopted);
            Assert.True(adopt.Data.TicketsTrusted);
            Assert.Equal("Tiggo8", adopt.Data.Applied[0].VehicleKey);
            Assert.Equal(20, adopt.Data.Applied[0].After.Fuel);
            Assert.Equal(new[] { "health" }, adopt.Data.Applied[0].Services);
            Assert.Equal(new[] { "pp-car-pride" }, adopt.Data.Skipped);
            Assert.Equal(1, adopt.Data.IgnoredServices);
            var sent = JObject.Parse(t.Calls.Last().Payload)["cars"][0];
            Assert.Equal("pp-car-tiggo8", (string)sent["vehicleKey"]);
            Assert.Equal(70, (double)sent["condition"]["health"]);
            Assert.Equal("health", (string)sent["services"][0]["slot"]);
            Assert.Equal(started.Ticks, (long)sent["services"][0]["startedAtTicks"]);
            Assert.Equal(300, (double)sent["services"][0]["seconds"]);
            Assert.Equal(12, (double)sent["services"][0]["gem"]);
        }
    }
}
