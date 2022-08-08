using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammal.Feline
{
    public class Cat : Feline
    {
        private const double WeightGainPerPiece = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed)
            : this()
        {
            //•	Felines - "{Type} {Name} {Weight} {LivingRegion} {Breed}"
            this.Name = name;
            this.Weight = weight;
            this.LivingRegion = livingRegion;
            this.Breed = breed;
        }
        public Cat()
        {
            foodTypes.Add(new Food.Vegetable());
            foodTypes.Add(new Food.Meat());
        }
        public override void Eat(Food.Food foodtype)
        {
            base.EatFood(foodtype, WeightGainPerPiece);
        }
        public override string AskForFood()
        {
            return "Meow";
        }
    }
}
