using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Car : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsPerKm;
        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            set
            {
                fuelQuantity = value;
            }
        }
        public double FuelConsumptionPerKM
        {
            get
            {
                return fuelConsPerKm;
            }
            set
            {
                fuelConsPerKm = value;
            }
        }

        public void Drive(double distance)
        {
            var fuelNeeded = distance * this.FuelConsumptionPerKM;
            if (FuelQuantity < fuelNeeded)
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
                FuelQuantity -= fuelNeeded;
            }
        }

        public void Refuel(double liters)
        {
            throw new NotImplementedException();
        }
    }
}
