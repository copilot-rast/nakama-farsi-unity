using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using NF = NakamaFarsi.Sdk;

namespace PolicePatrol.Sdk
{
    public static class ErrorAliases
    {
        public static readonly IReadOnlyDictionary<string, string> Common = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["OTP_INVALID_CODE"] = "AUTH_INVALID_CODE",
            ["OTP_EXPIRED"] = "AUTH_INVALID_CODE",
            ["INVALID_PHONE"] = "PHONE_NUMBER_IS_NOT_VALID",
            ["PHONE_NOT_VERIFIED"] = "PAYMENT_PHONE_NOT_VERIFIED",
            ["USERNAME_SEPARATOR_AT_EDGE"] = "USERNAME_INVALID",
            ["USERNAME_MUST_START_WITH_LETTER"] = "USERNAME_INVALID",
            ["USERNAME_DOUBLE_SEPARATOR"] = "USERNAME_INVALID",
            ["USERNAME_RESERVED"] = "USERNAME_INVALID",
            ["USERNAME_TOO_SHORT"] = "USERNAME_INVALID",
            ["USERNAME_TOO_LONG"] = "USERNAME_INVALID",
            ["USERNAME_INVALID_CHARACTERS"] = "USERNAME_INVALID",
            ["PASSWORD_TOO_SHORT"] = "AUTH_PASSWORD_MUST_BE_7_TO_30_CHARACTERS",
            ["PASSWORD_TOO_LONG"] = "AUTH_PASSWORD_MUST_BE_7_TO_30_CHARACTERS",
            ["PASSWORD_INVALID_CHARACTERS"] = "AUTH_PASSWORD_INVALID_CHARACTERS",
            ["ACCOUNT_SUSPENDED"] = "USER_SUSPENDED",
            ["TOKEN_ALREADY_USED"] = "VALIDATED_PAYMENT",
            ["PAYMENT_ALREADY_SETTLED"] = "PAYMENT_HAS_ALREADY_BEEN_SUCCESSFULLY_PROCESSED",
            ["PRODUCT_ALREADY_BOUGHT"] = "PAYMENT_PRODUCT_ALREADY_BOUGHT",
            ["PRODUCT_NOT_FOUND"] = "PAYMENT_PRODUCT_WITH_ID_NOT_FOUND",
            ["PAYMENT_NOT_FOUND"] = "PAYMENT_WITH_ID_NOT_FOUND",
            ["LEVEL_TOO_HIGH"] = "PAYMENT_PRODUCT_LEVEL_TOO_HIGH",
            ["PRIZE_ALREADY_OWNED"] = "PAYMENT_PRIZE_ALREADY_OWNED",
            ["METHOD_NOT_ALLOWED"] = "PAYMENT_METHOD_IS_NOT_SUPPORTED_FOR_THIS_PRODUCT_SUPPORTED_METHODS",
            ["METHOD_UNAVAILABLE"] = "PAYMENT_METHOD_IS_NOT_CONFIGURED",
            ["SKU_REQUIRED"] = "PAYMENT_PRODUCT_DOES_NOT_HAVE_SKU_CONFIGURED_FOR_THIS_STORE",
        };

        public static readonly IReadOnlyDictionary<string, string> Inventory = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["ITEM_NOT_FOUND"] = "INVENTORY_ITEM_NOT_FOUND",
            ["ALREADY_OWNED"] = "INVENTORY_ITEM_ALREADY_OWNED",
            ["ALREADY_UNLOCKED"] = "INVENTORY_ITEM_ALREADY_UNLOCKED",
            ["LEVEL_TOO_LOW"] = "INVENTORY_LEVEL_TOO_LOW",
            ["REQUIRES_ITEM"] = "INVENTORY_REQUIRES_ANOTHER_ITEM",
            ["NOT_FOR_SALE"] = "INVENTORY_ITEM_NOT_FOR_SALE",
            ["ITEM_SALE_STOPPED"] = "INVENTORY_ITEM_SALE_STOPPED",
            ["NOT_UNLOCKABLE"] = "INVENTORY_ITEM_NOT_FOR_SALE",
            ["UNLOCK_NOT_AVAILABLE"] = "INVENTORY_ITEM_NOT_FOR_SALE",
            ["INSUFFICIENT_BALANCE"] = "INVENTORY_NOT_ENOUGH_CURRENCY",
            ["NOT_OWNED"] = "INVENTORY_ITEM_NOT_OWNED",
            ["TRACK_NOT_FOUND"] = "INVENTORY_UPGRADE_NOT_FOUND",
            ["UPGRADE_MAXED"] = "INVENTORY_UPGRADE_AT_MAX",
            ["UPGRADE_CHANGED"] = "INVENTORY_UPGRADE_LEVEL_CHANGED",
            ["SERVICE_NOT_FOUND"] = "INVENTORY_SERVICE_NOT_FOUND",
            ["INVALID_UNITS"] = "INVENTORY_INVALID_UNITS",
            ["REQUEST_ID_REQUIRED"] = "INVENTORY_REQUEST_ID_REQUIRED",
            ["REQUEST_ID_REUSED"] = "INVENTORY_REQUEST_ID_REUSED",
            ["ANALYTICS_BUSY"] = "INVENTORY_BUSY_TRY_AGAIN",
            ["PART_VEHICLE_NOT_OWNED"] = "INVENTORY_PART_VEHICLE_NOT_OWNED",
        };

        public static readonly IReadOnlyDictionary<string, string> Stages = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["STAGE_NOT_FOUND"] = "PROGRESS_STAGE_NOT_FOUND",
            ["STAGE_KEY_REQUIRED"] = "PROGRESS_STAGE_NOT_FOUND",
            ["STAGE_LOCKED"] = "PROGRESS_STAGE_LOCKED",
            ["STAGE_FINISHED_TOO_FAST"] = "PROGRESS_STAGE_FINISHED_TOO_FAST",
            ["INVALID_RESULT"] = "PROGRESS_INVALID_RESULT",
            ["STAGE_BUSY"] = "PROGRESS_BUSY_TRY_AGAIN",
            ["ATTEMPT_REQUIRED"] = "PROGRESS_ATTEMPT_REQUIRED",
            ["ATTEMPT_NOT_FOUND"] = "PROGRESS_ATTEMPT_NOT_FOUND",
            ["ATTEMPT_CLOSED"] = "PROGRESS_ATTEMPT_CLOSED",
            ["ATTEMPT_EXPIRED"] = "PROGRESS_ATTEMPT_EXPIRED",
            ["STAGE_ALREADY_WON"] = "PROGRESS_STAGE_ALREADY_WON",
            ["STAGE_ITEM_REQUIRED"] = "PROGRESS_STAGE_ITEM_REQUIRED",
            ["STAGE_ITEM_NOT_ALLOWED"] = "PROGRESS_STAGE_ITEM_NOT_ALLOWED",
            ["ITEM_NOT_OWNED"] = "PROGRESS_ITEM_NOT_OWNED",
        };

        public static readonly IReadOnlyDictionary<string, string> Payments = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["INSUFFICIENT_BALANCE"] = "PAYMENT_INSUFFICIENT_CURRENCY_YOU_NEED_AT_LEAST_OF_THE_REQUIRED_CURRENCY_TO_PURCHASE_THIS_PRODUCT",
            ["LEVEL_TOO_LOW"] = "PAYMENT_PRODUCT_LEVEL_TOO_LOW",
            ["REQUIRES_ITEM"] = "PAYMENT_PRIZE_REQUIRES_ANOTHER_ITEM",
        };

        private static readonly IReadOnlyDictionary<string, string> UsernameReasons = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["USERNAME_TOO_SHORT"] = Users.UserErrorCodes.ReasonLength,
            ["USERNAME_TOO_LONG"] = Users.UserErrorCodes.ReasonLength,
            ["USERNAME_INVALID_CHARACTERS"] = Users.UserErrorCodes.ReasonCharacters,
            ["USERNAME_SEPARATOR_AT_EDGE"] = Users.UserErrorCodes.ReasonSeparatorEdge,
            ["USERNAME_MUST_START_WITH_LETTER"] = Users.UserErrorCodes.ReasonStart,
            ["USERNAME_DOUBLE_SEPARATOR"] = Users.UserErrorCodes.ReasonSeparators,
            ["USERNAME_RESERVED"] = Users.UserErrorCodes.ReasonReserved,
            ["USERNAME_TAKEN"] = Users.UserErrorCodes.ReasonTaken,
            ["USERNAME_REQUIRED"] = Users.UserErrorCodes.ReasonRequired,
        };

        public static ApiError Convert(NF.ApiError e, IReadOnlyDictionary<string, string> extra = null)
        {
            if (e == null)
            {
                return null;
            }

            var code = e.Code;
            if (code == NF.ApiError.TimeoutCode)
            {
                code = ApiError.NetworkErrorCode;
            }
            else if (code == NF.ApiError.NotLoggedInCode || code == NF.ApiError.SessionExpiredCode)
            {
                code = "UNAUTHORIZED";
            }
            else if (extra != null && extra.TryGetValue(code, out var a))
            {
                code = a;
            }
            else if (Common.TryGetValue(code, out var b))
            {
                code = b;
            }
            else if (e.Status == 429 && (code.EndsWith("_RATE_LIMITED", StringComparison.Ordinal) || code.StartsWith("TOO_MANY_", StringComparison.Ordinal)))
            {
                code = ApiError.TooManyRequestsCode;
            }

            var meta = e.Meta != null ? (JObject)e.Meta.DeepClone() : new JObject();
            if (e.RetryAfterSeconds.HasValue && meta["retryAfter"] == null)
            {
                meta["retryAfter"] = e.RetryAfterSeconds.Value;
            }

            if (meta["reason"] == null && UsernameReasons.TryGetValue(e.Code ?? string.Empty, out var reason))
            {
                meta["reason"] = reason;
            }

            return new ApiError(e.Status, code, meta, e.Message) { ServerCode = e.Code, Field = e.Field };
        }
    }
}
