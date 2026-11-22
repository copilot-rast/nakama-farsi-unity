namespace PolicePatrol.Sdk.Stats
{
    public static class StatsErrorCodes
    {
        public const string ReportInvalid = "STATS_REPORT_INVALID";
        public const string Busy = "STATS_BUSY_TRY_AGAIN";
        public const string GroupNotFound = "ANALYTICS_GROUP_NOT_FOUND";
        public const string StepNotFound = "ANALYTICS_STEP_NOT_FOUND";
        public const string StepLocked = "ANALYTICS_STEP_LOCKED";
        public const string NothingToClaim = "ANALYTICS_NOTHING_TO_CLAIM";
        public const string AlreadyClaimed = "ANALYTICS_ALREADY_CLAIMED";
        public const string ClaimBusy = "ANALYTICS_BUSY";
        public const string TooManyKeys = "ANALYTICS_TOO_MANY_KEYS";
    }
}
