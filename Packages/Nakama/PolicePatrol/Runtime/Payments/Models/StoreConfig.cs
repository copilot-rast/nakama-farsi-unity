namespace PolicePatrol.Sdk.Payments
{
    public sealed record StoreConfig(string Method, bool Sandbox, string RsaPublicKey);
}
