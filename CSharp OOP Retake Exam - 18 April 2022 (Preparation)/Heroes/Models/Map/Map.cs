using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Heroes.Models.Heroes;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            var knights = players.OfType<Knight>().Where(kn => kn.IsAlive).ToList();
            var barbarians = players.OfType<Barbarian>().Where(b => b.IsAlive).ToList();

            while (true)
            {
                var allKnightsAreDead = true;
                var allBarbariansAreDead = true;

                var knightsAlive = 0;
                var barbariansAlive = 0;

                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        allKnightsAreDead = false;
                        knightsAlive++;

                        var weaponDamage = knight.Weapon.DoDamage();

                        foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                        {
                            barbarian.TakeDamage(weaponDamage);
                        }
                    }
                }

                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        allBarbariansAreDead = false;
                        barbariansAlive++;

                        var weaponDamage = barbarian.Weapon.DoDamage();

                        foreach (var knight in knights.Where(kn => kn.IsAlive))
                        {
                            knight.TakeDamage(weaponDamage);
                        }
                    }
                }

                if (allBarbariansAreDead)
                {
                    var deadKnights = knights.Count - knightsAlive;
                    return $"The knights took {deadKnights} casualties but won the battle.";
                }

                if (allKnightsAreDead)
                {
                    var deadBarbarians = barbarians.Count - barbariansAlive;
                    return $"The barbarians took {deadBarbarians} casualties but won the battle.";
                }
            }
        }
    }
}
