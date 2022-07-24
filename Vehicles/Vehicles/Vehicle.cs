using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumptionPerKm;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            if (TankCapacity < fuelQuantity)
                this.FuelQuantity = 0;
            else
                this.fuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }
        public virtual double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            set
            {
                var currentQuantity = this.FuelQuantity;
                if (value > this.TankCapacity)
                    throw new ArgumentException("Cannot fit {0} fuel in the tank");
                else
                    fuelQuantity = value;
            }
        }
        public virtual double FuelConsumptionPerKm
        {
            get { return fuelConsumptionPerKm; }
            set { fuelConsumptionPerKm = value; }
        }

        public double TankCapacity { get => tankCapacity; set => tankCapacity = value; }

        public void Drive(double distance)
        {
            var fuelNeeded = distance * fuelConsumptionPerKm;
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
        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            try
            {
                FuelQuantity += liters;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(String.Format(ae.Message, liters));
            }
        }
    }
}
