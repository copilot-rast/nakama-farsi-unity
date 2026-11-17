namespace PolicePatrol.Sdk.Assets
{
    public sealed record AssetApplyResult(string[] Warnings)
    {
        public bool IsClean => Warnings.Length == 0;
    }
}
