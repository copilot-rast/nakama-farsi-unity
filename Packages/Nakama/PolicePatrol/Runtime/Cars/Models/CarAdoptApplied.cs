namespace PolicePatrol.Sdk.Cars
{
    public sealed record CarAdoptApplied(string VehicleKey, CarCondition Before, CarCondition After, string[] Services);
}
