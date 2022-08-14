using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private UnitRepository units;
        private WeaponRepository weapons;
        private string name;
        private double budget;
        public Planet(string name, double budget)
        {
            this.units = new UnitRepository();
            this.weapons = new WeaponRepository();
            this.Name = name;
            this.Budget = budget;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower
        {
            get
            {
                double result = 0;

                foreach (var unit in units.Models)
                {
                    result += unit.EnduranceLevel;
                }
                foreach (var weapon in weapons.Models)
                {
                    result += weapon.DestructionLevel;
                }
                if (units.FindByName("AnonymousImpactUnit") != null)
                {
                    result += result * 0.3;
                }
                if (weapons.FindByName("NuclearWeapon") != null)
                {
                    result += result * 0.45;
                }
                return Math.Round(result, 3);
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army
        {
            get => units.Models;
        }

        public IReadOnlyCollection<IWeapon> Weapons
        {
            get => weapons.Models;
        }

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            var sb = new StringBuilder();
            string forces = string.Empty;
            string combatEquipment = string.Empty;
            if (weapons.Models.Count == 0)
            {
                combatEquipment = "No weapons";
            }
            else
            {
                bool firstWeapon = true;
                foreach (var weapon in weapons.Models)
                {
                    if (firstWeapon)
                    {
                        combatEquipment = weapon.GetType().Name;
                    }
                    else
                    {
                        combatEquipment += $", {weapon.GetType().Name}";
                    }
                    firstWeapon = false;
                }
            }
            combatEquipment = combatEquipment.Trim();
            if (units.Models.Count == 0)
            {
                forces = "No units";
            }
            else
            {
                bool firstUnit = true;
                foreach (var unit in units.Models)
                {
                    //forces += $" {unit.GetType().Name},";
                    if (firstUnit)
                    {
                        forces = unit.GetType().Name;
                    }
                    else
                    {
                        forces += $", {unit.GetType().Name}";
                    }
                    firstUnit = false;
                }
            }
            forces = forces.Trim();

            sb.AppendLine($"Planet: {this.Name}");
            //sb.AppendLine();
            sb.AppendLine($"--Budget: {this.budget} billion QUID");
            sb.AppendLine($"--Forces: {forces}");
            //sb.AppendLine();
            sb.AppendLine($"--Combat equipment: {combatEquipment}");
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().Trim();
        }

        public void Profit(double amount)
        {
            budget += amount;
        }

        public void Spend(double amount)
        {
            if (amount > budget)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in units.Models)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
