using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    [CreateAssetMenu(fileName = ResourceName, menuName = "PolicePatrol/SDK Config", order = 0)]
    public sealed class PolicePatrolSdkConfig : ScriptableObject
    {
        public const string ResourceName = "PolicePatrolSdkConfig";

        [SerializeField] private string baseUrl = "http://localhost:7350";
        [SerializeField] private string workspace = "default";
        [SerializeField] private bool logging = true;
        [SerializeField] private bool loggingInReleaseBuilds = false;
        [SerializeField, Min(1)] private int timeoutSeconds = 30;
        [SerializeField] private string language = "fa";
        [SerializeField, Tooltip("Nakama server key (socket.server_key); ask the project owner")] private string serverKey = "defaultkey";
        [SerializeField, Tooltip("Send calls over the realtime socket first; HTTP is used while it is down")] private bool useSocket = true;
        [SerializeField, Tooltip("Analytics sessions follow pause / resume / quit")] private bool analyticsSessions = true;

        public string BaseUrl => baseUrl;

        public string Workspace => workspace;

        public int TimeoutSeconds => timeoutSeconds;

        public string Language => language;

        public string ServerKey => serverKey;

        public bool UseSocket => useSocket;

        public bool AnalyticsSessions => analyticsSessions;

        public bool LoggingEnabled => logging && (Debug.isDebugBuild || loggingInReleaseBuilds);

        public static PolicePatrolSdkConfig Load() => Resources.Load<PolicePatrolSdkConfig>(ResourceName);

        public SdkOptions ToOptions() => new SdkOptions(baseUrl, workspace, LoggingEnabled, timeoutSeconds, language) { ServerKey = serverKey, UseSocket = useSocket, DeviceId = SystemInfo.deviceUniqueIdentifier };
    }
}
