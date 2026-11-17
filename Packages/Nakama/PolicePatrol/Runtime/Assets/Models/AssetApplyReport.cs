namespace PolicePatrol.Sdk.Assets
{
    public sealed record AssetApplyReport(int Applied, string[] Missing, string[] Warnings, bool Skipped, bool Offline = false);
}
