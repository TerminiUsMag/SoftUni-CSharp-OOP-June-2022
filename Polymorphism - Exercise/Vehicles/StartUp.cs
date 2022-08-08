using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var fuelQuantity = double.Parse(input[1]);
            var fuelConsPerKm = double.Parse(input[2]);
            var tankCapacity = double.Parse(input[3]);
            var car = new Car(fuelQuantity, fuelConsPerKm, tankCapacity);

            input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            fuelQuantity = double.Parse(input[1]);
            fuelConsPerKm = double.Parse(input[2]);
            tankCapacity = double.Parse(input[3]);

            var truck = new Truck(fuelQuantity, fuelConsPerKm, tankCapacity);

            input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            fuelQuantity = double.Parse(input[1]);
            fuelConsPerKm = double.Parse(input[2]);
            tankCapacity = double.Parse(input[3]);

            var bus = new Bus(fuelQuantity, fuelConsPerKm, tankCapacity);

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
                else if (vehicleType == "Bus")
                {
                    vehicle = bus;
                }
                else
                {
                    vehicle = truck;
                }

                var variable = double.Parse(command[2]);
                if (action == "DriveEmpty")
                {
                    bus.DriveEmpty(variable);
                }
                else if (action == "Drive")
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
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
