using FluentAssertions;
using Xunit;

namespace PolicePatrol.Sdk.Tests;

public sealed class ContentUrlsTests
{
    [Theory]
    [InlineData("https://s3.example/bucket/game-content/StandaloneLinux64//catalog_0.1.0.hash", "https://s3.example/bucket/game-content/StandaloneLinux64/catalog_0.1.0.hash")]
    [InlineData("https://s3.example//a///b.bundle", "https://s3.example/a/b.bundle")]
    [InlineData("https://s3.example/a/b.bundle?x=//y", "https://s3.example/a/b.bundle?x=//y")]
    [InlineData("https://s3.example/a/b.bundle", "https://s3.example/a/b.bundle")]
    [InlineData("{UnityEngine.AddressableAssets.Addressables.RuntimePath}//Android/x.bundle", "{UnityEngine.AddressableAssets.Addressables.RuntimePath}//Android/x.bundle")]
    [InlineData("", "")]
    public void Double_slashes_in_web_paths_are_collapsed(string url, string expected) =>
        ContentUrls.CollapseSlashes(url).Should().Be(expected);
}
