using System;

namespace PolicePatrol.Sdk.Cars
{
    public static class CarSlots
    {
        public const string Fuel = "fuel";
        public const string Tire = "tire";
        public const string Oil = "oil";
        public const string Brake = "brake";
        public const string CarWash = "carWash";
        public const string Health = "health";
        public const string Repair = "repair";

        private static readonly string[] Order = { Fuel, Tire, Oil, Brake, CarWash, Health };

        public static string[] All => (string[])Order.Clone();

        public static string FromIndex(int index) => index >= 0 && index < Order.Length ? Order[index] : null;

        public static int ToIndex(string slot)
        {
            var key = Normalize(slot);
            return key == null ? -1 : Array.IndexOf(Order, key);
        }

        public static string Of<TEnum>(TEnum value) where TEnum : struct, Enum => FromIndex(Convert.ToInt32(value));

        public static TEnum ToEnum<TEnum>(string slot) where TEnum : struct, Enum => (TEnum)Enum.ToObject(typeof(TEnum), ToIndex(slot));

        public static string Normalize(string slot)
        {
            var s = slot?.Trim();
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }

            if (string.Equals(s, Repair, StringComparison.OrdinalIgnoreCase))
            {
                return Health;
            }

            return Array.Find(Order, x => string.Equals(x, s, StringComparison.OrdinalIgnoreCase));
        }
    }
}
