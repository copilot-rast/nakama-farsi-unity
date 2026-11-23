using System;
using System.Linq;

namespace PolicePatrol.Sdk.Cars
{
    public sealed record CarConditions(DateTimeOffset? ServerTime, string Route, bool Adopted, CarView[] Cars)
    {
        public DateTimeOffset ReceivedAt { get; init; } = DateTimeOffset.UtcNow;

        public TimeSpan ServerOffset => ServerTime.HasValue ? ServerTime.Value - ReceivedAt : TimeSpan.Zero;

        public DateTimeOffset ServerNowAt(DateTimeOffset localNow) => localNow + ServerOffset;

        public CarView Equipped => Cars?.FirstOrDefault(c => c.Equipped);

        public CarView Find(string vehicleKey) => Cars?.FirstOrDefault(c => c.VehicleKey == vehicleKey || c.ServerKey == vehicleKey || (!string.IsNullOrEmpty(c.GameId) && string.Equals(c.GameId, vehicleKey, StringComparison.OrdinalIgnoreCase)));
    }
}
