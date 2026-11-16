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

    public sealed class ConsoleLogger : ISdkLogger
    {
        public void Log(string message) => Console.WriteLine("[NakamaFarsi] " + message);

        public void Warn(string message) => Console.Error.WriteLine("[NakamaFarsi] " + message);
    }
}
