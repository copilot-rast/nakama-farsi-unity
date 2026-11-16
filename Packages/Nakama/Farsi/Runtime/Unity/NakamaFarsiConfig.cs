#if UNITY_5_3_OR_NEWER
using UnityEngine;

namespace NakamaFarsi.Sdk.Unity
{
    [CreateAssetMenu(fileName = ResourceName, menuName = "Nakama Farsi/SDK Config", order = 0)]
    public sealed class NakamaFarsiConfig : ScriptableObject
    {
        public const string ResourceName = "NakamaFarsiConfig";

        [SerializeField] private string baseUrl = "http://127.0.0.1:7350";
        [SerializeField] private string serverKey = "defaultkey";
        [SerializeField, Tooltip("Runtime HTTP key; only for RPCs called before any sign-in. Leave empty when the game always signs in with the device first")] private string httpKey = "";
        [SerializeField] private string language = "fa";
        [SerializeField, Min(1)] private int timeoutSeconds = 15;
        [SerializeField] private bool useSocket = true;
        [SerializeField, Tooltip("Analytics sessions; needs the analytics module on the server")] private bool autoStartSession = false;
        [SerializeField] private bool logging = true;
        [SerializeField] private bool loggingInReleaseBuilds = false;

        public string BaseUrl { get => baseUrl; set => baseUrl = value; }

        public string ServerKey { get => serverKey; set => serverKey = value; }

        public string HttpKey { get => httpKey; set => httpKey = value; }

        public string Language { get => language; set => language = value; }

        public int TimeoutSeconds { get => timeoutSeconds; set => timeoutSeconds = value; }

        public bool UseSocket { get => useSocket; set => useSocket = value; }

        public bool AutoStartSession { get => autoStartSession; set => autoStartSession = value; }

        public bool LoggingEnabled => logging && (Debug.isDebugBuild || loggingInReleaseBuilds);

        public static NakamaFarsiConfig Load() => Resources.Load<NakamaFarsiConfig>(ResourceName);

        public NakamaFarsiOptions ToOptions()
        {
            var o = NakamaFarsiOptions.FromUrl(baseUrl, serverKey);
            o.Language = string.IsNullOrEmpty(language) ? "fa" : language;
            o.TimeoutSeconds = timeoutSeconds;
            o.UseSocket = useSocket;
            o.HttpKey = string.IsNullOrEmpty(httpKey) ? null : httpKey;
            o.Logging = LoggingEnabled;
            return o;
        }
    }
}
#endif
