namespace PolicePatrol.Sdk.Assets
{
    public enum AssetSyncStatus
    {
        Same,
        New,
        Changed,
        ServerNewer,
        Conflict,
        Differs,
        OtherFile,
        ServerOnly,
    }
}
