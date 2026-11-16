#if UNITY_5_3_OR_NEWER
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace NakamaFarsi.Sdk.Unity
{
    public sealed class PlayerPrefsKeyValueStore : IKeyValueStore
    {
        public string Get(string key) => PlayerPrefs.HasKey(key) ? PlayerPrefs.GetString(key) : null;

        public void Set(string key, string value) => PlayerPrefs.SetString(key, value ?? string.Empty);

        public void Delete(string key) => PlayerPrefs.DeleteKey(key);

        public void Save() => PlayerPrefs.Save();
    }

    public static class UnityStores
    {
        public static IKeyValueStore Default(string fileName = "nakamafarsi-store.json") =>
            new FallbackKeyValueStore(new PlayerPrefsKeyValueStore(), new FileKeyValueStore(Path.Combine(Application.persistentDataPath, fileName)));
    }

    public sealed class UnityLogger : ISdkLogger
    {
        public void Log(string message) => Debug.Log("[NakamaFarsi] " + message);

        public void Warn(string message) => Debug.LogWarning("[NakamaFarsi] " + message);
    }

    public sealed class UnityMainThreadDispatcher : IMainThreadDispatcher
    {
        private readonly ConcurrentQueue<Action> _queue = new ConcurrentQueue<Action>();
        private readonly int _mainThread;

        public UnityMainThreadDispatcher()
        {
            _mainThread = Thread.CurrentThread.ManagedThreadId;
        }

        public void Post(Action action)
        {
            if (action == null)
            {
                return;
            }

            _queue.Enqueue(action);
        }

        public bool IsMainThread => Thread.CurrentThread.ManagedThreadId == _mainThread;

        public void Pump(int max = 256)
        {
            for (var i = 0; i < max && _queue.TryDequeue(out var a); i++)
            {
                try
                {
                    a();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }
    }

    public sealed class UnityWebRequestGet : IHttpGet
    {
        private readonly UnityMainThreadDispatcher _dispatcher;

        public UnityWebRequestGet(UnityMainThreadDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public Task<HttpGetResult> GetAsync(string url, IDictionary<string, string> headers, int timeoutSeconds, CancellationToken ct)
        {
            var tcs = new TaskCompletionSource<HttpGetResult>();
            _dispatcher.Post(() =>
            {
                var req = UnityWebRequest.Get(url);
                req.timeout = Math.Max(1, timeoutSeconds);
                foreach (var h in headers ?? new Dictionary<string, string>())
                {
                    req.SetRequestHeader(h.Key, h.Value);
                }

                req.SendWebRequest().completed += _ =>
                {
                    if (req.result == UnityWebRequest.Result.ConnectionError)
                    {
                        tcs.TrySetException(new IOException(req.error));
                    }
                    else
                    {
                        int? maxAge = null;
                        var cc = req.GetResponseHeader("Cache-Control");
                        if (cc != null && cc.Contains("max-age="))
                        {
                            int.TryParse(cc.Substring(cc.IndexOf("max-age=", StringComparison.Ordinal) + 8).Split(',')[0], out var v);
                            maxAge = v;
                        }

                        tcs.TrySetResult(new HttpGetResult(req.responseCode, req.downloadHandler?.text, req.GetResponseHeader("ETag"), maxAge));
                    }

                    req.Dispose();
                };
            });
            return tcs.Task;
        }
    }
}
#endif
