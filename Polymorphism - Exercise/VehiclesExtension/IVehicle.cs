using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public interface IVehicle
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumptionPerKM { get; set; }

        public void Drive(double distance);
        public void Refuel(double liters);
    }
}
