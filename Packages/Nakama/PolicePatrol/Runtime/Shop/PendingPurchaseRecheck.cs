using System;
using System.Collections.Generic;
using PolicePatrol.Sdk.Payments;

namespace PolicePatrol.Sdk.Shop
{
    internal sealed class PendingPurchaseRecheck
    {
        private readonly IStoreBilling _store;
        private readonly PaymentPoller _poller;
        private readonly List<string> _pending = new List<string>();
        private int _confirmed;
        private int _alreadyDone;

        public PendingPurchaseRecheck(IStoreBilling store, PaymentPoller poller)
        {
            _store = store;
            _poller = poller;
        }

        public static bool IsAlreadyDone(ApiError error) =>
            error != null && (error.Code == PaymentErrorCodes.AlreadyProcessed || error.Code == PaymentErrorCodes.TokenAlreadyValidated);

        public void Run(Action<RecheckResult> onComplete) =>
            _store.GetPurchases(purchases => Next(purchases ?? Array.Empty<StorePurchase>(), 0, onComplete));

        private void Next(IReadOnlyList<StorePurchase> purchases, int index, Action<RecheckResult> onComplete)
        {
            if (index >= purchases.Count)
            {
                onComplete?.Invoke(new RecheckResult(_confirmed, _alreadyDone, _pending));
                return;
            }

            var purchase = purchases[index];
            if (purchase == null || string.IsNullOrWhiteSpace(purchase.PurchaseToken))
            {
                Next(purchases, index + 1, onComplete);
                return;
            }

            Submit(purchase, result => Settle(purchase, result, () => Next(purchases, index + 1, onComplete)));
        }

        private void Submit(StorePurchase purchase, Action<ApiResult<Payment>> onComplete)
        {
            if (Guid.TryParse(purchase.DeveloperPayload, out _))
            {
                _poller.SubmitBilling(purchase.DeveloperPayload, purchase.PurchaseToken, onComplete);
                return;
            }

            PaymentProvider.Review(purchase.Sku, purchase.PurchaseToken, _store.Method, onComplete);
        }

        private void Settle(StorePurchase purchase, ApiResult<Payment> result, Action then)
        {
            var confirmed = result.IsSuccess && result.Data?.Status == PaymentStatus.Success;
            var alreadyDone = !result.IsSuccess && IsAlreadyDone(result.Error);
            if (!confirmed && !alreadyDone)
            {
                _pending.Add(result.IsSuccess ? result.Data?.Status ?? PaymentStatus.Pending : result.Error?.Code);
                then();
                return;
            }

            if (confirmed)
            {
                _confirmed++;
            }
            else
            {
                _alreadyDone++;
            }

            var subscription = purchase.IsSubscription || (result.Data?.Product?.IsSubscription ?? false);
            if (subscription)
            {
                then();
                return;
            }

            _store.Consume(purchase.PurchaseToken, _ => then());
        }
    }
}
