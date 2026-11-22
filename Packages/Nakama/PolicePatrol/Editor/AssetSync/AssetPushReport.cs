namespace PolicePatrol.Sdk.Editor
{
    public sealed class AssetPushReport
    {
        public AssetPushReport(string message, bool dryRun, AssetRouting routing)
        {
            Message = message;
            DryRun = dryRun;
            Routing = routing;
        }

        public string Message { get; }

        public bool DryRun { get; }

        public AssetRouting Routing { get; }

        public bool RoutingOff => Routing == null;
    }
}
