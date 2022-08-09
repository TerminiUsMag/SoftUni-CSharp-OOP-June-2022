using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        private const int Damage = 20;
        public Claymore(string name, int durability) : base(name, durability, Damage)
        {
        }
        //public override int DoDamage()
        //{
        //    if (base.DoDamage() == 1)
        //    {
        //        return 20;
        //    }
        //    else
        //        return 0;
        //}
    }
}
