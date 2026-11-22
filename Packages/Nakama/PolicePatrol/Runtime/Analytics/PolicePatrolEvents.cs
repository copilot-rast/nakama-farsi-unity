using System.Collections.Generic;

namespace PolicePatrol.Sdk.Analytics
{
    public static class PolicePatrolEvents
    {
        public const string StoryMode = "story";
        public const string FreeRideMode = "freeride";

        public static void SetVehicle(string vehicle, string vehicleClass)
        {
            Set(PolicePatrolContextKeys.Vehicle, vehicle);
            Set(PolicePatrolContextKeys.VehicleClass, vehicleClass);
        }

        public static void SetGun(string gun, string gunClass)
        {
            Set(PolicePatrolContextKeys.Gun, gun);
            Set(PolicePatrolContextKeys.GunClass, gunClass);
        }

        public static void SetMission(string mode, string stageKey = null, string attemptId = null)
        {
            Set(PolicePatrolContextKeys.Mode, mode);
            Set(PolicePatrolContextKeys.Stage, stageKey);
            Set(PolicePatrolContextKeys.AttemptId, attemptId);
        }

        public static void ClearMission() => SetMission(null);

        public static bool Distance(double km) => Design(PolicePatrolDesignIds.VehicleDistance, km);

        public static bool DistanceForward(double km) => Design(PolicePatrolDesignIds.VehicleDistanceForward, km);

        public static bool DistanceBackward(double km) => Design(PolicePatrolDesignIds.VehicleDistanceBackward, km);

        public static bool DistanceClean(double km) => Design(PolicePatrolDesignIds.VehicleDistanceClean, km);

        public static bool CleanRun(double km) => Design(PolicePatrolDesignIds.VehicleCleanRun, km);

        public static bool DistanceTopSpeed(double km) => Design(PolicePatrolDesignIds.VehicleDistanceTopSpeed, km);

        public static bool TopSpeed(double kmh) => Design(PolicePatrolDesignIds.VehicleTopSpeed, kmh);

        public static bool Drift(double meters) => Design(PolicePatrolDesignIds.VehicleDrift, meters);

        public static bool ObstacleByCar(int count = 1) => Design(PolicePatrolDesignIds.VehicleObstacle, count);

        public static bool Turn180(int count = 1) => Design(PolicePatrolDesignIds.VehicleTurn180, count);

        public static bool Spin(int count = 1) => Design(PolicePatrolDesignIds.VehicleSpin, count);

        public static bool Thread(int count = 1) => Design(PolicePatrolDesignIds.VehicleThread, count);

        public static bool RanOut(RanOutKind kind, int count = 1) => Design(PolicePatrolDesignIds.VehicleRanOut + ":" + kind, count);

        public static bool Arrest(int count = 1) => Design(PolicePatrolDesignIds.PoliceArrest, count);

        public static bool Kill(int count = 1) => Design(PolicePatrolDesignIds.GunKill, count);

        public static bool ObstacleByGun(int count = 1) => Design(PolicePatrolDesignIds.GunObstacle, count);

        public static bool Shots(int shots, int hits, int misses)
        {
            var ok = true;
            if (shots > 0)
            {
                ok &= Design(PolicePatrolDesignIds.GunShot, shots);
            }

            if (hits > 0)
            {
                ok &= Design(PolicePatrolDesignIds.GunHit, hits);
            }

            if (misses > 0)
            {
                ok &= Design(PolicePatrolDesignIds.GunMiss, misses);
            }

            return ok;
        }

        public static bool PlayTime(double seconds) => Design(PolicePatrolDesignIds.PlayerPlayTime, seconds);

        public static bool SecretPlace(int count = 1) => Design(PolicePatrolDesignIds.DiscoverPlace, count);

        public static bool HiddenPrize(int count = 1) => Design(PolicePatrolDesignIds.DiscoverTreasure, count);

        public static bool Paint(int count = 1) => Design(PolicePatrolDesignIds.GaragePaint, count);

        public static bool Jump(double height, double length, double airTime) =>
            PolicePatrolAnalytics.Client?.AddNamedEvent(PolicePatrolDesignIds.JumpEvent, new Dictionary<string, object> { ["height"] = height, ["length"] = length, ["airTime"] = airTime }) ?? false;

        public static bool Overtake(double gap, bool topSpeed, double? speed = null)
        {
            var fields = new Dictionary<string, object> { ["gap"] = gap, ["topSpeed"] = topSpeed };
            if (speed.HasValue)
            {
                fields["speed"] = speed.Value;
            }

            return PolicePatrolAnalytics.Client?.AddNamedEvent(PolicePatrolDesignIds.OvertakeEvent, fields) ?? false;
        }

        public static bool Design(string id, double value, IDictionary<string, string> context = null) => value > 0 && PolicePatrolAnalytics.AddDesignEvent(id, value, context);

        private static void Set(string key, string value) => PolicePatrolAnalytics.SetContext(key, string.IsNullOrEmpty(value) ? null : value);
    }
}
