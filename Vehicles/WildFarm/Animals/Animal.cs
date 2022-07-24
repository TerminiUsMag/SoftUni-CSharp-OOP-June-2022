using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        public int FoodEaten
        {
            get { return foodEaten; }
            set { foodEaten = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
