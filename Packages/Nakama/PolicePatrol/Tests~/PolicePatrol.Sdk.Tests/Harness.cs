using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nakama;
using NakamaFarsi.Sdk;

namespace PolicePatrol.Sdk.Tests
{
    internal sealed class ScriptedTransport : IRpcTransport
    {
        public string Name => "fake";

        public bool IsAvailable => true;

        public Dictionary<string, Func<string, object>> Routes { get; } = new Dictionary<string, Func<string, object>>();

        public List<(string Id, string Payload)> Calls { get; } = new List<(string, string)>();

        public Task<string> CallAsync(ISession session, string id, string payload, CancellationToken ct)
        {
            lock (Calls)
            {
                Calls.Add((id, payload));
            }

            if (!Routes.TryGetValue(id, out var route))
            {
                throw new RpcServerException("RPC function not found", 404);
            }

            var answer = route(payload);
            if (answer is Exception e)
            {
                throw e;
            }

            return Task.FromResult((string)answer);
        }
    }

    internal static class Harness
    {
        public static ScriptedTransport Start(MemoryKeyValueStore shared = null, ScriptedTransport reuse = null, bool signedIn = true)
        {
            var transport = reuse ?? new ScriptedTransport();
            var options = new SdkOptions("http://127.0.0.1:1", "test", false, 5, "fa") { UseSocket = false };
            var coreOptions = PolicePatrolSdk.CoreOptions(options);
            var store = shared ?? new MemoryKeyValueStore();
            if (signedIn)
            {
                store.Set(coreOptions.StorePrefix + "session.token", Jwt(DateTimeOffset.UtcNow.AddHours(2)));
                store.Set(coreOptions.StorePrefix + "session.refresh", Jwt(DateTimeOffset.UtcNow.AddDays(30)));
            }

            var core = new NakamaFarsiClient(coreOptions, store, httpTransport: transport, socketTransport: transport);
            core.ErrorCatalogRetryGap = TimeSpan.MaxValue;
            core.Rpc.SignInSilently = ct =>
            {
                lock (transport.Calls)
                {
                    transport.Calls.Add(("device_sign_in", ""));
                }

                core.Session.Adopt(Jwt(DateTimeOffset.UtcNow.AddHours(2)), Jwt(DateTimeOffset.UtcNow.AddDays(30)));
                return Task.CompletedTask;
            };
            PolicePatrolSdk.Initialize(options, core);
            return transport;
        }

        public static string Jwt(DateTimeOffset expires)
        {
            string B64(string s) => Convert.ToBase64String(Encoding.UTF8.GetBytes(s)).TrimEnd('=').Replace('+', '-').Replace('/', '_');
            return B64("{\"alg\":\"HS256\"}") + "." + B64("{\"uid\":\"u-1\",\"usn\":\"p\",\"exp\":" + expires.ToUnixTimeSeconds() + "}") + ".c2ln";
        }

        public static Task<ApiResult<T>> Call<T>(Action<Action<ApiResult<T>>> call)
        {
            var tcs = new TaskCompletionSource<ApiResult<T>>(TaskCreationOptions.RunContinuationsAsynchronously);
            call(r => tcs.TrySetResult(r));
            return tcs.Task.WaitAsync(TimeSpan.FromSeconds(10));
        }
    }
}
