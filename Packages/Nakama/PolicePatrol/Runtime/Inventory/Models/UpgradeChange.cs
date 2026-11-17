namespace PolicePatrol.Sdk.Inventory
{
    public sealed record UpgradeChange(PlayerItem Item, string Upgrade, int Level, ItemPrice[] Paid);
}
