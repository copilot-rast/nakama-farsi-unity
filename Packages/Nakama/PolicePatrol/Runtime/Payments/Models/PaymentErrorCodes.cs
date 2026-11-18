namespace PolicePatrol.Sdk.Payments
{
    public static class PaymentErrorCodes
    {
        public const string StoreUnavailable = "STORE_UNAVAILABLE";
        public const string RewardPending = "PAYMENT_REWARD_PENDING";
        public const string ServerRewardPending = "REWARD_PENDING";
        public const string InProgress = "PAYMENT_IN_PROGRESS";
        public const string Expired = "PAYMENT_EXPIRED";
        public const string Closed = "PAYMENT_CLOSED";
        public const string StoreModeChanged = "STORE_MODE_CHANGED";
        public const string SubscriptionNotSupported = "SUBSCRIPTION_NOT_SUPPORTED";
        public const string DeveloperPayloadMismatch = "DEVELOPER_PAYLOAD_MISMATCH";
        public const string StoreConfigurationRejected = "STORE_CONFIGURATION_REJECTED";
        public const string SubscriptionOwnedByAnotherUser = "SUBSCRIPTION_OWNED_BY_ANOTHER_USER";
        public const string PhoneNotVerified = "PAYMENT_PHONE_NOT_VERIFIED";
        public const string PurchaseTokenRequired = "PAYMENT_PURCHASE_TOKEN_IS_REQUIRED";
        public const string ProductHasNoReward = "PAYMENT_PRODUCT_HAS_NO_REWARD";
        public const string CannotBeSettled = "PAYMENT_CANNOT_BE_SETTLED";
        public const string PrizeAlreadyOwned = "PAYMENT_PRIZE_ALREADY_OWNED";
        public const string PrizeRequiresAnotherItem = "PAYMENT_PRIZE_REQUIRES_ANOTHER_ITEM";
        public const string ProductAlreadyBought = "PAYMENT_PRODUCT_ALREADY_BOUGHT";
        public const string ProductLevelTooLow = "PAYMENT_PRODUCT_LEVEL_TOO_LOW";
        public const string ProductLevelTooHigh = "PAYMENT_PRODUCT_LEVEL_TOO_HIGH";
        public const string InvalidProductPrice = "PAYMENT_PRODUCT_PRICE_IS_INVALID";
        public const string GiftUseLimitReached = "GIFT_USE_LIMIT_REACHED";
        public const string GiftTotalLimitReached = "GIFT_TOTAL_LIMIT_REACHED";
        public const string BadRequest = "PAYMENT_BAD_REQUEST";
        public const string AlreadyProcessed = "PAYMENT_HAS_ALREADY_BEEN_SUCCESSFULLY_PROCESSED";
        public const string TokenNotVerified = "TOKEN_NOT_VERIFIED";
        public const string TokenAlreadyValidated = "VALIDATED_PAYMENT";
        public const string InsufficientCurrency = "PAYMENT_INSUFFICIENT_CURRENCY_YOU_NEED_AT_LEAST_OF_THE_REQUIRED_CURRENCY_TO_PURCHASE_THIS_PRODUCT";
        public const string MethodNotSupported = "PAYMENT_METHOD_DOES_NOT_SUPPORT";
        public const string MethodNotSupportedForProduct = "PAYMENT_METHOD_IS_NOT_SUPPORTED_FOR_THIS_PRODUCT_SUPPORTED_METHODS";
        public const string MethodNotImplemented = "PAYMENT_METHOD_IS_NOT_YET_IMPLEMENTED";
        public const string MethodNotConfigured = "PAYMENT_METHOD_IS_NOT_CONFIGURED";
        public const string SkuNotConfigured = "PAYMENT_PRODUCT_DOES_NOT_HAVE_SKU_CONFIGURED_FOR_THIS_STORE";
        public const string ProductNotFound = "PAYMENT_PRODUCT_WITH_ID_NOT_FOUND";
        public const string ProductNotActive = "PAYMENT_PRODUCT_IS_NOT_ACTIVE";
        public const string NotFound = "PAYMENT_WITH_ID_NOT_FOUND";
        public const string AccessDenied = "PAYMENT_YOU_DO_NOT_HAVE_PERMISSION_TO_ACCESS_THIS_PAYMENT";
    }
}
