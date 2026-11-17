using System;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class StatCardSyncResult
    {
        public bool DryRun { get; set; }

        public StatCardRow[] Rows { get; set; } = Array.Empty<StatCardRow>();
    }
}
