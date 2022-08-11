using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        static Garage garage = null;
        public class RepairsShopTests
        {
            [SetUp]
            public void SetUp()
            {
                garage = new Garage("BMW", 10);
            }

            [Test]
            public void Test_Garage_Constructor()
            {
                Assert.IsNotNull(garage);
                Assert.AreEqual("BMW", garage.Name);
                Assert.AreEqual(10, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void Test_Garage_If_CarsInGarage_Is_Accurate()
            {
                var car = new Car("E39", 1);
                garage.AddCar(car);
                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void Test_Garage_Has_No_Free_Mechanics()
            {
                try
                {
                for (int i = 0; i < 11; i++)
                {
                    garage.AddCar(new Car($"{i}", i + new Random().Next(1, 11)));
                }
                }
                catch (Exception ex)
                {
                    Assert.AreEqual("No mechanic available.", ex.Message);
                }
                Assert.AreEqual(10, garage.CarsInGarage);
            }

            [Test]
            public void Test_FixCar()
            {
                var firstCar = new Car("E39", 10);
                garage.AddCar(firstCar);
                Car car = garage.FixCar("E39");
                Assert.AreEqual(firstCar, car);
                Assert.AreEqual(1, garage.CarsInGarage);
                var removedCars = garage.RemoveFixedCar();
                Assert.AreEqual(1, removedCars);
                Assert.AreEqual(0, garage.CarsInGarage);
            }
        }
    }
}