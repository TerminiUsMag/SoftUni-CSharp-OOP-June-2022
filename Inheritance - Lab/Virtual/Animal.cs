using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual
{
    public class Animal
    {
        public int Food { get; set; }

        public Animal()
        {
            this.Food = 100;
        }

        public virtual void Eat()
        {
            Console.WriteLine("Animal Eating");
            this.Food -= 25;
        }
    }
}
