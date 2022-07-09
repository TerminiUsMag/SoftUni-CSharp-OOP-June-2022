using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class BladeKnight : DarkKnight
    {
        private const int DefaultStamina = 500;
        private const double DefaultHealth = 200;
        private const double DefaultDamage = 30;
        public BladeKnight(string username, int level, int stamina = DefaultStamina, double health = DefaultHealth, double damage = DefaultDamage) : base(username, level, stamina, health, damage)
        {
        }
        public void UltimateAbility()
        {
            if (this.Stamina < 500)
            {
                Console.WriteLine("Not enough stamina!");
                return;
            }
            Console.WriteLine("Casting Ultimate Attack!");
        }

    }
}
