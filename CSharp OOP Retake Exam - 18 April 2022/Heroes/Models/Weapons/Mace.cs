using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        private const int Damage = 25;
        public Mace(string name, int durability) : base(name, durability)// Damage)
        {
        }

        public override int DoDamage()
        {
            if (this.Durability - 1 <= 0)
            {
                this.Durability = 0;
                return 0;
            }
            this.Durability--;
            return Damage;
        }

        //public override int DoDamage()
        //{
        //    if (base.DoDamage() == 1)
        //    {
        //        return 25;
        //    }
        //    else
        //        return 0;
        //}
    }
}
