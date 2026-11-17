using System;
using System.Collections;
using PolicePatrol.Sdk.Payments;
using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    internal sealed class PaymentRunner : MonoBehaviour
    {
        private static PaymentRunner _instance;

        private Action _onReturn;
        private bool _away;

        public static PaymentRunner Instance
        {
            get
            {
                if (_instance == null)
                {
                    var host = new GameObject("PolicePatrol Payments") { hideFlags = HideFlags.HideAndDontSave };
                    DontDestroyOnLoad(host);
                    _instance = host.AddComponent<PaymentRunner>();
                }

                return _instance;
            }
        }

        public bool IsWaiting => _onReturn != null;

        public void WaitForReturn(Action onReturn)
        {
            _away = false;
            _onReturn = onReturn;
        }

        public bool Return()
        {
            var onReturn = _onReturn;
            _onReturn = null;
            _away = false;
            onReturn?.Invoke();
            return onReturn != null;
        }

        public void Delay(TimeSpan wait, Action then) => StartCoroutine(Wait(wait, then));

        private void Awake() => Application.deepLinkActivated += OnDeepLink;

        private void OnDestroy() => Application.deepLinkActivated -= OnDeepLink;

        private void OnApplicationFocus(bool hasFocus) => Track(!hasFocus);

        private void OnApplicationPause(bool paused) => Track(paused);

        private void Track(bool away)
        {
            if (away)
            {
                _away = IsWaiting;
                return;
            }

            if (_away)
            {
                Return();
            }
        }

        private void OnDeepLink(string url)
        {
            if (PaymentDeepLink.Matches(url, PolicePatrolPayments.DeepLinkPrefix))
            {
                Return();
            }
        }

        private static IEnumerator Wait(TimeSpan wait, Action then)
        {
            yield return new WaitForSecondsRealtime((float)wait.TotalSeconds);
            then();
        }
    }
}
