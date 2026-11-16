using System;
using System.Collections.Concurrent;
using UnityEngine;

namespace NakamaFarsi.Sdk.Unity
{
    internal sealed class MainThreadQueue : MonoBehaviour
    {
        private static readonly ConcurrentQueue<Action> Pending = new ConcurrentQueue<Action>();
        private static MainThreadQueue _instance;

        public static void Ensure()
        {
            if (_instance != null)
            {
                return;
            }

            var host = new GameObject("Nakama Farsi Main Thread") { hideFlags = HideFlags.HideAndDontSave };
            DontDestroyOnLoad(host);
            _instance = host.AddComponent<MainThreadQueue>();
        }

        public static void Post(Action action) => Pending.Enqueue(action);

        private void Update()
        {
            while (Pending.TryDequeue(out var action))
            {
                action();
            }
        }
    }
}
