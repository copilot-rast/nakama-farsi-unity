using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace PolicePatrol.Sdk.Payments
{
    public sealed class PaymentPoller
    {
        public static readonly TimeSpan DefaultInterval = TimeSpan.FromSeconds(2);
        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromMinutes(1);

        private readonly Action<TimeSpan, Action> _delay;
        private readonly Func<TimeSpan> _clock;

        public PaymentPoller(Action<TimeSpan, Action> delay = null, Func<TimeSpan> clock = null)
        {
            _delay = delay ?? TaskDelay;
            _clock = clock ?? Monotonic;
        }

        public TimeSpan Interval { get; set; } = DefaultInterval;

        public TimeSpan Timeout { get; set; } = DefaultTimeout;

        public static bool IsRetryable(ApiError error) =>
            error != null && (error.IsNetworkError || error.Status == 429 || error.Status >= 500 || error.Code == PaymentErrorCodes.StoreUnavailable);

        public void WaitForResult(string paymentId, Action<ApiResult<Payment>> onComplete, CancellationToken cancellationToken = default) =>
            Repeat(done => PaymentProvider.Get(paymentId, done), result => result.Data?.Status == PaymentStatus.Pending, onComplete, cancellationToken);

        public void SubmitBilling(string paymentId, string purchaseToken, Action<ApiResult<Payment>> onComplete, CancellationToken cancellationToken = default) =>
            Repeat(done => PaymentProvider.SubmitBilling(paymentId, purchaseToken, done), _ => false, onComplete, cancellationToken);

        private void Repeat(Action<Action<ApiResult<Payment>>> call, Func<ApiResult<Payment>, bool> stillPending, Action<ApiResult<Payment>> onComplete, CancellationToken cancellationToken)
        {
            var started = _clock();
            ApiResult<Payment> latest = null;

            void Attempt()
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                call(result =>
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return;
                    }

                    if (result.IsSuccess || latest == null || !latest.IsSuccess)
                    {
                        latest = result;
                    }

                    var again = result.IsSuccess ? stillPending(result) : IsRetryable(result.Error);
                    if (!again)
                    {
                        onComplete?.Invoke(result);
                        return;
                    }

                    if (_clock() - started >= Timeout)
                    {
                        onComplete?.Invoke(latest);
                        return;
                    }

                    _delay(Interval, Attempt);
                });
            }

            Attempt();
        }

        private static void TaskDelay(TimeSpan wait, Action then)
        {
            var context = SynchronizationContext.Current;
            Task.Delay(wait).ContinueWith(_ =>
            {
                if (context == null)
                {
                    then();
                    return;
                }

                context.Post(__ => then(), null);
            }, TaskScheduler.Default);
        }

        private static TimeSpan Monotonic() => TimeSpan.FromSeconds(Stopwatch.GetTimestamp() / (double)Stopwatch.Frequency);
    }
}
