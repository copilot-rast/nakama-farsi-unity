namespace PolicePatrol.Sdk.Cars
{
    public sealed record CarAdoptEntry(string VehicleKey, CarConditionReport Condition, CarAdoptTicket[] Services = null);
}
