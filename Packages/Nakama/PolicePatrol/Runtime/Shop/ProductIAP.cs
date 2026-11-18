using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Payments;

namespace PolicePatrol.Sdk.Shop
{
    public sealed class ProductIAP
    {
        public const string PurchaseCancelledCode = "STORE_PURCHASE_CANCELLED";
        public const string PurchaseFailedCode = "STORE_PURCHASE_FAILED";
        public const string StoreSkuMissingCode = "STORE_SKU_MISSING";
        public const int PageSize = 50;

        private readonly IStoreBilling _store;
        private readonly PaymentPoller _poller;

        public ProductIAP(IStoreBilling store, PaymentPoller poller = null)
        {
            _store = store ?? throw new ArgumentNullException(nameof(store));
            _poller = poller ?? new PaymentPoller();
        }

        public string Method => _store.Method;

        public static bool SupportsSubscriptions(string method) => method != PaymentMethods.Myket;

        public void Load(Action<ApiResult<IReadOnlyList<ShopItem>>> onComplete) =>
            LoadPage(1, new List<ShopItem>(), onComplete);

        public void Buy(ShopItem item, Action<ApiResult<Payment>> onComplete)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (item.IsSubscription && !SupportsSubscriptions(_store.Method))
            {
                onComplete?.Invoke(ApiResult<Payment>.Fail(new ApiError(0, PaymentErrorCodes.SubscriptionNotSupported, new JObject { ["method"] = _store.Method, ["productId"] = item.Id }, "Subscriptions cannot be bought with " + _store.Method)));
                return;
            }

            PaymentProvider.InitiateBilling(item.Id, _store.Method, initiated =>
            {
                if (!initiated.IsSuccess)
                {
                    onComplete?.Invoke(ApiResult<Payment>.Fail(initiated.Error));
                    return;
                }

                var billing = initiated.Data;
                Action<StorePurchaseResult> onPurchase = purchase =>
                {
                    if (!purchase.IsSuccess)
                    {
                        onComplete?.Invoke(ApiResult<Payment>.Fail(purchase.IsCancelled
                            ? new ApiError(0, PurchaseCancelledCode, null, "The purchase was cancelled")
                            : new ApiError(0, PurchaseFailedCode, null, purchase.Error ?? "The store could not complete the purchase")));
                        return;
                    }

                    _poller.SubmitBilling(billing.Id, purchase.PurchaseToken, submitted =>
                    {
                        if (!PaymentPoller.IsVerified(submitted))
                        {
                            onComplete?.Invoke(submitted);
                            return;
                        }

                        Action finish = () =>
                        {
                            if (submitted.IsSuccess)
                            {
                                onComplete?.Invoke(submitted);
                                return;
                            }

                            _poller.WaitForReward(billing.Id, onComplete);
                        };

                        if (item.IsSubscription)
                        {
                            finish();
                            return;
                        }

                        _store.Consume(purchase.PurchaseToken, _ => finish());
                    });
                };

                if (item.IsSubscription && _store is ISubscriptionStoreBilling subscriptions)
                {
                    subscriptions.Subscribe(billing.Sku, billing.DeveloperPayload, onPurchase);
                }
                else
                {
                    _store.Purchase(billing.Sku, billing.DeveloperPayload, onPurchase);
                }
            });
        }

        public void RecheckPending(Action<RecheckResult> onComplete) =>
            new PendingPurchaseRecheck(_store, _poller).Run(onComplete);

        private void LoadPage(int page, List<ShopItem> collected, Action<ApiResult<IReadOnlyList<ShopItem>>> onComplete)
        {
            ShopProvider.List(ListQuery.Page(page, PageSize), null, null, result =>
            {
                if (!result.IsSuccess)
                {
                    onComplete?.Invoke(ApiResult<IReadOnlyList<ShopItem>>.Fail(result.Error));
                    return;
                }

                collected.AddRange(result.Data.Items.Select(ToItem).Where(item => item != null));
                if (result.Data.HasNextPage)
                {
                    LoadPage(page + 1, collected, onComplete);
                    return;
                }

                onComplete?.Invoke(ApiResult<IReadOnlyList<ShopItem>>.Ok(collected));
            });
        }

        private ShopItem ToItem(Product product)
        {
            if (!product.IsActive || product.PaymentMethodSupport == null || !product.PaymentMethodSupport.Contains(_store.Method) || (product.IsSubscription && !SupportsSubscriptions(_store.Method)))
            {
                return null;
            }

            if (product.Sku == null || !product.Sku.TryGetValue(_store.Method, out var sku) || string.IsNullOrWhiteSpace(sku))
            {
                return null;
            }

            return new ShopItem(product, _store.Method, sku);
        }
    }
}
