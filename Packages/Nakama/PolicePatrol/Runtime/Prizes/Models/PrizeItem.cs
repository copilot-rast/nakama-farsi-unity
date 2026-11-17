using Newtonsoft.Json.Linq;

namespace PolicePatrol.Sdk.Prizes
{
    public sealed record PrizeItem(
        string Type,
        string ItemId,
        string Owner,
        string Action,
        JToken Value);
}
