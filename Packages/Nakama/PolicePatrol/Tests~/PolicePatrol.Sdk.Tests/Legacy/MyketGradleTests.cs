using FluentAssertions;
using PolicePatrol.Sdk.Editor;
using Xunit;

namespace PolicePatrol.Sdk.Tests;

public sealed class MyketGradleTests
{
    private const string Launcher = "android {\n    defaultConfig {\n        minSdkVersion 23\n    }\n}\n";
    private const string Settings = "dependencyResolutionManagement {\n    repositories {\n        google()\n        mavenCentral()\n    }\n}\n";

    [Fact]
    public void AddPlaceholders_puts_the_myket_manifest_values_into_default_config_once()
    {
        var patched = MyketGradle.AddPlaceholders(Launcher);

        patched.Should().Contain("defaultConfig {\n        manifestPlaceholders += [marketApplicationId: 'ir.mservices.market', marketBindAddress: 'ir.mservices.market.InAppBillingService.BIND', marketPermission: 'ir.mservices.market.BILLING', sdkVersion: '2.2']");
        MyketGradle.AddPlaceholders(patched).Should().Be(patched);
    }

    [Fact]
    public void AddPlaceholders_leaves_a_file_without_default_config_alone()
    {
        MyketGradle.AddPlaceholders("android {}\n").Should().Be("android {}\n");
    }

    [Fact]
    public void AddRepository_adds_the_myket_maven_after_maven_central_once()
    {
        var patched = MyketGradle.AddRepository(Settings);

        patched.Should().Contain("mavenCentral()\n        maven { url 'https://maven.myket.ir' }");
        MyketGradle.AddRepository(patched).Should().Be(patched);
    }

    [Fact]
    public void AddProguard_appends_the_keep_rules_once()
    {
        var patched = MyketGradle.AddProguard("-keep class com.unity3d.** { *; }");

        patched.Should().StartWith("-keep class com.unity3d.** { *; }\n-keep class ir.myket.billingclient.** { *; }");
        MyketGradle.AddProguard(patched).Should().Be(patched);
    }

    [Fact]
    public void DependenciesXml_names_the_myket_library_and_its_maven()
    {
        MyketGradle.DependenciesXml().Should().Contain("spec=\"ir.myket:billing:2.2\"").And.Contain("<repository>https://maven.myket.ir</repository>");
    }
}
