using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    interface IDamaging
    {
        void Attack(Hero hero);

        double Damage { get; set; }

    }
}
