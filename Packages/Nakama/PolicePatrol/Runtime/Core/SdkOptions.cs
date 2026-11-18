namespace PolicePatrol.Sdk
{
    public sealed record SdkOptions(string BaseUrl, string Workspace, bool Logging = false, int TimeoutSeconds = 30, string Language = null)
    {
        public string ServerKey { get; init; } = "defaultkey";

        public string DeviceId { get; init; }

        public bool UseSocket { get; init; } = true;
    }
}
