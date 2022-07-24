using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var raidGroup = new List<BaseHero>();
            while (raidGroup.Count < n)
            {
                var heroName = Console.ReadLine();
                var heroType = Console.ReadLine();
                try
                {
                    raidGroup.Add(CreateHero(heroName, heroType));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
            var bossPower = int.Parse(Console.ReadLine());
            int raidPower = 0;
            foreach (var hero in raidGroup)
            {
                raidPower += hero.Power;
                Console.WriteLine(hero.CastAbility());
            }
            if (raidPower >= bossPower)
                Console.WriteLine("Victory!");
            else
                Console.WriteLine("Defeat...");
        }
        static BaseHero CreateHero(string name, string type)
        {
            BaseHero hero;
            switch (type)
            {
                case "Druid":
                    hero = new Druid(name);
                    break;
                case "Paladin":
                    hero = new Paladin(name);
                    break;
                case "Rogue":
                    hero = new Rogue(name);
                    break;
                case "Warrior":
                    hero = new Warrior(name);
                    break;
                default:
                    throw new ArgumentException("Invalid hero!");
            }
            return hero;
        }
    }
}
