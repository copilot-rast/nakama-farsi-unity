using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    public sealed class UnityLogger : ISdkLogger
    {
        public void Log(string message) => Debug.Log(message);

        public void Error(string message) => Debug.LogWarning(message);
    }
}
