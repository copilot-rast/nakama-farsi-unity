using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PolicePatrol.Sdk.Shop;

namespace PolicePatrol.Sdk.Payments
{
    public static class PaymentProvider
    {
        public static void Methods(Action<ApiResult<string[]>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var r = await c.Rpc("shopx_purchase_rules", new JObject { ["lang"] = c.Language }, true).ConfigureAwait(false);
                return Mapping.Arr(r, "methods").Where(m => !J.Bool(m, "blocked")).Select(m => J.Str(m, "method")).Where(m => m != null).ToArray();
            }, ErrorAliases.Payments, "shopx_purchase_rules");

        public static void StoreConfig(string method, Action<ApiResult<StoreConfig>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var r = await c.Rpc("economy_store_config", new JObject { ["method"] = method }, true).ConfigureAwait(false);
                return new StoreConfig(J.Str(r, "method") ?? method, J.Bool(r, "sandbox"), J.Str(r, "rsaPublicKey"));
            }, ErrorAliases.Payments, "economy_store_config");

        public static void List(ListQuery query, string[] productIds, string status, Action<ApiResult<PagedResult<Payment>>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var size = Math.Max(1, query?.LimitItem ?? 20);
                var r = await c.Rpc("economy_payments_mine", new JObject { ["limit"] = size, ["lang"] = c.Language }, true).ConfigureAwait(false);
                var rows = Mapping.Arr(r, "items").Select(p => ToPayment(p, c.Core.Session.UserId))
                    .Where(p => (productIds == null || productIds.Length == 0 || productIds.Contains(p.ProductId)) && (status == null || p.Status == status)).ToArray();
                return new PagedResult<Payment>(rows, rows.Length, 1, size);
            }, ErrorAliases.Payments, "economy_payments_mine");

        public static void Get(string id, Action<ApiResult<Payment>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var r = await c.Rpc("economy_purchase_status", new JObject { ["paymentId"] = id, ["lang"] = c.Language }, true).ConfigureAwait(false);
                return ToPayment(r, c.Core.Session.UserId, id);
            }, ErrorAliases.Payments, "economy_purchase_status");

        public static void Preview(string productId, string paymentMethod, Action<ApiResult<PaymentPreview>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var product = await ShopProvider.Find(c, productId).ConfigureAwait(false);
                return new PaymentPreview((decimal)(product.Price?.Amount ?? 0), (decimal)product.FinalPrice, product);
            }, ErrorAliases.Payments, "economy_catalog");

        public static void Initiate(string productId, string paymentMethod, Action<ApiResult<InitiatePaymentResult>> onComplete, string giftCode = null) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var r = await Start(c, productId, paymentMethod, giftCode).ConfigureAwait(false);
                return new InitiatePaymentResult(J.Str(r, "paymentId"), J.Str(r, "redirectUrl"), J.Str(r, "paymentId"));
            }, ErrorAliases.Payments, "economy_purchase_start");

        public static void InitiateBilling(string productId, string paymentMethod, Action<ApiResult<BillingInitiation>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var r = await Start(c, productId, paymentMethod, null).ConfigureAwait(false);
                return new BillingInitiation(J.Str(r, "paymentId"), (decimal)J.Num(r, "amount"), (decimal)J.Num(r, "amount"), J.Str(r, "productName"), J.Str(r, "sku"), J.Str(r, "developerPayload") ?? J.Str(r, "paymentId"));
            }, ErrorAliases.Payments, "economy_purchase_start");

        public static void SubmitBilling(string paymentId, string purchaseToken, Action<ApiResult<Payment>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var r = await c.Rpc("economy_purchase_submit", new JObject { ["paymentId"] = paymentId, ["token"] = purchaseToken }, false, true).ConfigureAwait(false);
                return ToPayment(r, c.Core.Session.UserId, paymentId);
            }, ErrorAliases.Payments, "economy_purchase_submit");

        public static void Review(string sku, string purchaseToken, string paymentMethod, Action<ApiResult<Payment>> onComplete) =>
            PolicePatrolSdk.Run(onComplete, async c =>
            {
                var r = await c.Rpc("economy_purchase_review", new JObject { ["sku"] = sku, ["token"] = purchaseToken, ["method"] = paymentMethod }, false, true).ConfigureAwait(false);
                return ToPayment(r, c.Core.Session.UserId);
            }, ErrorAliases.Payments, "economy_purchase_review");

        private static Task<JToken> Start(ApiClient c, string productId, string method, string giftCode)
        {
            var body = new JObject { ["productId"] = productId, ["method"] = method == PaymentMethods.Zarrinpal ? "zarinpal" : method, ["lang"] = c.Language };
            if (!string.IsNullOrEmpty(giftCode))
            {
                body["giftCode"] = giftCode;
            }

            return c.Rpc("economy_purchase_start", body, false);
        }

        internal static Payment ToPayment(JToken r, string userId, string paymentId = null)
        {
            var status = (J.Str(r, "status") ?? PaymentStatus.Pending).ToLowerInvariant();
            if (status == "succeeded" || status == "paid" || status == "completed" || status == "granted")
            {
                status = PaymentStatus.Success;
            }

            var created = J.TimeOr(r, "createdAt");
            return new Payment(
                J.Str(r, "paymentId", "id") ?? paymentId,
                userId,
                "product",
                J.Str(r, "productId"),
                (decimal)J.Num(r, "amount"),
                (decimal)J.Num(r, "amount"),
                (decimal)J.Num(r, "amount"),
                J.Str(r, "method"),
                status,
                J.Str(r, "transactionId"),
                null,
                J.Str(r, "error"),
                J.Str(r, "giftCode"),
                null,
                J.Str(r, "refId"),
                null,
                created,
                J.Time(r, "updatedAt") ?? created)
            {
                RewardGranted = r is JObject o && o["rewardGranted"] is JValue granted && granted.Type == JTokenType.Boolean ? (bool?)(bool)granted : null,
            };
        }

        internal static ApiResult<Payment> RewardCheck(ApiResult<Payment> result)
        {
            if (result == null || !result.IsSuccess || result.Data == null || !result.Data.IsRewardPending)
            {
                return result;
            }

            var server = string.IsNullOrEmpty(result.Data.ErrorMessage) ? PaymentErrorCodes.ServerRewardPending : result.Data.ErrorMessage;
            var meta = new JObject { ["paymentId"] = result.Data.Id, ["serverCode"] = server, ["status"] = result.Data.Status };
            return ApiResult<Payment>.Fail(new ApiError(200, PaymentErrorCodes.RewardPending, meta, "The payment was received and the reward is still being granted") { ServerCode = server });
        }
    }
}
