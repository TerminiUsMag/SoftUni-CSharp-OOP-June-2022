using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;
        public Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Health
        {
            get
            {
                return health;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                health = value;
            }
        }
        public int Armour
        {
            get
            {
                return armour;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                armour = value;
            }
        }
        public IWeapon Weapon
        {
            get
            {
                return weapon;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentException("Weapon cannot be null.");
                weapon = value;
            }
        }
        public bool IsAlive => health > 0;

        public void AddWeapon(IWeapon weapon) => this.Weapon = weapon;

        public void TakeDamage(int points)
        {
            if (points > this.Armour)
            {
                points -= this.Armour;
                this.armour = 0;
                this.health -= points;
                if (this.health <= 0)
                    this.health = 0;
            }
            else if (points <= this.Armour)
            {
                this.armour -= points;
            }
        }
    }
}
