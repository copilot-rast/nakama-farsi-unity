using FluentAssertions;
using PolicePatrol.Sdk.Assets;
using Xunit;

namespace PolicePatrol.Sdk.Tests;

public sealed class AssetPathsTests
{
    [Theory]
    [InlineData("Assets/Common/Config/Asset/Vehicle_Tiggo8/Exhaust/Tiggo8_Exhaust-3 .asset", "Common/Config/Asset/Vehicle_Tiggo8/Exhaust")]
    [InlineData("Assets/Car.asset", "")]
    [InlineData("Assets/Cars /BMW\\M3.asset", "Cars/BMW")]
    [InlineData("Packages/com.x/Data/Car.asset", "Packages/com.x/Data")]
    public void Folder_of_an_asset_path_matches_the_server_rule(string path, string folder) =>
        AssetPaths.FolderOfAssetPath(path).Should().Be(folder);

    [Theory]
    [InlineData("7ae680df-5f44-49e3-bf34-c3889b93c839", true)]
    [InlineData("Tiggo8", true)]
    [InlineData("car:bmw.m3_v2", true)]
    [InlineData("has space", false)]
    [InlineData("", false)]
    [InlineData("ماشین", false)]
    public void Ids_follow_the_server_rule(string id, bool valid) =>
        AssetPaths.IsValidId(id).Should().Be(valid);
}
