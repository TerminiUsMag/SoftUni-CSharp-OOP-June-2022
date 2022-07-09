using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Knight : Hero
    {
        private const int DefaultStamina = 100;
        private const double DefaultHealth = 125;
        private const double DefaultDamage = 25;
        public Knight(string username, int level, int stamina = DefaultStamina, double health = DefaultHealth, double damage = DefaultDamage) : base(username, level, health, damage)
        {
            this.Stamina = stamina;

        }
        public int Stamina { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} Stamina: {this.Stamina}";
        }
    }
}
