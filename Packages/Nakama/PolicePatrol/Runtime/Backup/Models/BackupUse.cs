using System;

namespace PolicePatrol.Sdk.Backup
{
    public sealed record BackupUse(string RequestId, string Key, string Kind, string AttemptId, string Status)
    {
        public string Mission { get; init; }

        public string UnitId { get; init; }

        public long Debited { get; init; }

        public DateTimeOffset? At { get; init; }

        public bool Replayed { get; init; }

        public bool Refunded => Status == "refunded";
    }
}
