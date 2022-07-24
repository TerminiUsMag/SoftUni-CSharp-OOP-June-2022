using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double AirConditionerFuelConstumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }
        public override double FuelConsumptionPerKm
        {
            get => base.FuelConsumptionPerKm;
            set => base.FuelConsumptionPerKm = value + AirConditionerFuelConstumption;
        }


    }
}
