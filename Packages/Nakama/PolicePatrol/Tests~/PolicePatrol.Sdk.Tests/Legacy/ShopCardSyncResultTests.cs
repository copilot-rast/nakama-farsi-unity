using FluentAssertions;
using Newtonsoft.Json;
using PolicePatrol.Sdk.Editor;
using Xunit;

namespace PolicePatrol.Sdk.Tests;

public sealed class ShopCardSyncResultTests
{
    [Fact]
    public void The_upload_answer_of_the_server_is_read_with_every_row()
    {
        const string body = "{\"dryRun\":true,\"rows\":[{\"key\":\"car\",\"action\":\"created\",\"errorCode\":null},{\"key\":\"pack\",\"action\":\"failed\",\"errorCode\":\"SHOP_PRODUCT_SHOP_WITH_NAME_ALREADY_EXISTS\"}]}";

        var result = JsonConvert.DeserializeObject<ShopCardSyncResult>(body, SdkJson.Settings);

        result.DryRun.Should().BeTrue();
        result.Rows.Should().HaveCount(2);
        result.Rows[0].Key.Should().Be("car");
        result.Rows[1].ErrorCode.Should().Be("SHOP_PRODUCT_SHOP_WITH_NAME_ALREADY_EXISTS");
    }
}
