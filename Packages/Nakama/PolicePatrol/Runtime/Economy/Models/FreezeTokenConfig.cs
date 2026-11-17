namespace PolicePatrol.Sdk.Economy
{
    public sealed record FreezeTokenConfig(
        int Default,
        int? CooldownDuration);
}
