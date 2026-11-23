namespace PolicePatrol.Sdk.Cars
{
    public sealed record CarCondition(int Health, int Fuel, int Tire, int Oil, int Brake, int CarWash)
    {
        public static CarCondition Full => new CarCondition(100, 100, 100, 100, 100, 100);

        public int Get(string slot)
        {
            switch (CarSlots.Normalize(slot))
            {
                case CarSlots.Fuel: return Fuel;
                case CarSlots.Tire: return Tire;
                case CarSlots.Oil: return Oil;
                case CarSlots.Brake: return Brake;
                case CarSlots.CarWash: return CarWash;
                case CarSlots.Health: return Health;
                default: return 0;
            }
        }

        public int Get(int index) => Get(CarSlots.FromIndex(index));
    }
}
