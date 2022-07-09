using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class SoulMaster : DarkWizard
    {
        private const double DefaultHealth = 200;
        private const double DefaultDamage = 30;
        private const int DefaultMana = 200;
        public SoulMaster(string username, int level, int mana = DefaultMana, double health = DefaultHealth, double damage = DefaultHealth) : base(username, level, mana, health, damage)
        {
        }
    }
}
