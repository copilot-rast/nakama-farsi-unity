using System;
using System.Threading;
using PolicePatrol.Sdk.Payments;
using UnityEngine;

namespace PolicePatrol.Sdk.Unity
{
    public static class PolicePatrolPayments
    {
        private const string PendingPaymentKey = "PolicePatrol.Sdk.PendingPayment";

        public static string DeepLinkPrefix { get; set; } = PaymentDeepLink.DefaultPrefix;

        public static TimeSpan PollInterval { get; set; } = PaymentPoller.DefaultInterval;

        public static TimeSpan PollTimeout { get; set; } = PaymentPoller.DefaultTimeout;

        public static string PendingPaymentId
        {
            get
            {
                var paymentId = PlayerPrefs.GetString(PendingPaymentKey, string.Empty);
                return paymentId.Length == 0 ? null : paymentId;
            }
        }

        public static bool LaunchedFromGateway => PaymentDeepLink.Matches(Application.absoluteURL, DeepLinkPrefix);

        public static bool IsWaitingForReturn => PaymentRunner.Instance.IsWaiting;

        public static PaymentPoller CreatePoller() =>
            new PaymentPoller(PaymentRunner.Instance.Delay) { Interval = PollInterval, Timeout = PollTimeout };

        public static void PayWithZarrinpal(string productId, Action<ApiResult<Payment>> onComplete, string giftCode = null, CancellationToken cancellationToken = default) =>
            PaymentProvider.Initiate(productId, PaymentMethods.Zarrinpal, result =>
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                if (!result.IsSuccess)
                {
                    onComplete?.Invoke(ApiResult<Payment>.Fail(result.Error));
                    return;
                }

                var paymentId = result.Data.PaymentId;
                Remember(paymentId);
                if (string.IsNullOrEmpty(result.Data.GatewayUrl))
                {
                    Watch(CreatePoller(), paymentId, onComplete, cancellationToken);
                    return;
                }

                PaymentRunner.Instance.WaitForReturn(() => Watch(CreatePoller(), paymentId, onComplete, cancellationToken));
                Application.OpenURL(result.Data.GatewayUrl);
            }, giftCode);

        public static bool CheckNow() => PaymentRunner.Instance.Return();

        public static bool ResumePending(Action<ApiResult<Payment>> onComplete, CancellationToken cancellationToken = default)
        {
            var paymentId = PendingPaymentId;
            if (paymentId == null || IsWaitingForReturn)
            {
                return false;
            }

            var poller = CreatePoller();
            if (!LaunchedFromGateway)
            {
                poller.Timeout = TimeSpan.Zero;
            }

            Watch(poller, paymentId, onComplete, cancellationToken);
            return true;
        }

        public static void SubmitBilling(string paymentId, string purchaseToken, Action<ApiResult<Payment>> onComplete, CancellationToken cancellationToken = default) =>
            CreatePoller().SubmitBilling(paymentId, purchaseToken, onComplete, cancellationToken);

        public static void ForgetPending()
        {
            PlayerPrefs.DeleteKey(PendingPaymentKey);
            PlayerPrefs.Save();
        }

        private static void Remember(string paymentId)
        {
            PlayerPrefs.SetString(PendingPaymentKey, paymentId ?? string.Empty);
            PlayerPrefs.Save();
        }

        private static void Watch(PaymentPoller poller, string paymentId, Action<ApiResult<Payment>> onComplete, CancellationToken cancellationToken) =>
            poller.WaitForResult(paymentId, result =>
            {
                var settled = result.IsSuccess ? result.Data?.Status != PaymentStatus.Pending : !PaymentPoller.IsRetryable(result.Error);
                if (settled && PendingPaymentId == paymentId)
                {
                    ForgetPending();
                }

                onComplete?.Invoke(result);
            }, cancellationToken);
    }
}
