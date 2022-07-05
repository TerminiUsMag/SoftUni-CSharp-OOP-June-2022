using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual
{
    public class Mouse : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("Mouse Eating");
            this.Food -= 1;
        }
    }
}
