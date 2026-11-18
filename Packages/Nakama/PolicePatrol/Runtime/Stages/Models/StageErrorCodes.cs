namespace PolicePatrol.Sdk.Stages
{
    public static class StageErrorCodes
    {
        public const string NotFound = "PROGRESS_STAGE_NOT_FOUND";
        public const string Locked = "PROGRESS_STAGE_LOCKED";
        public const string TooFast = "PROGRESS_STAGE_FINISHED_TOO_FAST";
        public const string InvalidResult = "PROGRESS_INVALID_RESULT";
        public const string Busy = "PROGRESS_BUSY_TRY_AGAIN";
        public const string AttemptRequired = "PROGRESS_ATTEMPT_REQUIRED";
        public const string AttemptNotFound = "PROGRESS_ATTEMPT_NOT_FOUND";
        public const string AttemptClosed = "PROGRESS_ATTEMPT_CLOSED";
        public const string AttemptExpired = "PROGRESS_ATTEMPT_EXPIRED";
        public const string ServerOwned = "STAGE_SERVER_OWNED";
        public const string LimitedCooldown = "cooldown";
        public const string LimitedDaily = "daily_limit";
    }
}
