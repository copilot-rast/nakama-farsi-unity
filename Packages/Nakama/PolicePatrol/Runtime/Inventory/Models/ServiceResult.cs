namespace PolicePatrol.Sdk.Inventory
{
    public sealed record ServiceResult(string ItemKey, string Service, int Units, ItemPrice[] Paid);
}
