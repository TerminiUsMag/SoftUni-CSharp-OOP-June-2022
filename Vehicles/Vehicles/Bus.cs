using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private double AirConditionerFuelConsumption;
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            this.AirConditionerFuelConsumption = 1.4;
        }
        public override double FuelConsumptionPerKm
        {
            get => base.FuelConsumptionPerKm;
            set => base.FuelConsumptionPerKm = value + AirConditionerFuelConsumption;
        }
    }
}
