#if UNITY_5_3_OR_NEWER
using System;
using NakamaFarsi.Sdk.Analytics;
using Nakama;
using UnityEngine;

namespace NakamaFarsi.Sdk.Unity
{
    public sealed class NakamaFarsiRunner : MonoBehaviour
    {
        private static NakamaFarsiRunner _instance;
        private UnityMainThreadDispatcher _dispatcher;
        private bool _autoSession;

        public static NakamaFarsiClient Client { get; private set; }

        public static bool IsInitialized => Client != null;

        public static NakamaFarsiClient Initialize(NakamaFarsiConfig config, AnalyticsOptions analytics = null)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            return Initialize(config.ToOptions(), config.AutoStartSession, analytics);
        }

        public static NakamaFarsiClient Initialize(NakamaFarsiOptions options, bool autoStartSession = false, AnalyticsOptions analytics = null)
        {
            if (_instance == null)
            {
                var host = new GameObject("NakamaFarsiRunner");
                DontDestroyOnLoad(host);
                _instance = host.AddComponent<NakamaFarsiRunner>();
                _instance._dispatcher = new UnityMainThreadDispatcher();
            }

            IClient nakama = new Client(options.Scheme, options.Host, options.Port, options.ServerKey, UnityWebRequestAdapter.Instance, false);
            Func<IClient, ISocket> socketFactory = c => c.NewSocket(true);
            Client = new NakamaFarsiClient(options, UnityStores.Default(), _instance._dispatcher, new UnityLogger(), nakama, socketFactory, new UnityWebRequestGet(_instance._dispatcher));
            Client.UseAnalytics(analytics ?? DefaultAnalytics());
            _instance._autoSession = autoStartSession;
            if (Client.Session.Current != null)
            {
                Client.AfterLogin();
            }

            if (autoStartSession)
            {
                Client.Analytics.StartSession();
            }

            return Client;
        }

        public static AnalyticsOptions DefaultAnalytics() => new AnalyticsOptions
        {
            AppVersion = Application.version,
            Platform = Application.platform == RuntimePlatform.Android ? "android"
                : Application.platform == RuntimePlatform.IPhonePlayer ? "ios"
                : Application.platform.ToString().ToLowerInvariant(),
            Build = Application.buildGUID,
            Os = SystemInfo.operatingSystem,
            Model = SystemInfo.deviceModel,
            Manufacturer = SystemInfo.deviceModel.Split(' ')[0],
        };

        private void Update()
        {
            _dispatcher?.Pump();
            Client?.Analytics.Tick();
        }

        private void OnApplicationPause(bool paused)
        {
            if (Client == null || !_autoSession)
            {
                return;
            }

            if (paused)
            {
                Client.Analytics.OnPause();
            }
            else
            {
                Client.Analytics.OnResume();
            }
        }

        private void OnApplicationQuit()
        {
            if (Client != null && _autoSession)
            {
                Client.Analytics.OnQuit();
            }
        }
    }
}
#endif
