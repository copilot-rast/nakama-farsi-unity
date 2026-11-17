using System;
using System.Collections.Generic;
using System.Linq;

namespace PolicePatrol.Sdk.Stats
{
    public sealed class StatTracker
    {
        public const int MaxBatches = 20;
        private const int DefaultIntervalSeconds = 60;
        private const int RetrySeconds = 10;

        private readonly Dictionary<string, StatConfig> _config = new Dictionary<string, StatConfig>(StringComparer.Ordinal);
        private readonly Dictionary<string, double> _pending = new Dictionary<string, double>(StringComparer.Ordinal);
        private readonly Dictionary<string, DateTimeOffset> _lastSent = new Dictionary<string, DateTimeOffset>(StringComparer.Ordinal);
        private readonly List<StatBatch> _batches = new List<StatBatch>();
        private readonly Func<DateTimeOffset> _clock;
        private readonly int _defaultInterval;
        private DateTimeOffset _retryAt;
        private bool _sending;

        public StatTracker(StatsConfig config, Func<DateTimeOffset> clock = null)
        {
            _clock = clock ?? (() => DateTimeOffset.UtcNow);
            _defaultInterval = config?.SendIntervalSeconds > 0 ? config.SendIntervalSeconds : DefaultIntervalSeconds;
            foreach (var stat in config?.Stats ?? Array.Empty<StatConfig>())
            {
                _config[stat.Key] = stat;
            }
        }

        public event Action<Trophy[]> TrophiesReceived;

        public event Action<StatsReport> Reported;

        public event Action<ApiError> Failed;

        public bool IsSending => _sending;

        public IReadOnlyDictionary<string, double> Pending => _pending;

        public IReadOnlyList<StatBatch> Batches => _batches;

        public bool IsEmpty => _pending.Count == 0 && _batches.Count == 0;

        public StatsBacklog Backlog => new StatsBacklog(
            _batches.ToArray(),
            _pending.Select(pair => new StatValue(pair.Key, pair.Value)).ToArray());

        public void Add(string key, double value = 1d)
        {
            if (string.IsNullOrEmpty(key) || value < 0 || double.IsNaN(value) || double.IsInfinity(value))
            {
                return;
            }

            if (!_lastSent.ContainsKey(key))
            {
                _lastSent[key] = _clock();
            }

            var isMax = _config.TryGetValue(key, out var stat) && stat.Kind == StatKinds.Max;
            _pending[key] = _pending.TryGetValue(key, out var current)
                ? (isMax ? Math.Max(current, value) : current + value)
                : value;
        }

        public void Restore(StatsBacklog backlog)
        {
            foreach (var batch in backlog?.Batches ?? Array.Empty<StatBatch>())
            {
                if (batch?.Stats?.Length > 0 && !string.IsNullOrEmpty(batch.ReportId) && _batches.All(b => b.ReportId != batch.ReportId))
                {
                    _batches.Add(batch);
                }
            }

            foreach (var value in backlog?.Pending ?? Array.Empty<StatValue>())
            {
                Add(value.Key, value.Value);
            }
        }

        public void Tick()
        {
            if (_sending)
            {
                return;
            }

            var now = _clock();
            if (_batches.Count > 0)
            {
                if (now >= _retryAt)
                {
                    SendHead();
                }

                return;
            }

            var due = _pending.Keys.Where(key => (now - _lastSent[key]).TotalSeconds >= IntervalOf(key)).ToList();
            if (due.Count > 0 && Pack(due))
            {
                SendHead();
            }
        }

        public void Flush()
        {
            if (_sending)
            {
                return;
            }

            if (_pending.Count > 0)
            {
                Pack(_pending.Keys.ToList());
            }

            if (_batches.Count > 0)
            {
                SendHead();
            }
        }

        private int IntervalOf(string key) =>
            _config.TryGetValue(key, out var stat) && stat.SendIntervalSeconds > 0 ? stat.SendIntervalSeconds : _defaultInterval;

        private bool Pack(List<string> keys)
        {
            if (_batches.Count >= MaxBatches)
            {
                return false;
            }

            var now = _clock();
            var values = keys.Select(key => new StatValue(key, _pending[key])).ToArray();
            foreach (var key in keys)
            {
                _pending.Remove(key);
                _lastSent[key] = now;
            }

            _batches.Add(new StatBatch(Guid.NewGuid().ToString("N"), values));
            return true;
        }

        private void SendHead()
        {
            var batch = _batches[0];
            _sending = true;
            StatsProvider.Report(batch.Stats, batch.ReportId, result =>
            {
                _sending = false;
                if (result.IsSuccess)
                {
                    _batches.Remove(batch);
                    Reported?.Invoke(result.Data);
                    if (result.Data?.Trophies?.Length > 0)
                    {
                        TrophiesReceived?.Invoke(result.Data.Trophies);
                    }

                    if (_batches.Count > 0)
                    {
                        SendHead();
                    }

                    return;
                }

                if (IsRetryable(result.Error))
                {
                    _retryAt = _clock().AddSeconds(RetrySeconds);
                }
                else
                {
                    _batches.Remove(batch);
                }

                Failed?.Invoke(result.Error);
            });
        }

        private static bool IsRetryable(ApiError error) =>
            error == null || error.IsNetworkError || error.Status == 429 || error.Status >= 500 || error.Code == StatsErrorCodes.Busy;
    }
}
