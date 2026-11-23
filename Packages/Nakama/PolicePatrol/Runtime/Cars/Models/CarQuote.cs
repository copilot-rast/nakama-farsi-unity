namespace PolicePatrol.Sdk.Cars
{
    public sealed record CarQuote(string Slot, int Percent, bool Available, bool Full, double Coin, double Gem, double Seconds, CarPrice Price);
}
