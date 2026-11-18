using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nakama;

namespace NakamaFarsi.Sdk.Tests
{
    internal sealed class FakeClock : IClock
    {
        public DateTimeOffset UtcNow { get; set; } = new DateTimeOffset(2026, 11, 15, 10, 0, 0, TimeSpan.Zero);

        public void Advance(double seconds) => UtcNow = UtcNow.AddSeconds(seconds);
    }

    internal static class Jwt
    {
        public static string Make(DateTimeOffset expires, string userId = "11111111-2222-3333-4444-555555555555", string username = "tester")
        {
            string B64(string s) => Convert.ToBase64String(Encoding.UTF8.GetBytes(s)).TrimEnd('=').Replace('+', '-').Replace('/', '_');
            var payload = "{\"tid\":\"t\",\"uid\":\"" + userId + "\",\"usn\":\"" + username + "\",\"exp\":" + expires.ToUnixTimeSeconds() + ",\"iat\":" + expires.AddHours(-1).ToUnixTimeSeconds() + "}";
            return B64("{\"alg\":\"HS256\",\"typ\":\"JWT\"}") + "." + B64(payload) + ".c2ln";
        }

        public static MemoryKeyValueStore StoreWithSession(DateTimeOffset now)
        {
            var store = new MemoryKeyValueStore();
            store.Set("nf.session.token", Make(now.AddHours(2)));
            store.Set("nf.session.refresh", Make(now.AddDays(30)));
            return store;
        }
    }

    internal sealed class FakeTransport : IRpcTransport
    {
        public FakeTransport(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public bool IsAvailable { get; set; } = true;

        public List<(string Id, string Payload)> Calls { get; } = new List<(string, string)>();

        public Queue<object> Answers { get; } = new Queue<object>();

        public TimeSpan Delay { get; set; }

        public async Task<string> CallAsync(ISession session, string id, string payload, CancellationToken ct)
        {
            Calls.Add((id, payload));
            if (Delay > TimeSpan.Zero)
            {
                await Task.Delay(Delay, ct);
            }

            var next = Answers.Count > 0 ? Answers.Dequeue() : "{}";
            if (next is Exception e)
            {
                throw e;
            }

            return (string)next;
        }
    }

    internal sealed class FakeCaller : IRpcCaller
    {
        public string Language { get; set; } = "fa";

        public List<(string Id, string Payload, RpcCallOptions Options)> Calls { get; } = new List<(string, string, RpcCallOptions)>();

        public Queue<object> Answers { get; } = new Queue<object>();

        public Func<string, string, string> Responder { get; set; }

        public Task<string> CallRpcAsync(string id, string payload, RpcCallOptions options = null, CancellationToken ct = default)
        {
            Calls.Add((id, payload, options));
            if (Answers.Count > 0)
            {
                var next = Answers.Dequeue();
                if (next is Exception e)
                {
                    return Task.FromException<string>(e);
                }

                return Task.FromResult((string)next);
            }

            return Task.FromResult(Responder != null ? Responder(id, payload) : "{}");
        }
    }
}
