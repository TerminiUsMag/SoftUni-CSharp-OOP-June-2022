using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammal.Feline
{
    public abstract class Feline : Mammal
    {
        private string breed;

        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
