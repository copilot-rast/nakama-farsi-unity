using System.Collections.Generic;

namespace PolicePatrol.Sdk.Cars
{
    public sealed record CarConditionReport
    {
        public double? Health { get; init; }

        public double? Fuel { get; init; }

        public double? Tire { get; init; }

        public double? Oil { get; init; }

        public double? Brake { get; init; }

        public double? CarWash { get; init; }

        public CarConditionReport With(string slot, double? percent)
        {
            switch (CarSlots.Normalize(slot))
            {
                case CarSlots.Fuel: return this with { Fuel = percent };
                case CarSlots.Tire: return this with { Tire = percent };
                case CarSlots.Oil: return this with { Oil = percent };
                case CarSlots.Brake: return this with { Brake = percent };
                case CarSlots.CarWash: return this with { CarWash = percent };
                case CarSlots.Health: return this with { Health = percent };
                default: return this;
            }
        }

        public static CarConditionReport From(CarCondition condition) => condition == null ? new CarConditionReport() : new CarConditionReport
        {
            Health = condition.Health,
            Fuel = condition.Fuel,
            Tire = condition.Tire,
            Oil = condition.Oil,
            Brake = condition.Brake,
            CarWash = condition.CarWash,
        };

        public Dictionary<string, double> ToDictionary()
        {
            var d = new Dictionary<string, double>();
            void Put(string slot, double? v)
            {
                if (v.HasValue)
                {
                    d[slot] = v.Value;
                }
            }

            Put(CarSlots.Fuel, Fuel);
            Put(CarSlots.Tire, Tire);
            Put(CarSlots.Oil, Oil);
            Put(CarSlots.Brake, Brake);
            Put(CarSlots.CarWash, CarWash);
            Put(CarSlots.Health, Health);
            return d;
        }
    }
}
