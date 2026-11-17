using System.Linq;
using PolicePatrol.Sdk.Assets;

namespace PolicePatrol.Sdk.Editor
{
    public sealed class AssetSyncSession
    {
        public AssetSyncSession(AssetScanResult scan, AssetDiffEntry[] diff)
        {
            Scan = scan;
            Diff = diff;
        }

        public AssetScanResult Scan { get; }

        public AssetDiffEntry[] Diff { get; }

        public AssetDiffEntry[] With(params AssetSyncStatus[] statuses) => Diff.Where(entry => statuses.Contains(entry.Status)).ToArray();
    }
}
