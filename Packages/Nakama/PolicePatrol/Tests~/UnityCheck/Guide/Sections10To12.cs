namespace GuideCheck.Sections10To12.S10
{
    using PolicePatrol.Sdk.Analytics;
    using PolicePatrol.Sdk.Inventory;
    using PolicePatrol.Sdk.Stages;
    using PolicePatrol.Sdk.Stats;
    using PolicePatrol.Sdk;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using UnityEngine;

    public static class ServerStages
    {
        public static void Load()
        {
            StageProvider.Get(r =>
            {
                if (!r.IsSuccess)
                {
                    Debug.LogWarning(r.Error.Code + ": " + r.Error.Message);
                    return;
                }

                foreach (var chapter in r.Data.Chapters)
                {
                    foreach (var stage in chapter.Stages)
                    {
                        Debug.Log(chapter.Kind + " " + stage.Key + " = " + stage.UnityLevelId + " (" + stage.Context + ")"
                            + " min " + stage.MinSeconds + "s, can start " + stage.CanStart
                            + ", missions " + stage.Settings.Missions.Length);
                    }
                }
            });
        }
    }

    public sealed class ResultScreen : MonoBehaviour
    {
        public void Finish(string stageKey, string attemptId, bool won, double seconds, double health)
        {
            var fields = new Dictionary<string, object> { [StageFields.TimesSeen] = 0 };
            StageProvider.Complete(stageKey, attemptId, won, seconds, health, fields, r =>
            {
                if (!r.IsSuccess)
                {
                    Debug.LogWarning(r.Error.Code + ": " + r.Error.Message);
                    return;
                }

                var result = r.Data;
                Debug.Log("stars " + result.Stars + ", time saved " + result.TimeSavedPercent + "%");
                foreach (var c in result.Criteria)
                {
                    Debug.Log(c.Field + " = " + (c.WasSent ? c.Value.ToString() : "-") + " → " + c.Stars);
                }

                foreach (var id in result.MilestoneIds)
                {
                    Debug.Log("milestone paid " + id);
                }

                var canReplay = result.Replayable ?? true;
            });
        }
    }

    public sealed class ServerStageMap : MonoBehaviour
    {
        private PlayerProgress _progress;

        public void Load()
        {
            StageProvider.Get(r =>
            {
                if (!r.IsSuccess)
                {
                    Debug.LogWarning(r.Error.Code + ": " + r.Error.Message);
                    return;
                }

                _progress = r.Data;
                foreach (var stage in _progress.Chapters.SelectMany(c => c.Stages))
                {
                    if (string.IsNullOrEmpty(stage.UnityLevelId))
                    {
                        Debug.LogWarning("stage " + stage.Key + " has no unityLevelId");
                    }
                }
            });
        }

        public PlayerStage Find(string levelCardId, string context) => _progress?.FindByUnityLevel(levelCardId, context);
    }

    public sealed class FakeButton
    {
        public bool interactable;
    }

    public sealed class FakeFreeRideConfig
    {
        public float secondsBeforeFirstOffer;
        public float secondsBetweenOffers;
        public int spawnAttempts;
        public bool logOffers;
    }

    public sealed class Statements
    {
        public readonly string stageKey = "s";
        public readonly string attemptId = "a";
        public readonly string partKey = "p";
        public readonly PlayerStage stage = null;
        public readonly FakeButton startButton = new FakeButton();
        public readonly FakeFreeRideConfig config = new FakeFreeRideConfig();

        public void Snippet0()
        {
            StageProvider.Complete(
                stageKey,
                attemptId,
                true,
                96.4,
                81,
                new Dictionary<string, object> { [StageFields.TimesSeen] = 1 },
                r => { });
        }

        public void Snippet1()
        {
            startButton.interactable = stage.CanStart;
            StageProvider.Start(stage.Key, r =>
            {
                if (!r.IsSuccess && r.Error.Code == StageErrorCodes.AlreadyWon)
                {
                    startButton.interactable = false;
                }
            });
        }

        public void Snippet2()
        {
            StageProvider.Get(r =>
            {
                if (!r.IsSuccess)
                {
                    return;
                }

                var offers = r.Data.FreeRideOffers;
                config.secondsBeforeFirstOffer = (float)offers.SecondsBeforeFirstOffer;
                config.secondsBetweenOffers = (float)offers.SecondsBetweenOffers;
                config.spawnAttempts = offers.SpawnAttempts;
                config.logOffers = offers.LogOffers;
            });
        }

    }
}

namespace GuideCheck.Sections10To12.S11
{
    using PolicePatrol.Sdk.Analytics;
    using PolicePatrol.Sdk.Inventory;
    using PolicePatrol.Sdk.Stages;
    using PolicePatrol.Sdk.Stats;
    using PolicePatrol.Sdk;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using UnityEngine;

    public static class Thresholds
    {
        public static void Show()
        {
            StatsProvider.Config(r =>
            {
                if (r.IsSuccess)
                {
                    Debug.Log("big jump from " + r.Data.BigJumpHeight + " m, mm overtake under " + r.Data.MmOvertakeGap + " m");
                }
            });
        }
    }

    public sealed class TrophyScreen : MonoBehaviour
    {
        public void Load(string group)
        {
            StatsProvider.Trophies(group, r =>
            {
                if (!r.IsSuccess)
                {
                    Debug.LogWarning(r.Error.Code + ": " + r.Error.Message);
                    return;
                }

                Debug.Log("claimable " + r.Data.Totals.Claimable + " of " + r.Data.Totals.Unlocked);
                foreach (var g in r.Data.Groups)
                {
                    foreach (var trophy in g.Trophies)
                    {
                        foreach (var step in trophy.Steps)
                        {
                            Debug.Log(trophy.Name + " · " + step.Name + " progress=" + step.Progress + " claimable=" + step.Claimable);
                            foreach (var c in step.Conditions)
                            {
                                Debug.Log("  " + c.StatName + " " + c.Current + " / " + c.Target + (c.IsAnyTag ? " (best car)" : string.Empty));
                            }
                        }
                    }
                }
            });
        }

        public void Claim(TrophyInfo trophy, TrophyStep step)
        {
            StatsProvider.Claim(trophy.Key, step.Step, r =>
            {
                if (!r.IsSuccess)
                {
                    Debug.LogWarning(r.Error.Code + ": " + r.Error.Message);
                    return;
                }

                foreach (var coin in r.Data.Rewards.Currencies)
                {
                    Debug.Log("claimed " + coin.Value + " " + coin.Key);
                }
            });
        }
    }

    public sealed class TrophyToast : MonoBehaviour
    {
        private void OnEnable() => StatsProvider.TrophyStepUnlocked += Show;

        private void OnDisable() => StatsProvider.TrophyStepUnlocked -= Show;

        private void Show(TrophyUnlock unlock)
        {
            Debug.Log(unlock.Title + (unlock.Claimable ? " · claim your prize" : string.Empty));
        }
    }

    public sealed class FakeButton
    {
        public bool interactable;
    }

    public sealed class FakeFreeRideConfig
    {
        public float secondsBeforeFirstOffer;
        public float secondsBetweenOffers;
        public int spawnAttempts;
        public bool logOffers;
    }

    public sealed class Statements
    {
        public readonly string stageKey = "s";
        public readonly string attemptId = "a";
        public readonly string partKey = "p";
        public readonly PlayerStage stage = null;
        public readonly FakeButton startButton = new FakeButton();
        public readonly FakeFreeRideConfig config = new FakeFreeRideConfig();

        public void Snippet0()
        {
            PolicePatrolEvents.SetVehicle("HyundaiSantafe", "SUV");
            PolicePatrolEvents.SetGun("gun-handgun-mp5", "Handgun");
            PolicePatrolEvents.SetMission(PolicePatrolEvents.StoryMode, stageKey, attemptId);
        }

        public void Snippet1()
        {
            PolicePatrolEvents.Jump(3.4, 22.0, 1.2);
            PolicePatrolEvents.Overtake(0.35, true, 182.0);
        }

        public void Snippet2()
        {
            StageProvider.Complete(
                "chapter-close-beta-level-01",
                attemptId,
                true,
                84.2,
                100,
                new Dictionary<string, object>
                {
                    [StageFields.Vehicle] = "HyundaiSantafe",
                    [StageFields.VehicleClass] = "SUV",
                    [StageFields.Gun] = "gun-handgun-mp5",
                    [StageFields.GunClass] = "Handgun",
                },
                r =>
                {
                    if (!r.IsSuccess)
                    {
                        return;
                    }

                    foreach (var unlock in r.Data.Unlocks)
                    {
                        Debug.Log("Trophy: " + unlock.Title + (unlock.Claimable ? " (claim)" : string.Empty));
                    }
                });
        }

        public void Snippet3()
        {
            StatsProvider.Mine(new[] { "vehicle_distance_km", "stages_won_day" }, r =>
            {
                if (!r.IsSuccess)
                {
                    return;
                }

                var distance = r.Data.First(s => s.Key == "vehicle_distance_km");
                Debug.Log("all cars " + distance.Value + " km, Santa Fe " + distance.Tag("vehicle", "HyundaiSantafe")?.Value + " km");
                foreach (var row in distance.TagsOf("vehicleClass"))
                {
                    Debug.Log(row.Label + ": " + row.Value);
                }

                var today = r.Data.First(s => s.Key == "stages_won_day");
                Debug.Log("today " + today.Current + ", best day " + today.Value);
            });
        }

    }
}

namespace GuideCheck.Sections10To12.S12
{
    using PolicePatrol.Sdk.Analytics;
    using PolicePatrol.Sdk.Inventory;
    using PolicePatrol.Sdk.Stages;
    using PolicePatrol.Sdk.Stats;
    using PolicePatrol.Sdk;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using UnityEngine;

    public static class Garage
    {
        public static void LoadCars(Action<ApiResult<PlayerInventory>> done) => InventoryProvider.Get(ItemTypes.Vehicle, true, done);

        public static void LoadParts(Action<ApiResult<PlayerInventory>> done) => InventoryProvider.Get(ItemTypes.Part, true, done);
    }

    public static class PartEquip
    {
        public static void Equip(string partKey)
        {
            InventoryProvider.Equip(partKey, r =>
            {
                if (!r.IsSuccess)
                {
                    Debug.LogWarning(r.Error.Code + ": " + r.Error.Message);
                    return;
                }

                Debug.Log("slot " + r.Data.Slot + ", removed " + string.Join(", ", r.Data.Unequipped));
            });
        }

        public static void Remove(string partKey) => InventoryProvider.Unequip(partKey, r => { });
    }

    public static class StageWithCar
    {
        public static void Begin(string stageKey, string carId)
        {
            StageProvider.Start(stageKey, carId, r =>
            {
                if (r.IsSuccess)
                {
                    Debug.Log("attempt " + r.Data.AttemptId + " with " + r.Data.Item?.ItemKey);
                    return;
                }

                switch (r.Error.Code)
                {
                    case StageErrorCodes.ItemNotAllowed:
                        Debug.Log("this car is not allowed here: " + r.Error.Meta?["reason"]);
                        break;
                    case StageErrorCodes.ItemNotOwned:
                        Debug.Log("buy this car first");
                        break;
                    case StageErrorCodes.ItemRequired:
                        Debug.Log("pick a car first");
                        break;
                }
            });
        }
    }

    public sealed class CarGarage : MonoBehaviour
    {
        private PlayerInventory _cars;
        private PlayerInventory _parts;

        public void Load()
        {
            Garage.LoadCars(r =>
            {
                if (!r.IsSuccess)
                {
                    return;
                }

                _cars = r.Data;
                foreach (var car in _cars.Cars)
                {
                    Debug.Log(car.CarProfile.GameId + " (" + car.CarProfile.CarClass + ") owned=" + car.Owned);
                    foreach (var stat in car.Stats)
                    {
                        Debug.Log("  " + stat.Key + " " + stat.Value.Base + " + " + stat.Value.Bonus + " = " + stat.Value.Total);
                    }
                }
            });
            Garage.LoadParts(r => _parts = r.IsSuccess ? r.Data : _parts);
        }

        public void BuyAndEquip(string partKey)
        {
            var part = _parts?.Items.FirstOrDefault(p => p.Key == partKey);
            if (part?.PartProfile == null || !part.PartProfile.Sellable)
            {
                return;
            }

            InventoryProvider.Buy(partKey, r =>
            {
                if (r.IsSuccess)
                {
                    InventoryProvider.Equip(partKey, e => Load());
                }
                else
                {
                    Debug.LogWarning(r.Error.Code + ": " + r.Error.Message);
                }
            });
        }
    }

    public sealed class FakeButton
    {
        public bool interactable;
    }

    public sealed class FakeFreeRideConfig
    {
        public float secondsBeforeFirstOffer;
        public float secondsBetweenOffers;
        public int spawnAttempts;
        public bool logOffers;
    }

    public sealed class Statements
    {
        public readonly string stageKey = "s";
        public readonly string attemptId = "a";
        public readonly string partKey = "p";
        public readonly PlayerStage stage = null;
        public readonly FakeButton startButton = new FakeButton();
        public readonly FakeFreeRideConfig config = new FakeFreeRideConfig();

        public void Snippet0()
        {
            InventoryProvider.Buy(partKey, r =>
            {
                if (r.IsSuccess)
                {
                    InventoryProvider.Equip(partKey, e => { });
                    return;
                }

                switch (r.Error.Code)
                {
                    case InventoryErrorCodes.PartVehicleNotOwned:
                        Debug.Log("buy the car first: " + r.Error.Meta?["vehicleKey"]);
                        break;
                    case InventoryErrorCodes.RequiresItem:
                        Debug.Log("buy the previous level first");
                        break;
                    case InventoryErrorCodes.NotForSale:
                        Debug.Log("this part is not for sale");
                        break;
                }
            });
        }

    }
}
