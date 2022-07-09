using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero : IDamaging
    {
        private double health;
        private const double DefaultDamage = 25;
        private const double DefaultHealth = 100;

        public Hero(string username, int level, double health = DefaultHealth, double damage = DefaultDamage)
        {
            this.Username = username;
            this.Level = level;
            this.Health = health;
            this.Damage = damage;
        }
        public double Health
        {
            get { return this.health; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine($"{this.GetType().Name} DEAD!");
                    this.isDead = true;
                    this.health = 0;
                }
                else
                {
                    this.health = value;
                }
            }

        }
        public bool isDead { get; private set; }
        public string Username { get; set; }
        public int Level { get; set; }

        public double Damage { get; set; }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level} Health: {this.health} Damage: {this.Damage}";
        }

        public void Attack(Hero hero)
        {
            hero.Health -= this.Damage;
        }
    }
}
