using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Nakama;
using Xunit;

namespace NakamaFarsi.Sdk.Tests
{
    public class FakeProxy : DispatchProxy
    {
        public Dictionary<string, Delegate> Handlers { get; } = new Dictionary<string, Delegate>();

        public List<(string Name, object[] Args)> Calls { get; } = new List<(string, object[])>();

        public Func<string, object[], object> Answer { get; set; }

        public bool Connected { get; set; }

        protected override object Invoke(MethodInfo method, object[] args)
        {
            lock (Calls)
            {
                Calls.Add((method.Name, args));
            }

            if (method.Name.StartsWith("add_", StringComparison.Ordinal))
            {
                Handlers[method.Name.Substring(4)] = (Delegate)args[0];
                return null;
            }

            if (method.Name == "get_IsConnected")
            {
                return Connected;
            }

            if (method.Name == "ConnectAsync")
            {
                Connected = true;
            }

            var answer = Answer?.Invoke(method.Name, args);
            if (answer != null)
            {
                return answer;
            }

            if (method.ReturnType == typeof(Task))
            {
                return Task.CompletedTask;
            }

            return method.ReturnType.IsValueType && method.ReturnType != typeof(void) ? Activator.CreateInstance(method.ReturnType) : null;
        }
    }

    public class ChatTests
    {
        private static IChannel Channel(string id)
        {
            var channel = DispatchProxy.Create<IChannel, FakeProxy>();
            ((FakeProxy)(object)channel).Answer = (name, args) => name == "get_Id" ? id : null;
            return channel;
        }

        [Fact]
        public async Task RoomsKeepHistoryAndAreJoinedAgainAfterAReconnect()
        {
            var sockets = new List<FakeProxy>();
            ISocket Make(IClient c)
            {
                var socket = DispatchProxy.Create<ISocket, FakeProxy>();
                var fake = (FakeProxy)(object)socket;
                fake.Answer = (name, args) => name == "JoinChatAsync" ? Task.FromResult(Channel("2...lobby")) : null;
                lock (sockets)
                {
                    sockets.Add(fake);
                }

                return socket;
            }

            var clock = new FakeClock { UtcNow = DateTimeOffset.UtcNow };
            var client = new NakamaFarsiClient(new NakamaFarsiOptions { UseSocket = true }, Jwt.StoreWithSession(clock.UtcNow), socketFactory: Make);
            await client.Socket.ConnectAsync();
            var channel = await client.Chat.JoinRoomAsync("lobby");
            Assert.Equal("2...lobby", channel.Id);
            var join = sockets[0].Calls.Single(c => c.Name == "JoinChatAsync");
            Assert.Equal(true, join.Args[2]);

            var rejoined = new TaskCompletionSource<IChannel>();
            client.Chat.Rejoined += ch => rejoined.TrySetResult(ch);
            ((Action<string>)sockets[0].Handlers["Closed"])("gone");
            var again = await rejoined.Task.WaitAsync(TimeSpan.FromSeconds(10));
            Assert.Equal("2...lobby", again.Id);
            Assert.Equal(2, sockets.Count);
            var second = sockets[1].Calls.Single(c => c.Name == "JoinChatAsync");
            Assert.Equal("lobby", second.Args[0]);
            Assert.Equal(true, second.Args[2]);

            await client.Chat.LeaveAsync("2...lobby");
            Assert.Empty(client.Chat.JoinedChannelIds);
        }
    }
}
