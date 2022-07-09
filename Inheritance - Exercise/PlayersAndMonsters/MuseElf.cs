using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class MuseElf : Elf
    {
        private const double DefaultHealth = 150;
        private const double DefaultDamage = 30;
        public MuseElf(string username, int level, double health = DefaultHealth, double damage = DefaultDamage) : base(username, level, health, damage)
        {
        }
    }
}
