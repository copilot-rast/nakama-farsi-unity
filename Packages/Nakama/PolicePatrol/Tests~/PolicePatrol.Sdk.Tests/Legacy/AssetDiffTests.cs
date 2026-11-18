using FluentAssertions;
using PolicePatrol.Sdk.Assets;
using Xunit;

namespace PolicePatrol.Sdk.Tests;

public sealed class AssetDiffTests
{
    [Fact]
    public void Every_local_and_server_state_gets_the_right_status()
    {
        var local = new[]
        {
            Local("same", "h1"),
            Local("new", "h1"),
            Local("changed", "h2"),
            Local("server-newer", "h1"),
            Local("conflict", "h2"),
            Local("differs", "h2"),
            Local("other-file", "h1", guid: "another-file"),
            Local("moved", "h1", folder: "Cars/Old"),
        };
        var server = new[]
        {
            Remote("same", 1, "h1"),
            Remote("changed", 3, "h1"),
            Remote("server-newer", 4, "h9"),
            Remote("conflict", 4, "h9"),
            Remote("differs", 2, "h1"),
            Remote("other-file", 1, "h1"),
            Remote("moved", 2, "h1"),
            Remote("server-only", 1, "h1"),
        };
        var synced = new Dictionary<string, AssetSyncRecord>
        {
            ["changed"] = Record("changed", 3, "h1"),
            ["server-newer"] = Record("server-newer", 3, "h1"),
            ["conflict"] = Record("conflict", 3, "h1"),
            ["moved"] = Record("moved", 2, "h1"),
        };

        var statuses = AssetDiff.Compare(local, server, synced).ToDictionary(e => e.AssetId, e => e.Status);

        statuses.Should().BeEquivalentTo(new Dictionary<string, AssetSyncStatus>
        {
            ["same"] = AssetSyncStatus.Same,
            ["new"] = AssetSyncStatus.New,
            ["changed"] = AssetSyncStatus.Changed,
            ["server-newer"] = AssetSyncStatus.ServerNewer,
            ["conflict"] = AssetSyncStatus.Conflict,
            ["differs"] = AssetSyncStatus.Differs,
            ["other-file"] = AssetSyncStatus.OtherFile,
            ["moved"] = AssetSyncStatus.Changed,
            ["server-only"] = AssetSyncStatus.ServerOnly,
        });
    }

    private static LocalAssetInfo Local(string id, string hash, string guid = null, string folder = "Cars") =>
        new(id, guid ?? "g-" + id, "CarData", folder, id, hash);

    private static AssetManifestItem Remote(string id, int version, string hash) =>
        new(id, "g-" + id, "CarData", "Cars", id, version, hash);

    private static AssetSyncRecord Record(string id, int version, string hash) =>
        new(version, AssetSyncRecord.FingerprintOf(hash, "Cars", id, "CarData"));
}
