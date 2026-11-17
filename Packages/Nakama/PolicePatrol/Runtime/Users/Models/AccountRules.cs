namespace PolicePatrol.Sdk.Users
{
    public sealed record AccountRules(
        int UsernameMinLength,
        int UsernameMaxLength,
        int PasswordMinLength,
        int PasswordMaxLength);
}
