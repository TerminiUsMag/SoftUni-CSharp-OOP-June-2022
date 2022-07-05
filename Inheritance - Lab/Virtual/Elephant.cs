using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual
{
    public class Elephant : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("Elephant Eating");
            this.Food -= 50;
        }
    }
}
