using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery)
        {
            this.Color = color;
            this.Model = model;
            this.Battery = battery;
        }

        public int Battery { get; private set; }

        public string Model { get; private set; }

        public string Color { get; private set; }
        public override string ToString()
        {
            return $"{this.Color} Tesla {this.Model} with {this.Battery} Batteries";
        }
    }
}
