using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var carInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var fuelQuantity = double.Parse(carInput[1]);
            var fuelConsPerKm = double.Parse(carInput[2]);
            var car = new Car(fuelQuantity, fuelConsPerKm);

            var truckInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            fuelQuantity = double.Parse(truckInput[1]);
            fuelConsPerKm = double.Parse(truckInput[2]);
            var truck = new Truck(fuelQuantity, fuelConsPerKm);

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var action = command[0];

                var vehicleType = command[1];
                Vehicle vehicle;
                if (vehicleType == "Car")
                {
                    vehicle = car;
                }
                else
                {
                    vehicle = truck;
                }

                var variable = double.Parse(command[2]);

                if (action == "Drive")
                {
                    vehicle.Drive(variable);
                }
                else if (action == "Refuel")
                {
                    vehicle.Refuel(variable);
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
