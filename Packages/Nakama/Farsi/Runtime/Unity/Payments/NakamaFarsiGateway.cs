#if UNITY_5_3_OR_NEWER
using System;
using System.Threading;
using System.Threading.Tasks;
using NakamaFarsi.Sdk.Payments;
using UnityEngine;

namespace NakamaFarsi.Sdk.Unity
{
    public sealed class NakamaFarsiGateway : MonoBehaviour
    {
        private static NakamaFarsiGateway _instance;
        private TaskCompletionSource<bool> _return;
        private bool _away;

        public static string DeepLinkPrefix { get; set; } = string.Empty;

        public static event Action<PurchaseResult> Returned;

        private static NakamaFarsiGateway Instance
        {
            get
            {
                if (_instance == null)
                {
                    var host = new GameObject("NakamaFarsiGateway") { hideFlags = HideFlags.HideAndDontSave };
                    DontDestroyOnLoad(host);
                    _instance = host.AddComponent<NakamaFarsiGateway>();
                }

                return _instance;
            }
        }

        public static async Task<PurchaseResult> BuyAsync(string productId, string method = PaymentMethods.ZarinPal, string giftCode = null, NakamaFarsiClient client = null, CancellationToken ct = default)
        {
            client = client ?? NakamaFarsiRunner.Client;
            var gateway = Instance;
            var start = await client.Payments.BuyAsync(productId, method, null, giftCode, null, null, ct).ConfigureAwait(true);
            if (start.Outcome != PurchaseOutcome.Redirect)
            {
                return start;
            }

            gateway._return = new TaskCompletionSource<bool>();
            gateway._away = false;
            Application.OpenURL(start.RedirectUrl);
            using (ct.Register(() => gateway._return.TrySetCanceled()))
            {
                await gateway._return.Task.ConfigureAwait(true);
            }

            var result = await client.Payments.WaitAsync(start.PaymentId, null, ct).ConfigureAwait(true);
            Returned?.Invoke(result);
            return result;
        }

        private void Awake() => Application.deepLinkActivated += OnDeepLink;

        private void OnDestroy() => Application.deepLinkActivated -= OnDeepLink;

        private void OnApplicationFocus(bool hasFocus) => Track(!hasFocus);

        private void OnApplicationPause(bool paused) => Track(paused);

        private void Track(bool away)
        {
            if (_return == null)
            {
                return;
            }

            if (away)
            {
                _away = true;
                return;
            }

            if (_away)
            {
                Release();
            }
        }

        private void OnDeepLink(string url)
        {
            if (_return != null && (string.IsNullOrEmpty(DeepLinkPrefix) || PaymentDeepLink.Matches(url, DeepLinkPrefix)))
            {
                Release();
            }
        }

        private void Release()
        {
            var pending = _return;
            _return = null;
            _away = false;
            pending?.TrySetResult(true);
        }
    }
}
#endif
