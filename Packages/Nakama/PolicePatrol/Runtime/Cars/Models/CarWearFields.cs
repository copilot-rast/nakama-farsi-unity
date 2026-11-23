using System.Collections.Generic;

namespace PolicePatrol.Sdk.Cars
{
    public static class CarWearFields
    {
        public const string DistanceKm = "distanceKm";
        public const string OffroadKm = "offroadKm";
        public const string BrakeKm = "brakeKm";
        public const string VehicleCondition = "vehicleCondition";

        public static Dictionary<string, object> Build(double? distanceKm, double? offroadKm = null, double? brakeKm = null, CarConditionReport vehicleCondition = null) =>
            Add(new Dictionary<string, object>(), distanceKm, offroadKm, brakeKm, vehicleCondition);

        public static Dictionary<string, object> Add(Dictionary<string, object> fields, double? distanceKm, double? offroadKm = null, double? brakeKm = null, CarConditionReport vehicleCondition = null)
        {
            fields = fields ?? new Dictionary<string, object>();
            if (distanceKm.HasValue)
            {
                fields[DistanceKm] = distanceKm.Value;
            }

            if (offroadKm.HasValue)
            {
                fields[OffroadKm] = offroadKm.Value;
            }

            if (brakeKm.HasValue)
            {
                fields[BrakeKm] = brakeKm.Value;
            }

            var condition = vehicleCondition?.ToDictionary();
            if (condition != null && condition.Count > 0)
            {
                fields[VehicleCondition] = condition;
            }

            return fields;
        }
    }
}
