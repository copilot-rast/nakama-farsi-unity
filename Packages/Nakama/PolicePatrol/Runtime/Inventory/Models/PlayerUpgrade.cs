namespace PolicePatrol.Sdk.Inventory
{
    public sealed record PlayerUpgrade(string Key, string Name, int Level, int MaxLevel, ItemPrice NextPrice);
}
