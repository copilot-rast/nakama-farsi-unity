using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PolicePatrol.Sdk.Stats;
using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    public sealed class PolicePatrolStats : MonoBehaviour
    {
        public const string SavedKey = "PolicePatrol.Stats.Unsent";
        private const int MaxEarly = 1000;
        private const float RetrySeconds = 60f;

        private static readonly List<StatValue> Early = new List<StatValue>();
        private static readonly HashSet<string> Warned = new HashSet<string>(StringComparer.Ordinal);
        private static PolicePatrolStats _instance;
        private static bool _loading;
        private static float _nextTry;

        public static StatTracker Tracker { get; private set; }

        public static event Action<Trophy[]> TrophiesReceived;

        private static bool _forwarding;

        public static void Begin(Action<ApiResult<StatsConfig>> onReady = null)
        {
            if (!_forwarding && PolicePatrolSdk.Client != null)
            {
                _forwarding = true;
                PolicePatrolSdk.Client.Core.Analytics.Unlocked += unlocked =>
                    TrophiesReceived?.Invoke(Stages.StageProvider.Trophies(new Newtonsoft.Json.Linq.JObject { ["trophies"] = unlocked }));
            }

            if (_instance == null)
            {
                var host = new GameObject("PolicePatrolStats");
                DontDestroyOnLoad(host);
                _instance = host.AddComponent<PolicePatrolStats>();
            }

            Load(onReady);
        }

        public static void Add(string key, double value = 1d)
        {
            if (Tracker != null)
            {
                Tracker.Add(key, value);
                return;
            }

            if (Early.Count >= MaxEarly)
            {
                Early.RemoveAt(0);
            }

            Early.Add(new StatValue(key, value));
        }

        public static void Flush() => Tracker?.Flush();

        private static void Load(Action<ApiResult<StatsConfig>> onReady)
        {
            if (Tracker != null || _loading)
            {
                return;
            }

            _loading = true;
            StatsProvider.Config(result =>
            {
                _loading = false;
                if (!result.IsSuccess)
                {
                    _nextTry = Time.realtimeSinceStartup + RetrySeconds;
                    onReady?.Invoke(result);
                    return;
                }

                Tracker = new StatTracker(result.Data);
                Tracker.TrophiesReceived += trophies => TrophiesReceived?.Invoke(trophies);
                Tracker.Reported += OnReported;
                Tracker.Restore(Restore());
                foreach (var value in Early)
                {
                    Tracker.Add(value.Key, value.Value);
                }

                Early.Clear();
                onReady?.Invoke(result);
            });
        }

        private static StatsBacklog Restore()
        {
            var json = PlayerPrefs.GetString(SavedKey, string.Empty);
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            try
            {
                return json.TrimStart().StartsWith("[", StringComparison.Ordinal)
                    ? new StatsBacklog(Array.Empty<StatBatch>(), JsonConvert.DeserializeObject<StatValue[]>(json))
                    : JsonConvert.DeserializeObject<StatsBacklog>(json);
            }
            catch (JsonException)
            {
                return null;
            }
        }

        private static void Save()
        {
            var backlog = Tracker?.Backlog ?? new StatsBacklog(Array.Empty<StatBatch>(), Array.Empty<StatValue>());
            backlog = backlog with { Pending = backlog.Pending.Concat(Early).ToArray() };
            if (backlog.Batches.Length == 0 && backlog.Pending.Length == 0)
            {
                PlayerPrefs.DeleteKey(SavedKey);
            }
            else
            {
                PlayerPrefs.SetString(SavedKey, JsonConvert.SerializeObject(backlog));
            }

            PlayerPrefs.Save();
        }

        private static void OnReported(StatsReport report)
        {
            if (Tracker != null && PlayerPrefs.HasKey(SavedKey))
            {
                Save();
            }

            if (!Debug.isDebugBuild)
            {
                return;
            }

            foreach (var row in report?.Stats ?? Array.Empty<StatReportRow>())
            {
                if (row.Status == StatReportStatuses.Unknown && Warned.Add(row.Key))
                {
                    Debug.LogWarning("PolicePatrol: stat \"" + row.Key + "\" is not defined in the panel, so the server ignores it");
                }
            }
        }

        private void Update()
        {
            if (Tracker == null)
            {
                if (!_loading && Time.realtimeSinceStartup >= _nextTry)
                {
                    Load(null);
                }

                return;
            }

            Tracker.Tick();
        }

        private void OnApplicationPause(bool paused)
        {
            if (paused)
            {
                Tracker?.Flush();
                Save();
            }
        }

        private void OnApplicationQuit()
        {
            Tracker?.Flush();
            Save();
        }
    }
}
