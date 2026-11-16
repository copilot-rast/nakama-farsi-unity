using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NakamaFarsi.Sdk.Generated;

namespace NakamaFarsi.Sdk.Insights
{
    public sealed class InsightsDevice
    {
        public string AppVersion { get; set; } = string.Empty;

        public string Platform { get; set; } = string.Empty;

        public string Device { get; set; } = string.Empty;

        public string Os { get; set; } = string.Empty;
    }

    public sealed class InsightsClient
    {
        private readonly NakamaFarsiRpcs _rpcs;
        private readonly IClock _clock;
        private readonly ISdkLogger _logger;
        private readonly object _gate = new object();
        private DateTimeOffset _startedAt;
        private DateTimeOffset _nextPing;
        private DateTimeOffset? _pausedAt;
        private double _foreground;
        private bool _pinging;

        public InsightsClient(NakamaFarsiRpcs rpcs, IClock clock = null, ISdkLogger logger = null)
        {
            _rpcs = rpcs ?? throw new ArgumentNullException(nameof(rpcs));
            _clock = clock ?? SystemClock.Instance;
            _logger = logger ?? NullLogger.Instance;
        }

        public InsightsDevice Device { get; set; } = new InsightsDevice();

        public string SessionId { get; private set; }

        public int PingSeconds { get; private set; } = 60;

        public int TimeoutSeconds { get; private set; } = 300;

        public bool Running => SessionId != null;

        public async Task StartSessionAsync(CancellationToken ct = default)
        {
            var id = Guid.NewGuid().ToString("N");
            lock (_gate)
            {
                SessionId = id;
                _startedAt = _clock.UtcNow;
                _foreground = 0;
                _pausedAt = null;
                _nextPing = _startedAt.AddSeconds(PingSeconds);
            }

            var res = await _rpcs.Insights.SessionAsync(Request("start", id, null), ct).ConfigureAwait(false);
            if (res.Raw != null && res.Raw["pingSeconds"] != null)
            {
                PingSeconds = Math.Max(10, (int)res.Raw["pingSeconds"]);
                TimeoutSeconds = Math.Max(PingSeconds, (int?)res.Raw["timeoutSeconds"] ?? TimeoutSeconds);
                _nextPing = _clock.UtcNow.AddSeconds(PingSeconds);
            }
        }

        public async Task EndSessionAsync(CancellationToken ct = default)
        {
            string id;
            double seconds;
            lock (_gate)
            {
                id = SessionId;
                if (id == null)
                {
                    return;
                }

                seconds = ForegroundSeconds();
                SessionId = null;
            }

            await _rpcs.Insights.SessionAsync(Request("end", id, seconds), ct).ConfigureAwait(false);
        }

        public void Tick()
        {
            string id;
            lock (_gate)
            {
                var now = _clock.UtcNow;
                if (SessionId == null || _pausedAt != null || _pinging || now < _nextPing)
                {
                    return;
                }

                _pinging = true;
                _nextPing = now.AddSeconds(PingSeconds);
                id = SessionId;
            }

            _ = PingAsync(id);
        }

        public void OnPause()
        {
            lock (_gate)
            {
                if (SessionId != null && _pausedAt == null)
                {
                    _foreground = ForegroundSeconds();
                    _pausedAt = _clock.UtcNow;
                }
            }
        }

        public void OnResume()
        {
            bool restart;
            lock (_gate)
            {
                if (SessionId == null || _pausedAt == null)
                {
                    return;
                }

                restart = (_clock.UtcNow - _pausedAt.Value).TotalSeconds > TimeoutSeconds;
                if (!restart)
                {
                    _startedAt = _clock.UtcNow.AddSeconds(-_foreground);
                    _pausedAt = null;
                    _nextPing = _clock.UtcNow;
                }
            }

            if (restart)
            {
                _ = RestartAsync();
            }
        }

        public HeatmapRecorder NewRace(string map, string uploadId) => new HeatmapRecorder(_rpcs, map, uploadId);

        private async Task RestartAsync()
        {
            try
            {
                await EndSessionAsync().ConfigureAwait(false);
                await StartSessionAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _logger.Warn("insights session restart failed: " + e.Message);
            }
        }

        private async Task PingAsync(string id)
        {
            try
            {
                await _rpcs.Insights.SessionAsync(Request("ping", id, null)).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                _logger.Warn("insights ping failed: " + e.Message);
            }
            finally
            {
                lock (_gate)
                {
                    _pinging = false;
                }
            }
        }

        private double ForegroundSeconds()
        {
            if (_pausedAt != null)
            {
                return _foreground;
            }

            return Math.Max(0, (_clock.UtcNow - _startedAt).TotalSeconds);
        }

        private InsightsSessionRequest Request(string ev, string id, double? seconds) => new InsightsSessionRequest
        {
            Event = ev,
            SessionId = id,
            AppVersion = Device.AppVersion,
            Platform = Device.Platform,
            Device = Device.Device,
            Os = Device.Os,
            Seconds = seconds.HasValue ? Math.Round(seconds.Value, 1) : (double?)null,
        };
    }

    public sealed class HeatmapRecorder
    {
        private readonly NakamaFarsiRpcs _rpcs;
        private readonly List<string> _lines = new List<string>();

        public HeatmapRecorder(NakamaFarsiRpcs rpcs, string map, string uploadId)
        {
            _rpcs = rpcs ?? throw new ArgumentNullException(nameof(rpcs));
            Map = map;
            UploadId = uploadId;
        }

        public string Map { get; }

        public string UploadId { get; }

        public int MaxPartBytes { get; set; } = 24 * 1024;

        public int Count => _lines.Count;

        public void Record(float t, float x, float z, string player, float kmh)
        {
            var c = CultureInfo.InvariantCulture;
            var name = (player ?? string.Empty).Replace(",", " ").Replace("\n", " ");
            _lines.Add(t.ToString("0.##", c) + "," + x.ToString("0.##", c) + "," + z.ToString("0.##", c) + "," + name + "," + kmh.ToString("0.#", c));
        }

        public async Task<int> UploadAsync(CancellationToken ct = default)
        {
            var parts = Split();
            var accepted = 0;
            for (var i = 0; i < parts.Count; i++)
            {
                var res = await _rpcs.Insights.HeatmapAsync(new InsightsHeatmapRequest { Map = Map, UploadId = UploadId, Part = i, Format = "csv.gz", Data = parts[i] }, ct).ConfigureAwait(false);
                if (res.Accepted.HasValue)
                {
                    accepted += (int)res.Accepted.Value;
                }
            }

            _lines.Clear();
            return accepted;
        }

        public List<string> Split()
        {
            var parts = new List<string>();
            var start = 0;
            while (start < _lines.Count)
            {
                var take = _lines.Count - start;
                var data = Pack(start, take);
                while (data.Length > MaxPartBytes && take > 1)
                {
                    take = Math.Max(1, take * MaxPartBytes / data.Length * 9 / 10);
                    data = Pack(start, take);
                }

                parts.Add(data);
                start += take;
            }

            return parts;
        }

        private string Pack(int start, int count)
        {
            var sb = new StringBuilder("t,x,z,player,kmh\n");
            for (var i = start; i < start + count; i++)
            {
                sb.Append(_lines[i]).Append('\n');
            }

            using (var ms = new MemoryStream())
            {
                using (var gz = new GZipStream(ms, CompressionLevel.Optimal, true))
                {
                    var bytes = Encoding.UTF8.GetBytes(sb.ToString());
                    gz.Write(bytes, 0, bytes.Length);
                }

                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }
}
