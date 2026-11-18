using System;

namespace NakamaFarsi.Sdk
{
    public interface ISdkLogger
    {
        void Log(string message);

        void Warn(string message);
    }

    public sealed class NullLogger : ISdkLogger
    {
        public static readonly NullLogger Instance = new NullLogger();

        public void Log(string message)
        {
        }

        public void Warn(string message)
        {
        }
    }

    public sealed class SwitchedLogger : ISdkLogger
    {
        private readonly ISdkLogger _inner;
        private readonly Func<bool> _enabled;

        public SwitchedLogger(ISdkLogger inner, Func<bool> enabled)
        {
            _inner = inner ?? NullLogger.Instance;
            _enabled = enabled ?? (() => true);
        }

        public void Log(string message)
        {
            if (_enabled())
            {
                _inner.Log(message);
            }
        }

        public void Warn(string message)
        {
            if (_enabled())
            {
                _inner.Warn(message);
            }
        }
    }

    public sealed class ConsoleLogger : ISdkLogger
    {
        public void Log(string message) => Console.WriteLine("[NakamaFarsi] " + message);

        public void Warn(string message) => Console.Error.WriteLine("[NakamaFarsi] " + message);
    }
}
