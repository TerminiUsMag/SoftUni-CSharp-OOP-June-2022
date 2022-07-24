using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AirConditionerFuelConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumptionPerKm) : base(fuelQuantity, fuelConsumptionPerKm)
        {
        }
        public override double FuelConsumptionPerKm
        {
            get => base.FuelConsumptionPerKm;
            set => base.FuelConsumptionPerKm = value + AirConditionerFuelConsumption;
        }
        public override void Refuel(double liters)
        {
            var result = liters * 0.95;
            base.Refuel(result);
        }
    }
}
