namespace PolicePatrol.Sdk.Inventory
{
    public sealed record EquipChange(PlayerItem Item, string Slot, string[] Unequipped);
}
