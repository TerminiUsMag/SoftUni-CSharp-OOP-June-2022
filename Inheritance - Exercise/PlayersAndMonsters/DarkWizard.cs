using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class DarkWizard : Wizard
    {
        private const double DefaultHealth = 150;
        private const double DefaultDamage = 25;
        private const int DefaultMana = 125;
        public DarkWizard(string username, int level, int mana = DefaultMana, double health = DefaultHealth, double damage = DefaultDamage) : base(username, level, mana, health, damage)
        {
        }
    }
}
