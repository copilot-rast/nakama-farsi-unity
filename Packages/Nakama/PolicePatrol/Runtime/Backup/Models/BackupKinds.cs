namespace PolicePatrol.Sdk.Backup
{
    public static class BackupKinds
    {
        public const string Ground = "ground";
        public const string Air = "air";
    }

    public static class BackupDebitModes
    {
        public const string Arrival = "arrival";
        public const string Call = "call";
    }

    public static class BackupErrorCodes
    {
        public const string NotOwned = "BACKUP_NOT_OWNED";
        public const string Limit = "BACKUP_LIMIT";
        public const string Cooldown = "BACKUP_COOLDOWN";
        public const string NotFound = "BACKUP_NOT_FOUND";
        public const string UnitNotAllowed = "BACKUP_UNIT_NOT_ALLOWED";
        public const string StageNotRunning = "STAGE_NOT_RUNNING";
        public const string RefundOff = "BACKUP_REFUND_OFF";
        public const string RefundExpired = "BACKUP_REFUND_EXPIRED";
        public const string UseNotFound = "BACKUP_USE_NOT_FOUND";
        public const string RequestIdReused = "REQUEST_ID_REUSED";
    }
}
