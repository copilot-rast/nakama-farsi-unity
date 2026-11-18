using System.IO;
using Xunit;

namespace NakamaFarsi.Sdk.Tests
{
    public class StoreTests
    {
        [Fact]
        public void LargeValuesGoToTheFile()
        {
            var dir = Path.Combine(Path.GetTempPath(), "nf-store-" + System.Guid.NewGuid().ToString("N"));
            var path = Path.Combine(dir, "s.json");
            var prefs = new MemoryKeyValueStore();
            var store = new FallbackKeyValueStore(prefs, new FileKeyValueStore(path), 10);
            store.Set("small", "abc");
            store.Set("big", new string('x', 100));
            store.Save();
            Assert.Equal("abc", prefs.Get("small"));
            Assert.NotEqual(new string('x', 100), prefs.Get("big"));

            var again = new FallbackKeyValueStore(prefs, new FileKeyValueStore(path), 10);
            Assert.Equal(new string('x', 100), again.Get("big"));
            again.Set("big", "s");
            again.Save();
            Assert.Equal("s", new FallbackKeyValueStore(prefs, new FileKeyValueStore(path), 10).Get("big"));
            Directory.Delete(dir, true);
        }
    }
}
