namespace PolicePatrol.Sdk.Inventory
{
    public sealed record CarSlot(string Key, string Name, string Title, string Group, string Selection, string CollectionId, string[] Parts, string Default);
}
