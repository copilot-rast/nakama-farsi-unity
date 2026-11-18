namespace PolicePatrol.Sdk.Users
{
    public static class UserErrorCodes
    {
        public const string UsernameTaken = "USERNAME_TAKEN";
        public const string UsernameInvalid = "USERNAME_INVALID";
        public const string ReasonRequired = "required";
        public const string ReasonLength = "length";
        public const string ReasonCharacters = "characters";
        [System.Obsolete("The server sends separator_edge; use ReasonSeparatorEdge.")]
        public const string ReasonDotEdge = "dot_edge";
        public const string ReasonSeparatorEdge = "separator_edge";
        public const string ReasonTaken = "taken";
        public const string ReasonStart = "start";
        public const string ReasonSeparators = "separators";
        public const string PasswordLength = "AUTH_PASSWORD_MUST_BE_7_TO_30_CHARACTERS";
        public const string PasswordCharacters = "AUTH_PASSWORD_INVALID_CHARACTERS";
        public const string ReasonReserved = "reserved";
        public const string Suspended = "USER_SUSPENDED";
    }
}
