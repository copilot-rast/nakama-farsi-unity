namespace GuideCheck.Section13
{
    using System;
    using System.Collections.Generic;
    using PolicePatrol.Sdk;
    using PolicePatrol.Sdk.Assets;
    using PolicePatrol.Sdk.Cars;
    using PolicePatrol.Sdk.Stages;
    using PolicePatrol.Sdk.Unity;
    using UnityEngine;

    public enum ServiceSlot
    {
        Fuel,
        Tire,
        Oil,
        Brake,
        CarWash,
        Health,
    }

    public sealed class ServerData : MonoBehaviour
    {
        private void Start()
        {
            PolicePatrolAssets.RequireOnline = null;
            PolicePatrolAssets.MaxCacheAge = TimeSpan.FromDays(3);
            PolicePatrolAssets.LoadAndApply("cars", r =>
            {
                if (r.IsSuccess)
                {
                    Debug.Log("applied " + r.Data.Applied + (r.Data.Offline ? " from the cache" : string.Empty));
                }
                else if (r.Error.Code == AssetErrorCodes.OnlineRequired || r.Error.Code == AssetErrorCodes.CacheTooOld)
                {
                    Debug.LogWarning("connect to the internet: " + r.Error.Meta["originalCode"]);
                }

                var last = PolicePatrolAssets.LastLoad("cars");
                Debug.Log("last online load " + last?.LoadedAt + ", server says online only " + last?.Policy?.RequireOnline);
            });
        }
    }

    public sealed class Garage : MonoBehaviour
    {
        private CarService _running;

        public void Open(string vehicleKey)
        {
            CarProvider.Condition(vehicleKey, CarRoutes.Garage, r =>
            {
                if (!r.IsSuccess)
                {
                    Debug.LogWarning(r.Error.Code);
                    return;
                }

                var car = r.Data.Find(vehicleKey);
                foreach (var slot in CarSlots.All)
                {
                    var quote = car.Quote(slot);
                    Debug.Log(slot + " " + car.Percent(slot) + "% → " + quote?.Price?.Amount + " " + quote?.Price?.Currency + ", " + quote?.Seconds + "s");
                }

                _running = car.Running(CarSlots.Health);
                Debug.Log("can drive " + car.CanDrive + ", server clock offset " + r.Data.ServerOffset);
            });
        }

        public void Service(string vehicleKey, ServiceSlot slot)
        {
            CarProvider.StartService(vehicleKey, CarSlots.Of(slot), CarRoutes.Garage, r =>
            {
                if (r.IsSuccess)
                {
                    _running = r.Data.Service;
                }
                else if (r.Error.Code == CarErrorCodes.InsufficientBalance)
                {
                    Debug.Log("needs " + r.Error.Meta["required"] + " " + r.Error.Meta["currency"]);
                }
                else if (CarProvider.IsRetryable(r.Error))
                {
                    Debug.Log("try again, the same request id is reused");
                }
            });
        }

        private void Update()
        {
            if (_running != null && _running.IsRunning)
            {
                var left = _running.SecondsLeftAt(DateTimeOffset.UtcNow);
                if (left <= 0)
                {
                    var done = _running;
                    _running = null;
                    CarProvider.FinishService(PlayerCar(), done.Slot, false, r => Debug.Log(r.IsSuccess ? "done" : r.Error.Code));
                }
            }
        }

        public void Skip(ServiceSlot slot) =>
            CarProvider.FinishService(PlayerCar(), CarSlots.Of(slot), true, r =>
            {
                if (!r.IsSuccess && r.Error.Code == CarErrorCodes.ServiceNotReady)
                {
                    Debug.Log(r.Error.Meta["gemToFinish"] + " gems to finish now");
                }
            });

        public void Drive(string stageKey)
        {
            StageProvider.Start(stageKey, PlayerCar(), r =>
            {
                if (!r.IsSuccess && (r.Error.Code == StageErrorCodes.CarNeedsService || r.Error.Code == StageErrorCodes.CarInService))
                {
                    Debug.Log("the car needs the garage first");
                }
            });
        }

        public void Finish(string stageKey, string attemptId, double seconds, double health, double km, CarConditionReport condition)
        {
            var fields = CarWearFields.Build(km, 0, km * 0.1, condition);
            fields[StageFields.TimesSeen] = 0;
            StageProvider.Complete(stageKey, attemptId, true, seconds, health, fields, r =>
            {
                var wear = r.Data?.CarWear;
                if (wear != null)
                {
                    Debug.Log("fuel " + wear.Before.Fuel + " → " + wear.After.Fuel + ", needs service " + wear.NeedsCriticalService);
                }
            });
        }

        public void Report(ServiceSlot slot, float percent) =>
            CarProvider.Report(PlayerCar(), new CarConditionReport().With(CarSlots.Of(slot), percent), "gas-station-3", r => Debug.Log(r.Data?.Changed));

        public void AdoptLocalSave(string vehicleKey, int fuel, int health, DateTime repairStartedUtc)
        {
            var entries = new List<CarAdoptEntry>
            {
                new CarAdoptEntry(vehicleKey, new CarConditionReport { Fuel = fuel, Health = health }, new[] { CarAdoptTicket.From(CarSlots.Health, repairStartedUtc, 300, 12) }),
            };
            CarProvider.Adopt(entries, r => Debug.Log(r.IsSuccess ? "adopted " + r.Data.Adopted + ", already " + r.Data.AlreadyAdopted : r.Error.Code));
        }

        private static string PlayerCar() => "Tiggo8";
    }
}
