namespace PolicePatrol.Sdk
{
    public interface ISdkLogger
    {
        void Log(string message);

        void Error(string message);
    }

    internal sealed class CoreLogger : NakamaFarsi.Sdk.ISdkLogger
    {
        private readonly ISdkLogger _inner;

        public CoreLogger(ISdkLogger inner)
        {
            _inner = inner;
        }

        public void Log(string message) => _inner?.Log("[PolicePatrol.Sdk] " + message);

        public void Warn(string message) => _inner?.Error("[PolicePatrol.Sdk] " + message);
    }
}
