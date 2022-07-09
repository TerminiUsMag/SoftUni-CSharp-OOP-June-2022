using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Elf : Hero
    {
        private const double DefaultHealth = 150;
        private const double DefaultDamage = 25;
        public Elf(string username, int level, double health = DefaultHealth, double damage = DefaultDamage) : base(username, level, health, damage)
        {
        }

        public void Shoot(Hero hero)
        {
            hero.Health -= this.Damage;
        }
    }
}
