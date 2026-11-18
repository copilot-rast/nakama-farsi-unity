using System;
using Newtonsoft.Json.Linq;
using Xunit;

namespace NakamaFarsi.Sdk.Tests
{
    public class ErrorTests
    {
        private static ErrorCatalog Catalog()
        {
            var c = new ErrorCatalog(new MemoryKeyValueStore());
            c.Apply("{\"lang\":\"fa\",\"cacheSeconds\":60,\"errors\":{\"STAGE_LOCKED\":{\"status\":423,\"message\":\"از سطح {unlockLevel} باز می‌شود\"},\"GIFT_EXPIRED\":{\"status\":410,\"message\":\"کد هدیه منقضی شده\",\"retryAfterSeconds\":5}}}", "\"v1\"", DateTimeOffset.UtcNow);
            return c;
        }

        [Fact]
        public void EnvelopeIsUsedAsIs()
        {
            var e = ErrorParser.Parse("{\"code\":\"ANALYTICS_RATE_LIMITED\",\"status\":429,\"message\":\"زیاد\",\"meta\":{\"retryAfter\":12},\"retryAfterSeconds\":12,\"lang\":\"fa\"}", 429, Catalog(), "fa");
            Assert.Equal("ANALYTICS_RATE_LIMITED", e.Code);
            Assert.Equal(429, e.Status);
            Assert.Equal("زیاد", e.Message);
            Assert.Equal(12, e.RetryAfterSeconds);
            Assert.True(e.IsRetryable);
        }

        [Fact]
        public void BareCodeUsesCatalogWithPlaceholders()
        {
            var e = ErrorParser.Parse("GIFT_EXPIRED", 400, Catalog(), "fa");
            Assert.Equal(410, e.Status);
            Assert.Equal("کد هدیه منقضی شده", e.Message);
            Assert.Equal(5, e.RetryAfterSeconds);

            var locked = ErrorParser.Parse("{\"code\":\"STAGE_LOCKED\",\"status\":423,\"meta\":{\"unlockLevel\":5}}", 400, Catalog(), "fa");
            Assert.Equal("از سطح ۵ باز می‌شود", locked.Message);
            Assert.Equal(5, (int)locked.Meta["unlockLevel"]);
        }

        [Fact]
        public void UnknownCodeAndPlainText()
        {
            var e = ErrorParser.Parse("NOT_IN_CATALOG", 409, Catalog(), "fa");
            Assert.Equal("NOT_IN_CATALOG", e.Code);
            Assert.Equal(409, e.Status);
            Assert.Equal(string.Empty, e.Message);

            var nf = ErrorParser.Parse("RPC function not found", 404, null, "fa");
            Assert.Equal("RPC_NOT_FOUND", nf.Code);
            var html = ErrorParser.Parse("<html>bad gateway</html>", 502, null, "fa");
            Assert.Equal("HTTP_502", html.Code);
            Assert.True(html.IsRetryable);
        }

        [Fact]
        public void CatalogSurvivesRestart()
        {
            var store = new MemoryKeyValueStore();
            var a = new ErrorCatalog(store);
            a.Apply("{\"lang\":\"en\",\"errors\":{\"X_Y\":{\"status\":400,\"message\":\"Bad {what}\"}}}", "\"e1\"", DateTimeOffset.UtcNow);
            var b = new ErrorCatalog(store);
            Assert.Equal("\"e1\"", b.ETag);
            Assert.True(b.TryResolve("X_Y", new JObject { ["what"] = "thing" }, out _, out var text));
            Assert.Equal("Bad thing", text);
        }
    }
}
