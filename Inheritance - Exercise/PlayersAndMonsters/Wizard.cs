using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Wizard : Hero
    {
        private const double DefaultHealth = 125;
        private const double DefaultDamage = 25;
        private const int DefaultMana = 100;
        public Wizard(string username, int level, int mana = DefaultMana, double health = DefaultHealth, double damage = DefaultDamage) : base(username, level, health, damage)
        {
            this.Mana = mana;
        }
        public int Mana { get; set; }

        public void Cast(Hero hero)
        {
            Mana -= 5;
            hero.Health -= 25;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Mana: {this.Mana}";
        }
    }
}
