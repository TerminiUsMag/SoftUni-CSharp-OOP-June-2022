using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            IMilitaryUnit unit = null;
            if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            foreach (var currUnit in planet.Army)
            {
                if (currUnit.GetType().Name == unitTypeName)
                {
                    throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
                }
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);
            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);

        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            foreach (var currWeapon in planet.Weapons)
            {
                if (currWeapon.GetType().Name == weaponTypeName)
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
                }
            }
            IWeapon weapon = null;
            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.FindByName(name) != null)
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }
            planets.AddItem(new Planet(name, budget));
            return String.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            var orderedPlanets = planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(pn => pn.Name).ToList();
            var sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().Trim();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var firstPlanet = planets.FindByName(planetOne);
            var secondPlanet = planets.FindByName(planetTwo);

            IPlanet winner = null;
            IPlanet loser = null;

            var firstPlanetPower = firstPlanet.MilitaryPower;
            var secondPlanetPower = secondPlanet.MilitaryPower;

            if (firstPlanetPower > secondPlanetPower)
            {
                winner = firstPlanet;
                loser = secondPlanet;
            }
            else if (firstPlanetPower < secondPlanetPower)
            {
                winner = secondPlanet;
                loser = secondPlanet;
            }
            else
            {
                var firstPlanetHasNuclear = false;
                var secondPlanetHasNuclear = false;

                foreach (var weapon in firstPlanet.Weapons)
                {
                    if (weapon.GetType().Name == "NuclearWeapon")
                    {
                        firstPlanetHasNuclear = true;
                    }
                }
                foreach (var weapon in secondPlanet.Weapons)
                {
                    if (weapon.GetType().Name == "NuclearWeapon")
                    {
                        secondPlanetHasNuclear = true;
                    }
                }
                if (firstPlanetHasNuclear && !secondPlanetHasNuclear)
                {
                    winner = firstPlanet;
                    loser = secondPlanet;
                }
                else if (!firstPlanetHasNuclear && secondPlanetHasNuclear)
                {
                    winner = secondPlanet;
                    loser = firstPlanet;
                }
                else
                {
                    winner = null;
                    loser = null;
                }
            }

            if (winner == null && loser == null)
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                secondPlanet.Spend(secondPlanet.Budget / 2);
                return OutputMessages.NoWinner;
            }
            else
            {
                winner.Spend(winner.Budget / 2);
                //loser.Spend(loser.Budget / 2);
                //winner.Profit(loser.Budget / 2);
                double winnings = loser.Budget / 2;
                foreach (var unit in loser.Army)
                {
                    winnings += unit.Cost;
                }
                foreach (var weapon in loser.Weapons)
                {
                    winnings += weapon.Price;
                }
                winner.Profit(winnings);
                planets.RemoveItem(loser.Name);
                return String.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
            }
        }

        public string SpecializeForces(string planetName)
        {
            var planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }
            foreach (var unit in planet.Army)
            {
                unit.IncreaseEndurance();
            }
            planet.Spend(1.25);
            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
