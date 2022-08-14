using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void Test_Weapon_Creation()
            {
                var weapon = new Weapon("Gun", 10, 10);
                Assert.AreEqual("Gun", weapon.Name);
                Assert.AreEqual(10,weapon.Price);
                Assert.AreEqual(10, weapon.DestructionLevel);
                Assert.AreEqual(true, weapon.IsNuclear);
            }
            [Test]
            public void Test_Weapon_Price_Cannot_Be_Negative()
            {
                Assert.Throws<ArgumentException>(() => new Weapon("Gun", -1, 100), "Price cannot be negative.");
            }
            [Test]
            public void Test_Weapon_Should_Be_Nuclear_After_IncreaseDestructionLevel()
            {
                var weapon = new Weapon("Gun", 10, 9);
                Assert.AreEqual(false, weapon.IsNuclear);
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(true, weapon.IsNuclear);
            }
            [Test]
            public void Test_Planet_Name_Cannot_Be_Null_Or_Empty()
            {
                Assert.Throws<ArgumentException>(() => new Planet("", 10), "Invalid planet Name");
            }
            [Test]
            public void Test_Planet_Budget_Cannot_Drop_Below_Zero()
            {
                Assert.Throws<ArgumentException>(() => new Planet("Earth", -1), "Budget cannot drop below Zero!");
            }
            [Test]
            public void Test_Planet_Creation()
            {
                var planet = new Planet("Earth", 10);
                Assert.AreEqual("Earth", planet.Name);
                Assert.AreEqual(10, planet.Budget);
            }
            [Test]
            public void Test_Planet_MilitaryPowerRatio()
            {
                var planet = new Planet("Earth", 10);
                planet.AddWeapon(new Weapon("Gun", 10, 9));
                Assert.AreEqual(9,planet.MilitaryPowerRatio);
            }
            [Test]
            public void Test_Planet_Profit_Should_Increase_Planet_Budget()
            {
                var planet = new Planet("Earth", 10);
                Assert.AreEqual(10, planet.Budget);
                planet.Profit(5);
                Assert.AreEqual(15,planet.Budget);
            }
            [Test]
            public void Test_Planet_SpendFunds_Should_Throw_Exeption_If_Not_Enought_Budget()
            {
                var planet = new Planet("Earth", 10);
                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(11), "Not enough funds to finalize the deal.");
            }
            [Test]
            public void Test_Planet_SpendFunds_Should_Subtract_From_Budget()
            {
                var planet = new Planet("Earth", 10);
                planet.SpendFunds(5);
                Assert.AreEqual(10 - 5, planet.Budget);
            }
            [Test]
            public void Test_Planet_AddWeapon_Should_Throw_Exception_If_There_Already_Is_A_Weapon_With_That_Name()
            {
                var planet = new Planet("Earth", 10);
                var weapon = new Weapon("Gun", 10, 10);
                planet.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon), $"There is already a {weapon.Name} weapon.");
            }
            [Test]
            public void Test_Planet_AddWeapon_Should_Add_Weapon_To_Planet()
            {
                var planet = new Planet("Earth", 10);
                var weapon = new Weapon("Gun", 10, 10);
                var weaponList = new List<Weapon>();
                weaponList.Add(weapon);

                planet.AddWeapon(weapon);
                Assert.AreEqual(weaponList, planet.Weapons);
            }
            [Test]
            public void Test_Planet_RemoveWeapon_Should_Remove_Weapon_From_Planet()
            {
                var planet = new Planet("Earth", 10);
                var weapon = new Weapon("Gun", 10, 10);
                planet.AddWeapon(weapon);
                planet.RemoveWeapon("Gun");
                Assert.AreEqual(0, planet.Weapons.Count);
            }
            [Test]
            public void Test_Planet_UpgradeWeapon_Should_Throw_Exception_If_The_Given_Weapon_Name_Is_Not_In_The_WeaponRepository_Of_The_Planet()
            {
                var planet = new Planet("Earth", 10);
                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("Gun"), $"Gun does not exist in the weapon repository of {planet.Name}");
            }
            [Test]
            public void Test_Planet_UpgradeWeapon_Should_Increase_DestructionLevel_Of_Given_Weapon()
            {
                var planet = new Planet("Earth", 10);
                var weapon = new Weapon("Gun", 10, 9);

                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weapon.Name);
                Weapon planetWeapon = null;
                foreach (var currWeapon in planet.Weapons)
                {
                    planetWeapon = currWeapon;
                }

                Assert.AreEqual(weapon.DestructionLevel, planetWeapon.DestructionLevel);
            }
            [Test]
            public void Test_Planet_DestructOpponent_Should_Throw_Exception_When_The_Opponents_MilitaryPowerRatio_Is_Bigger_Or_Equal_To_The_Planet()
            {
                var firstPlanet = new Planet("Earth", 100);
                var secondPlanet = new Planet("Mars", 100);

                secondPlanet.AddWeapon(new Weapon("NuclearWeapon", 10, 15));

                Assert.Throws<InvalidOperationException>(() => firstPlanet.DestructOpponent(secondPlanet), $"{secondPlanet.Name} is too strong to declare war to!");
            }
            [Test]
            public void Test_Planet_Destruct_Opponent_Should_Return_Opponent_Name_Is_Destructed()
            {
                var firstPlanet = new Planet("Earth", 100);
                var secondPlanet = new Planet("Mars", 100);

                firstPlanet.AddWeapon(new Weapon("NuclearWeapon", 10, 15));

                Assert.AreEqual($"{secondPlanet.Name} is destructed!", firstPlanet.DestructOpponent(secondPlanet));
            }
        }
    }
}
