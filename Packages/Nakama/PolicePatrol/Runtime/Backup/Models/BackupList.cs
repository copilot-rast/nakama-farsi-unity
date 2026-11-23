using System;
using System.Collections.Generic;
using System.Linq;

namespace PolicePatrol.Sdk.Backup
{
    public sealed record BackupList(IReadOnlyList<BackupUnit> Units)
    {
        public bool Enabled { get; init; } = true;

        public bool Unlimited { get; init; }

        public string DebitOn { get; init; } = BackupDebitModes.Arrival;

        public int RefundSeconds { get; init; }

        public bool RequireRun { get; init; } = true;

        public bool EnforceCap { get; init; } = true;

        public int CallsPerMission { get; init; } = 3;

        public bool EnforceCooldown { get; init; } = true;

        public int SecondsBetweenCalls { get; init; } = 60;

        public int CarsOutAtOnce { get; init; } = 1;

        public string LimitsPer { get; init; } = "kind";

        public string AttemptId { get; init; }

        public string Mission { get; init; }

        public DateTimeOffset? ServerTime { get; init; }

        public BackupUse Use { get; init; }

        public bool DebitOnArrival => DebitOn != BackupDebitModes.Call;

        public BackupUnit Find(string key) => Units.FirstOrDefault(u => u.Key == key);

        public IEnumerable<BackupUnit> OfKind(string kind) => Units.Where(u => u.Kind == kind);

        public BackupUnit For(string kind, string unityId) =>
            Units.Where(u => u.Kind == kind && u.UnityIds.Count > 0 && unityId != null && u.UnityIds.Contains(unityId)).FirstOrDefault()
            ?? Units.FirstOrDefault(u => u.Kind == kind && u.UnityIds.Count == 0);

        public bool CanCall(BackupUnit unit) =>
            unit != null && (Unlimited || unit.Count > 0) && (unit.CallsLeft == null || unit.CallsLeft > 0) && unit.SecondsUntilNextCall <= 0;
    }
}
