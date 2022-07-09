using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class DarkKnight : Knight
    {
        private const int DefaultStamina = 200;
        private const double DefaultHealth = 150;
        private const double DefaultDamage = 25;
        public DarkKnight(string username, int level, int stamina = DefaultStamina, double health = DefaultHealth, double damage = DefaultDamage) : base(username, level, stamina, health, damage)
        {
        }
    }
}
