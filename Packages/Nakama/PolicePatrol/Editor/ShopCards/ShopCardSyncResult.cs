using System;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class ShopCardSyncResult
    {
        public bool DryRun { get; set; }

        public ShopCardRow[] Rows { get; set; } = Array.Empty<ShopCardRow>();
    }
}
