using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals;

namespace WildFarm.Animals.Bird
{
    public abstract class Bird : Animal
    {
        private double wingSize;

        public double WingSize
        {
            get { return wingSize; }
            set { wingSize = value; }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }

    }
}
