using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NakamaFarsi.Sdk.Analytics
{
    public sealed class AnalyticsClient
    {
        public const string TrackRpc = "analytics_track";
        public const string ConfigRpc = "analytics_config";

        private readonly object _gate = new object();
        private readonly IRpcCaller _rpc;
        private readonly IKeyValueStore _store;
        private readonly IClock _clock;
        private readonly ISdkLogger _logger;
        private readonly AnalyticsOptions _options;
        private readonly string _key;

        private readonly List<QueuedEvent> _queue = new List<QueuedEvent>();
        private JObject _dims = new JObject();
        private JObject _ctx = new JObject();
        private SessionState _session;
        private long _sessionNum;
        private DateTimeOffset? _pausedAt;
        private Inflight _inflight;

        private DateTimeOffset _nextSendAt;
        private DateTimeOffset _retryAt;
        private DateTimeOffset _nextConfigAt;
        private DateTimeOffset _lastPersist;
        private int _failures;
        private bool _sending;
        private bool _flush;
        private bool _dirty;
        private bool _configLoading;

        public AnalyticsClient(IRpcCaller rpc, IKeyValueStore store, IClock clock = null, ISdkLogger logger = null, AnalyticsOptions options = null, IMainThreadDispatcher dispatcher = null)
        {
            _rpc = rpc ?? throw new ArgumentNullException(nameof(rpc));
            _store = store ?? new MemoryKeyValueStore();
            _clock = clock ?? SystemClock.Instance;
            _logger = logger ?? NullLogger.Instance;
            _options = options ?? new AnalyticsOptions();
            Dispatcher = dispatcher ?? ImmediateDispatcher.Instance;
            Config = new AnalyticsConfig { MaxBatch = _options.DefaultMaxBatch, SendIntervalSeconds = _options.DefaultSendIntervalSeconds, SessionTimeoutSeconds = _options.DefaultSessionTimeoutSeconds };
            _key = "nf.analytics.state";
            Restore();
        }

        public IMainThreadDispatcher Dispatcher { get; set; }

        public Func<bool> CanSend { get; set; } = () => true;

        public AnalyticsConfig Config { get; private set; }

        public bool ConfigLoaded { get; private set; }

        public AnalyticsOptions Options => _options;

        public int Queued
        {
            get
            {
                lock (_gate)
                {
                    return _queue.Count + (_inflight?.Count ?? 0);
                }
            }
        }

        public bool IsSending
        {
            get
            {
                lock (_gate)
                {
                    return _sending;
                }
            }
        }

        public string SessionId => _session?.Id;

        public long SessionNum => _sessionNum;

        public int Dropped { get; private set; }

        public event Action<TrackAnswer> BatchSent;

        public event Action<ApiError, bool> BatchFailed;

        public event Action<JArray> Unlocked;

        public event Action<string> Invalid;

        public void ApplyConfig(AnalyticsConfig config)
        {
            lock (_gate)
            {
                Config = config ?? Config;
                ConfigLoaded = true;
            }
        }

        public async Task<AnalyticsConfig> LoadConfigAsync(CancellationToken ct = default)
        {
            var body = await _rpc.CallRpcAsync(ConfigRpc, new JObject { ["lang"] = _rpc.Language }.ToString(Formatting.None), RpcCallOptions.Read, ct).ConfigureAwait(false);
            var config = AnalyticsConfig.Parse(string.IsNullOrWhiteSpace(body) ? new JObject() : JObject.Parse(body));
            ApplyConfig(config);
            return config;
        }

        public void SetCustomDimension(string key, string value)
        {
            if (!Check(AnalyticsValidator.DimensionOrContextKey(key) ?? AnalyticsValidator.Value(value)))
            {
                return;
            }

            lock (_gate)
            {
                if (value == null)
                {
                    _dims.Remove(key);
                }
                else
                {
                    if (_dims[key] == null && _dims.Count >= Math.Max(1, Config.MaxDimensions))
                    {
                        Report("more than " + Config.MaxDimensions + " custom dimensions; \"" + key + "\" ignored");
                        return;
                    }

                    WarnUnknown(Config.Dimensions, key, value, "dimension");
                    _dims[key] = value;
                }

                _dirty = true;
            }
        }

        public void SetContext(string key, string value)
        {
            if (!Check(AnalyticsValidator.DimensionOrContextKey(key) ?? AnalyticsValidator.Value(value)))
            {
                return;
            }

            lock (_gate)
            {
                if (value == null)
                {
                    _ctx.Remove(key);
                }
                else
                {
                    WarnUnknown(Config.ContextKeys, key, value, "context key");
                    _ctx[key] = value;
                }

                _dirty = true;
            }
        }

        public void SetContext(IDictionary<string, string> values)
        {
            foreach (var kv in values ?? new Dictionary<string, string>())
            {
                SetContext(kv.Key, kv.Value);
            }
        }

        public void ClearContext()
        {
            lock (_gate)
            {
                _ctx = new JObject();
                _dirty = true;
            }
        }

        public IReadOnlyDictionary<string, string> Context
        {
            get
            {
                lock (_gate)
                {
                    return _ctx.Properties().ToDictionary(p => p.Name, p => (string)p.Value);
                }
            }
        }

        public bool AddDesignEvent(string eventId, double? value = null, IDictionary<string, string> context = null)
        {
            if (!Check(AnalyticsValidator.DesignId(eventId)) || (value.HasValue && !Check(AnalyticsValidator.IsNumber(value.Value) ? null : "value is not a number")))
            {
                return false;
            }

            if (_options.WarnUnknown && Config.DesignRoots.Length > 0)
            {
                var parts = eventId.Split(':');
                var root = Config.DesignRoots.FirstOrDefault(r => r.Root == parts[0]);
                if (root == null)
                {
                    _logger.Warn("design root \"" + parts[0] + "\" is not in the admin list (" + Config.UnknownDesign + ")");
                }
                else
                {
                    for (var i = 1; i < parts.Length && i - 1 < root.Levels.Length; i++)
                    {
                        if (!root.Levels[i - 1].Allows(parts[i]))
                        {
                            _logger.Warn("design level " + root.Levels[i - 1].Key + " does not list \"" + parts[i] + "\" (" + Config.UnknownDesign + ")");
                        }
                    }
                }
            }

            var e = new JObject { ["type"] = "design", ["id"] = eventId };
            if (value.HasValue)
            {
                e["value"] = value.Value;
            }

            return Enqueue(e, context);
        }

        public bool AddProgressionEvent(ProgressionStatus status, string progression01, string progression02 = null, string progression03 = null, int? score = null, IDictionary<string, string> context = null)
        {
            if (!Check(AnalyticsValidator.Progression(progression01, progression02, progression03)))
            {
                return false;
            }

            var e = new JObject { ["type"] = "progression", ["status"] = status.ToString(), ["p1"] = progression01 };
            if (!string.IsNullOrEmpty(progression02))
            {
                e["p2"] = progression02;
            }

            if (!string.IsNullOrEmpty(progression03))
            {
                e["p3"] = progression03;
            }

            if (score.HasValue)
            {
                e["score"] = score.Value;
            }

            return Enqueue(e, context);
        }

        public bool AddResourceEvent(ResourceFlow flow, string currency, double amount, string itemType, string itemId, IDictionary<string, string> context = null)
        {
            if (!Check(AnalyticsValidator.Resource(currency, amount, itemType, itemId)))
            {
                return false;
            }

            if (_options.WarnUnknown && Config.ResourceCurrencies.Length > 0 && !Config.ResourceCurrencies.Contains(currency))
            {
                _logger.Warn("resource currency \"" + currency + "\" is not in the admin list");
            }

            if (_options.WarnUnknown && Config.ResourceItemTypes.Length > 0 && !Config.ResourceItemTypes.Contains(itemType))
            {
                _logger.Warn("resource item type \"" + itemType + "\" is not in the admin list");
            }

            return Enqueue(new JObject { ["type"] = "resource", ["flow"] = flow.ToString(), ["currency"] = currency, ["amount"] = amount, ["itemType"] = itemType, ["item"] = itemId }, context);
        }

        public bool AddBusinessEvent(string currency, long amount, string itemType, string itemId, string cartType = null, string store = null, string receipt = null, IDictionary<string, string> context = null)
        {
            if (!Check(AnalyticsValidator.Business(currency, amount, itemType, itemId, cartType)))
            {
                return false;
            }

            var e = new JObject { ["type"] = "business", ["currency"] = currency, ["amount"] = amount, ["itemType"] = itemType, ["item"] = itemId };
            if (!string.IsNullOrEmpty(cartType))
            {
                e["cartType"] = cartType;
            }

            if (!string.IsNullOrEmpty(store))
            {
                e["store"] = store;
            }

            if (!string.IsNullOrEmpty(receipt))
            {
                e["receipt"] = receipt;
            }

            return Enqueue(e, context);
        }

        public bool AddErrorEvent(ErrorSeverity severity, string message, IDictionary<string, string> context = null)
        {
            if (!Check(AnalyticsValidator.Error(message)))
            {
                return false;
            }

            return Enqueue(new JObject { ["type"] = "error", ["severity"] = AnalyticsValidator.Name(severity), ["message"] = message ?? string.Empty }, context);
        }

        public bool AddNamedEvent(string name, IDictionary<string, object> fields = null, string contextKey = null)
        {
            if (!Check(AnalyticsValidator.LegacyEventName(name)))
            {
                return false;
            }

            var e = new JObject { ["name"] = name, ["fields"] = fields == null ? new JObject() : JObject.FromObject(fields) };
            if (!string.IsNullOrEmpty(contextKey))
            {
                e["context"] = contextKey;
            }

            return Enqueue(e, null);
        }

        public void StartSession()
        {
            lock (_gate)
            {
                var now = _clock.UtcNow;
                if (_session != null && !_session.Ended)
                {
                    return;
                }

                _sessionNum++;
                _session = new SessionState { Id = Guid.NewGuid().ToString("N"), Num = _sessionNum, Start = now, Last = now };
                _pausedAt = null;
                EnqueueLocked(new JObject { ["type"] = "session", ["status"] = "start" }, null, now);
                _dirty = true;
            }
        }

        public void EndSession() => EndSessionAt(null);

        public void OnPause()
        {
            lock (_gate)
            {
                var now = _clock.UtcNow;
                _pausedAt = now;
                if (_session != null)
                {
                    _session.Last = now;
                }

                _flush = true;
                _dirty = true;
                PersistLocked(now);
            }

            Tick();
        }

        public void OnResume()
        {
            DateTimeOffset? pausedAt;
            lock (_gate)
            {
                pausedAt = _pausedAt;
                _pausedAt = null;
            }

            if (pausedAt.HasValue && (_clock.UtcNow - pausedAt.Value).TotalSeconds > Math.Max(1, Config.SessionTimeoutSeconds))
            {
                EndSessionAt(pausedAt);
                StartSession();
            }
            else
            {
                StartSession();
            }
        }

        public void OnQuit()
        {
            EndSessionAt(null);
            lock (_gate)
            {
                _flush = true;
                PersistLocked(_clock.UtcNow);
            }

            Tick();
        }

        private void EndSessionAt(DateTimeOffset? at)
        {
            lock (_gate)
            {
                if (_session == null || _session.Ended)
                {
                    return;
                }

                var end = at ?? _clock.UtcNow;
                if (end < _session.Last && at == null)
                {
                    end = _session.Last;
                }

                var length = Math.Max(0, (long)Math.Round((end - _session.Start).TotalSeconds));
                EnqueueLocked(new JObject { ["type"] = "session", ["status"] = "end", ["length"] = length }, null, end);
                _session.Ended = true;
                _session.Last = end;
                _flush = true;
                _dirty = true;
            }
        }

        public void Flush()
        {
            lock (_gate)
            {
                _flush = true;
            }

            Tick();
        }

        public void Tick()
        {
            Inflight toSend = null;
            var loadConfig = false;
            lock (_gate)
            {
                var now = _clock.UtcNow;
                if (_session != null && !_session.Ended && _pausedAt == null)
                {
                    _session.Last = now;
                }

                if (_dirty && (now - _lastPersist).TotalSeconds >= _options.PersistEverySeconds)
                {
                    PersistLocked(now);
                }

                var canSend = CanSend == null || CanSend();
                if (!canSend)
                {
                    return;
                }

                if (!ConfigLoaded && !_configLoading && now >= _nextConfigAt)
                {
                    _configLoading = true;
                    loadConfig = true;
                }

                if (!_sending && now >= _retryAt)
                {
                    if (_inflight == null && _queue.Count > 0 && (_flush || now >= _nextSendAt || _queue.Count >= Config.MaxBatch))
                    {
                        _inflight = BuildLocked();
                        PersistLocked(now);
                    }

                    if (_inflight != null)
                    {
                        _sending = true;
                        toSend = _inflight;
                    }
                }
            }

            if (loadConfig)
            {
                _ = LoadConfigAsync().ContinueWith(t =>
                {
                    lock (_gate)
                    {
                        _configLoading = false;
                        if (t.IsFaulted)
                        {
                            _nextConfigAt = _clock.UtcNow.AddSeconds(60);
                        }
                    }
                }, TaskScheduler.Default);
            }

            if (toSend != null)
            {
                _ = Send(toSend);
            }
        }

        public async Task<bool> SendAllAsync(CancellationToken ct = default)
        {
            for (var guard = 0; guard < 1000; guard++)
            {
                Inflight batch;
                lock (_gate)
                {
                    if (_sending)
                    {
                        batch = null;
                    }
                    else
                    {
                        if (_inflight == null && _queue.Count > 0)
                        {
                            _inflight = BuildLocked();
                            PersistLocked(_clock.UtcNow);
                        }

                        if (_inflight == null)
                        {
                            return true;
                        }

                        _sending = true;
                        batch = _inflight;
                    }
                }

                if (batch == null)
                {
                    await Task.Delay(20, ct).ConfigureAwait(false);
                    continue;
                }

                if (!await Send(batch).ConfigureAwait(false))
                {
                    return false;
                }
            }

            return false;
        }

        public void Persist()
        {
            lock (_gate)
            {
                PersistLocked(_clock.UtcNow);
            }
        }

        private async Task<bool> Send(Inflight batch)
        {
            try
            {
                var body = await _rpc.CallRpcAsync(TrackRpc, batch.Payload, new RpcCallOptions { Idempotent = true }).ConfigureAwait(false);
                var answer = TrackAnswer.Parse(body);
                lock (_gate)
                {
                    var now = _clock.UtcNow;
                    _sending = false;
                    _inflight = null;
                    _failures = 0;
                    _retryAt = now;
                    _nextSendAt = now.AddSeconds(Math.Max(1, Config.SendIntervalSeconds));
                    if (_queue.Count == 0)
                    {
                        _flush = false;
                    }

                    PersistLocked(now);
                }

                Dispatcher.Post(() =>
                {
                    BatchSent?.Invoke(answer);
                    if (answer.Unlocked.Count > 0)
                    {
                        Unlocked?.Invoke(answer.Unlocked);
                    }
                });
                return true;
            }
            catch (Exception ex)
            {
                var error = ex is ApiException api ? api.Error : ApiError.Network(ex.Message);
                var retry = Retryable(error);
                lock (_gate)
                {
                    var now = _clock.UtcNow;
                    _sending = false;
                    if (retry)
                    {
                        _failures++;
                        var backoff = Math.Min(300, 5 * Math.Pow(2, Math.Min(6, _failures - 1)));
                        var wait = Math.Max(backoff, error.RetryAfterSeconds ?? 0);
                        _retryAt = now.AddSeconds(wait);
                    }
                    else
                    {
                        _logger.Warn("analytics batch " + batch.BatchId + " dropped: " + error);
                        Dropped += batch.Count;
                        _inflight = null;
                        _failures = 0;
                        PersistLocked(now);
                    }
                }

                Dispatcher.Post(() => BatchFailed?.Invoke(error, !retry));
                return false;
            }
        }

        private static bool Retryable(ApiError error) =>
            error.IsRetryable
            || error.Code == "ANALYTICS_BUSY"
            || error.Code == "RPC_NOT_FOUND"
            || error.Code == ApiError.NotLoggedInCode
            || error.Code == ApiError.SessionExpiredCode
            || error.Status == 401;

        private Inflight BuildLocked()
        {
            var first = _queue[0];
            var group = first.GroupKey();
            var events = new JArray();
            var take = 0;
            while (take < _queue.Count && take < Math.Max(1, Config.MaxBatch) && _queue[take].GroupKey() == group)
            {
                events.Add(_queue[take].Event);
                take++;
            }

            _queue.RemoveRange(0, take);
            var payload = new JObject
            {
                ["batchId"] = "b-" + Guid.NewGuid().ToString("N"),
                ["appVersion"] = _options.AppVersion ?? string.Empty,
                ["platform"] = _options.Platform ?? string.Empty,
                ["lang"] = _rpc.Language ?? string.Empty,
            };
            if (first.Session != null)
            {
                payload["session"] = first.Session;
            }

            payload["device"] = new JObject
            {
                ["platform"] = _options.Platform ?? string.Empty,
                ["build"] = _options.Build ?? string.Empty,
                ["os"] = _options.Os ?? string.Empty,
                ["model"] = _options.Model ?? string.Empty,
                ["manufacturer"] = _options.Manufacturer ?? string.Empty,
            };
            if (first.Dims != null && first.Dims.Count > 0)
            {
                payload["dimensions"] = first.Dims;
            }

            if (first.Ctx != null && first.Ctx.Count > 0)
            {
                payload["context"] = first.Ctx;
            }

            payload["events"] = events;
            return new Inflight { BatchId = (string)payload["batchId"], Payload = payload.ToString(Formatting.None), Count = take };
        }

        private bool Enqueue(JObject e, IDictionary<string, string> context)
        {
            lock (_gate)
            {
                if (_session == null || _session.Ended)
                {
                    _sessionNum++;
                    var now = _clock.UtcNow;
                    _session = new SessionState { Id = Guid.NewGuid().ToString("N"), Num = _sessionNum, Start = now, Last = now };
                    EnqueueLocked(new JObject { ["type"] = "session", ["status"] = "start" }, null, now);
                }

                EnqueueLocked(e, context, _clock.UtcNow);
                return true;
            }
        }

        private void EnqueueLocked(JObject e, IDictionary<string, string> context, DateTimeOffset at)
        {
            e["time"] = at.UtcDateTime.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'", CultureInfo.InvariantCulture);
            JObject ctx = _ctx.Count == 0 ? null : (JObject)_ctx.DeepClone();
            if (context != null && context.Count > 0)
            {
                ctx = ctx ?? new JObject();
                foreach (var kv in context)
                {
                    if (kv.Value == null)
                    {
                        ctx.Remove(kv.Key);
                    }
                    else
                    {
                        ctx[kv.Key] = kv.Value;
                    }
                }
            }

            _queue.Add(new QueuedEvent
            {
                Event = e,
                Session = _session == null ? null : new JObject { ["id"] = _session.Id, ["num"] = _session.Num, ["start"] = _session.Start.ToUnixTimeMilliseconds() },
                Ctx = ctx,
                Dims = _dims.Count == 0 ? null : (JObject)_dims.DeepClone(),
            });
            while (_queue.Count > Math.Max(10, _options.MaxQueuedEvents))
            {
                _queue.RemoveAt(0);
                Dropped++;
            }

            _dirty = true;
        }

        private bool Check(string error)
        {
            if (error == null)
            {
                return true;
            }

            Report(error);
            return false;
        }

        private void Report(string error)
        {
            Dropped++;
            _logger.Warn("analytics: " + error);
            Dispatcher.Post(() => Invalid?.Invoke(error));
        }

        private void WarnUnknown(AllowedValues[] list, string key, string value, string what)
        {
            if (!_options.WarnUnknown || list == null || list.Length == 0)
            {
                return;
            }

            var def = list.FirstOrDefault(d => d.Key == key);
            if (def == null)
            {
                _logger.Warn(what + " \"" + key + "\" is not in the admin list");
            }
            else if (!def.Allows(value))
            {
                _logger.Warn(what + " \"" + key + "\" does not allow \"" + value + "\"");
            }
        }

        private void PersistLocked(DateTimeOffset now)
        {
            var state = new JObject
            {
                ["v"] = 1,
                ["num"] = _sessionNum,
                ["dims"] = _dims,
                ["ctx"] = _ctx,
                ["queue"] = new JArray(_queue.Select(q => q.ToJson())),
            };
            if (_session != null)
            {
                state["session"] = _session.ToJson();
            }

            if (_pausedAt.HasValue)
            {
                state["pausedAt"] = _pausedAt.Value.ToUnixTimeMilliseconds();
            }

            if (_inflight != null)
            {
                state["inflight"] = new JObject { ["batchId"] = _inflight.BatchId, ["payload"] = _inflight.Payload, ["count"] = _inflight.Count };
            }

            try
            {
                _store.Set(_key, state.ToString(Formatting.None));
                _store.Save();
            }
            catch (Exception e)
            {
                _logger.Warn("analytics queue not saved: " + e.Message);
            }

            _lastPersist = now;
            _dirty = false;
        }

        private void Restore()
        {
            var raw = _store.Get(_key);
            if (string.IsNullOrEmpty(raw))
            {
                return;
            }

            try
            {
                var state = JObject.Parse(raw);
                _sessionNum = (long?)state["num"] ?? 0;
                _dims = state["dims"] as JObject ?? new JObject();
                _ctx = state["ctx"] as JObject ?? new JObject();
                foreach (var q in (state["queue"] as JArray ?? new JArray()).OfType<JObject>())
                {
                    _queue.Add(QueuedEvent.FromJson(q));
                }

                if (state["inflight"] is JObject f && !string.IsNullOrEmpty((string)f["payload"]))
                {
                    _inflight = new Inflight { BatchId = (string)f["batchId"], Payload = (string)f["payload"], Count = (int?)f["count"] ?? 0 };
                }

                if (state["session"] is JObject s)
                {
                    _session = SessionState.FromJson(s);
                    if (!_session.Ended)
                    {
                        var paused = state["pausedAt"] != null ? DateTimeOffset.FromUnixTimeMilliseconds((long)state["pausedAt"]) : _session.Last;
                        var end = paused > _session.Last ? paused : _session.Last;
                        var length = Math.Max(0, (long)Math.Round((end - _session.Start).TotalSeconds));
                        EnqueueLocked(new JObject { ["type"] = "session", ["status"] = "end", ["length"] = length }, null, end);
                        _session.Ended = true;
                    }
                }
            }
            catch (Exception e)
            {
                _logger.Warn("analytics queue could not be read, starting empty: " + e.Message);
                _queue.Clear();
                _inflight = null;
            }
        }

        private sealed class Inflight
        {
            public string BatchId;
            public string Payload;
            public int Count;
        }

        private sealed class SessionState
        {
            public string Id;
            public long Num;
            public DateTimeOffset Start;
            public DateTimeOffset Last;
            public bool Ended;

            public JObject ToJson() => new JObject { ["id"] = Id, ["num"] = Num, ["start"] = Start.ToUnixTimeMilliseconds(), ["last"] = Last.ToUnixTimeMilliseconds(), ["ended"] = Ended };

            public static SessionState FromJson(JObject o) => new SessionState
            {
                Id = (string)o["id"],
                Num = (long?)o["num"] ?? 0,
                Start = DateTimeOffset.FromUnixTimeMilliseconds((long?)o["start"] ?? 0),
                Last = DateTimeOffset.FromUnixTimeMilliseconds((long?)o["last"] ?? 0),
                Ended = (bool?)o["ended"] ?? false,
            };
        }

        private sealed class QueuedEvent
        {
            public JObject Event;
            public JObject Session;
            public JObject Ctx;
            public JObject Dims;

            public string GroupKey() =>
                ((string)Session?["id"] ?? string.Empty) + "|" + (Ctx?.ToString(Formatting.None) ?? string.Empty) + "|" + (Dims?.ToString(Formatting.None) ?? string.Empty);

            public JObject ToJson()
            {
                var o = new JObject { ["e"] = Event };
                if (Session != null)
                {
                    o["s"] = Session;
                }

                if (Ctx != null)
                {
                    o["c"] = Ctx;
                }

                if (Dims != null)
                {
                    o["d"] = Dims;
                }

                return o;
            }

            public static QueuedEvent FromJson(JObject o) => new QueuedEvent { Event = (JObject)o["e"], Session = o["s"] as JObject, Ctx = o["c"] as JObject, Dims = o["d"] as JObject };
        }
    }
}
