using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.FindByName(heroName);
            IWeapon weapon = weapons.FindByName(weaponName);


            if (hero == null)
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            if (weapon == null)
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");

            string result = $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";

            if (hero.Weapon != null)
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);

            return result;
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero newHero = null;
            string result = string.Empty;

            if (type.ToLower() == "knight")
            {
                newHero = new Knight(name, health, armour);
                result = $"Successfully added Sir {name} to the collection.";
            }
            else if (type.ToLower() == "barbarian")
            {
                newHero = new Barbarian(name, health, armour);
                result = $"Successfully added Barbarian {name} to the collection.";
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }

            if (heroes.FindByName(name) != null)
                throw new InvalidOperationException($"The hero {name} already exists.");

            heroes.Add(newHero);
            return result;
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon newWeapon = null;
            string result = $"A {type.ToLower()} {name} is added to the collection.";

            if (type == "Mace")
            {
                newWeapon = new Mace(name, durability);
            }
            else if (type == "Claymore")
            {
                newWeapon = new Claymore(name, durability);
            }
            else
                throw new InvalidOperationException($"The weapon type.");

            if (weapons.FindByName(name) != null)
                throw new InvalidOperationException($"The weapon {name} already exists.");

            weapons.Add(newWeapon);
            return result;
        }

        public string HeroReport()
        {
            var heroList = heroes.Models
                .OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(h => h.Name)
                .ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var hero in heroList)
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                if (hero.Weapon == null)
                    sb.AppendLine($"--Weapon: Unarmed");
                else
                    sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
            }
            return sb.ToString().Trim();
        }

        public string StartBattle()
        {
            var map = new Map();
            var result = map.Fight(heroes.Models.Where(h=>h.Weapon!=null).ToList());

            return result;

        }
    }
}
