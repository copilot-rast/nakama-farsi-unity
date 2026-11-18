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
        public void APlaceholderWithoutAValueIsNotShown()
        {
            Assert.Equal("برای کد تازه چند ثانیه صبر کنید.", ErrorCatalog.Fill("برای کد تازه {retryAfter} ثانیه صبر کنید.", null, "fa"));
            Assert.Equal("Wait a few seconds before asking for a new code.", ErrorCatalog.Fill("Wait {retryAfter} seconds before asking for a new code.", new JObject(), "en"));
            Assert.Equal("برای کد تازه ۴۰ ثانیه صبر کنید.", ErrorCatalog.Fill("برای کد تازه {retryAfter} ثانیه صبر کنید.", new JObject { ["retryAfter"] = 40 }, "fa"));
            Assert.Equal("از سطح باز می‌شود", ErrorCatalog.Fill("از سطح {unlockLevel} باز می‌شود", null, "fa"));

            var c = new ErrorCatalog(new MemoryKeyValueStore());
            c.Apply("{\"lang\":\"fa\",\"errors\":{\"OTP_TOO_SOON\":{\"status\":429,\"message\":\"برای کد تازه {retryAfter} ثانیه صبر کنید.\"}}}", "\"v1\"", DateTimeOffset.UtcNow);
            var bare = ErrorParser.Parse("OTP_TOO_SOON", 429, c, "fa");
            Assert.Equal("برای کد تازه چند ثانیه صبر کنید.", bare.Message);
            var top = ErrorParser.Parse("{\"code\":\"OTP_TOO_SOON\",\"retryAfterSeconds\":30}", 429, c, "fa");
            Assert.Equal("برای کد تازه ۳۰ ثانیه صبر کنید.", top.Message);
        }

        [Fact]
        public void TopLevelFieldsOfASuspensionNoticeGoToMeta()
        {
            var e = ErrorParser.Parse("{\"code\":\"ACCOUNT_SUSPENDED\",\"kind\":\"suspend\",\"until\":\"2026-12-01T00:00:00Z\",\"reason\":\"تقلب\",\"lang\":\"fa\"}", 403, Catalog(), "fa");
            Assert.Equal("ACCOUNT_SUSPENDED", e.Code);
            Assert.Equal("suspend", (string)e.Meta["kind"]);
            Assert.Equal("2026-12-01T00:00:00Z", (string)e.Meta["until"]);
            Assert.Equal("تقلب", (string)e.Meta["reason"]);
            Assert.Null(e.Meta["code"]);
            Assert.Null(e.Meta["lang"]);

            var nested = ErrorParser.Parse("{\"code\":\"X_Y\",\"until\":\"top\",\"meta\":{\"until\":\"inner\"}}", 400, null, "fa");
            Assert.Equal("inner", (string)nested.Meta["until"]);
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
