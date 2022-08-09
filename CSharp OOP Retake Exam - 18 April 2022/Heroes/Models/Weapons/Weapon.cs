using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;
        //protected int damage;
        protected Weapon(string name, int durability)//int damage)
        {
            this.Name = name;
            this.Durability = durability;
            //this.damage = damage;
        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Durability
        {
            get
            {
                return durability;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }
                durability = value;
            }
        }
        //public int DoDamage()
        //{
        //    this.Durability--;
        //    if (this.Durability == 0)
        //    {
        //        return 0;
        //    }
        //    return this.damage;
        //}
        public abstract int DoDamage();
        //public virtual int DoDamage()
        //{
        //    if (DamageWeapon())
        //    {
        //        return 1;
        //    }
        //    else
        //        return 0;
        //}
        //private bool DamageWeapon()
        //{
        //    this.Durability--;
        //    if (this.Durability == 0)
        //        return false;
        //    else
        //        return true;
        //}
    }
}
