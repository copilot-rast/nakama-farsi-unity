using System;
using System.Collections.Generic;
using System.Linq;
using PolicePatrol.Sdk.Payments;

namespace PolicePatrol.Sdk.Shop
{
    internal sealed class PendingPurchaseRecheck
    {
        private readonly IStoreBilling _store;
        private readonly PaymentPoller _poller;
        private readonly List<string> _pending = new List<string>();
        private readonly List<string> _rewardPending = new List<string>();
        private readonly HashSet<string> _seen = new HashSet<string>(StringComparer.Ordinal);
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
                FollowRewards(onComplete);
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

            PaymentProvider.Review(purchase.Sku, purchase.PurchaseToken, _store.Method, review => onComplete(PaymentProvider.RewardCheck(review)));
        }

        private void Settle(StorePurchase purchase, ApiResult<Payment> result, Action then)
        {
            var confirmed = PaymentPoller.IsVerified(result);
            var alreadyDone = !result.IsSuccess && IsAlreadyDone(result.Error);
            if (!confirmed && !alreadyDone)
            {
                _pending.Add(result.IsSuccess ? result.Data?.Status ?? PaymentStatus.Pending : result.Error?.Code);
                then();
                return;
            }

            if (alreadyDone)
            {
                _alreadyDone++;
            }

            Action counted = () =>
            {
                if (confirmed && result.IsSuccess)
                {
                    _confirmed++;
                    then();
                    return;
                }

                if (confirmed)
                {
                    FollowReward(PaymentId(result, purchase), then);
                    return;
                }

                then();
            };

            var subscription = purchase.IsSubscription || (result.Data?.Product?.IsSubscription ?? false);
            if (subscription)
            {
                counted();
                return;
            }

            _store.Consume(purchase.PurchaseToken, _ => counted());
        }

        private static string PaymentId(ApiResult<Payment> result, StorePurchase purchase) =>
            result.Error?.Meta?["paymentId"]?.ToString() ?? result.Data?.Id ?? purchase.DeveloperPayload;

        private void FollowReward(string paymentId, Action then)
        {
            if (string.IsNullOrEmpty(paymentId) || !_seen.Add(paymentId))
            {
                then();
                return;
            }

            _poller.WaitForReward(paymentId, granted =>
            {
                if (granted.IsSuccess)
                {
                    _confirmed++;
                }
                else
                {
                    _pending.Add(granted.Error?.Code ?? PaymentErrorCodes.RewardPending);
                    if (granted.Error?.Code == PaymentErrorCodes.RewardPending)
                    {
                        _rewardPending.Add(paymentId);
                    }
                }

                then();
            });
        }

        private void FollowRewards(Action<RecheckResult> onComplete)
        {
            Action done = () => onComplete?.Invoke(new RecheckResult(_confirmed, _alreadyDone, _pending, _rewardPending));
            PaymentProvider.List(ListQuery.Page(1, 20), null, PaymentStatus.Success, listed =>
            {
                if (!listed.IsSuccess || listed.Data?.Items == null)
                {
                    done();
                    return;
                }

                var waiting = listed.Data.Items.Where(p => p.IsRewardPending && !string.IsNullOrEmpty(p.Id) && !_seen.Contains(p.Id)).Select(p => p.Id).ToList();
                FollowEach(waiting, 0, done);
            });
        }

        private void FollowEach(IReadOnlyList<string> ids, int index, Action done)
        {
            if (index >= ids.Count)
            {
                done();
                return;
            }

            FollowReward(ids[index], () => FollowEach(ids, index + 1, done));
        }
    }
}
