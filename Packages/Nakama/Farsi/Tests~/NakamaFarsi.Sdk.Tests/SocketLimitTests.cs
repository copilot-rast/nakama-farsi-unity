using System.Reflection;
using Nakama;
using Xunit;

namespace NakamaFarsi.Sdk.Tests
{
    public class SocketLimitTests
    {
        private static int ReadLimit(ISocketAdapter adapter) =>
            (int)typeof(WebSocketStdlibAdapter).GetField("_maxMessageReadSize", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(adapter);

        [Fact]
        public void TheSocketReadsMessagesLargerThanTheNakamaDefault()
        {
            Assert.Equal(262144, ReadLimit(new WebSocketStdlibAdapter()));
            Assert.Equal(NakamaFarsiOptions.DefaultSocketMaxMessageBytes, new NakamaFarsiOptions().SocketMaxMessageBytes);
            Assert.Equal(NakamaFarsiOptions.DefaultSocketMaxMessageBytes, ReadLimit(SocketManager.Adapter(0)));
            Assert.Equal(1 << 20, ReadLimit(SocketManager.Adapter(1 << 20)));
        }
    }
}
