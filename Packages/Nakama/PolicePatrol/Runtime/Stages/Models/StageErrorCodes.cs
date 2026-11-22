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
        public const string AlreadyWon = "PROGRESS_STAGE_ALREADY_WON";
        public const string ItemRequired = "PROGRESS_STAGE_ITEM_REQUIRED";
        public const string ItemNotAllowed = "PROGRESS_STAGE_ITEM_NOT_ALLOWED";
        public const string ItemNotOwned = "PROGRESS_ITEM_NOT_OWNED";
        public const string ServerOwned = "STAGE_SERVER_OWNED";
        public const string RewardLimitedCode = "REWARD_LIMITED";
        public const string LimitedCooldown = "cooldown";
        public const string LimitedDaily = "daily_limit";
    }
}
