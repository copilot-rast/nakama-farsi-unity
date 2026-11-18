namespace PolicePatrol.Sdk.Inventory
{
    public static class InventoryErrorCodes
    {
        public const string NotFound = "INVENTORY_ITEM_NOT_FOUND";
        public const string AlreadyOwned = "INVENTORY_ITEM_ALREADY_OWNED";
        public const string AlreadyUnlocked = "INVENTORY_ITEM_ALREADY_UNLOCKED";
        public const string LevelTooLow = "INVENTORY_LEVEL_TOO_LOW";
        public const string RequiresItem = "INVENTORY_REQUIRES_ANOTHER_ITEM";
        public const string NotForSale = "INVENTORY_ITEM_NOT_FOR_SALE";
        public const string SaleStopped = "INVENTORY_ITEM_SALE_STOPPED";
        public const string NotEnough = "INVENTORY_NOT_ENOUGH_CURRENCY";
        public const string Busy = "INVENTORY_BUSY_TRY_AGAIN";
        public const string NotOwned = "INVENTORY_ITEM_NOT_OWNED";
        public const string UpgradeNotFound = "INVENTORY_UPGRADE_NOT_FOUND";
        public const string UpgradeAtMax = "INVENTORY_UPGRADE_AT_MAX";
        public const string UpgradeLevelChanged = "INVENTORY_UPGRADE_LEVEL_CHANGED";
        public const string ServiceNotFound = "INVENTORY_SERVICE_NOT_FOUND";
        public const string InvalidUnits = "INVENTORY_INVALID_UNITS";
        public const string RequestIdRequired = "INVENTORY_REQUEST_ID_REQUIRED";
        public const string RequestIdReused = "INVENTORY_REQUEST_ID_REUSED";
    }
}
