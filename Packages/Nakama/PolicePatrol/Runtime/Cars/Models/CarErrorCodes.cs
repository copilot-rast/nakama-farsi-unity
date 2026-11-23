namespace PolicePatrol.Sdk.Cars
{
    public static class CarErrorCodes
    {
        public const string ServiceAlreadyRunning = "SERVICE_ALREADY_RUNNING";
        public const string ServiceNotReady = "SERVICE_NOT_READY";
        public const string ServiceNotRunning = "SERVICE_NOT_RUNNING";
        public const string ServiceNotNeeded = "SERVICE_NOT_NEEDED";
        public const string ServiceNotAvailable = "SERVICE_NOT_AVAILABLE";
        public const string SlotInvalid = "SERVICE_SLOT_INVALID";
        public const string RouteInvalid = "SERVICE_ROUTE_INVALID";
        public const string NeedsService = "CAR_NEEDS_SERVICE";
        public const string InService = "CAR_IN_SERVICE";
        public const string ConditionOff = "CAR_CONDITION_OFF";
        public const string ReportsOff = "CAR_REPORTS_OFF";
        public const string ConditionInvalid = "CONDITION_INVALID";
        public const string VehicleKeyRequired = "VEHICLE_KEY_REQUIRED";
        public const string TooManyCars = "TOO_MANY_CARS";
        public const string InsufficientBalance = "INSUFFICIENT_BALANCE";
        public const string ItemNotOwned = "ITEM_NOT_OWNED";
        public const string ItemNotFound = "ITEM_NOT_FOUND";
        public const string RequestIdReused = "REQUEST_ID_REUSED";
        public const string RequestIdRequired = "REQUEST_ID_REQUIRED";
        public const string InvalidPoi = "INVALID_POI";
    }
}
