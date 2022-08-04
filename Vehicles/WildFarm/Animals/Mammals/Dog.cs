using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double WeightGainPerPiece = 0.4;
        public Dog(string name, double weight, string livingRegion)
            :this()
        {
            //•	Mice and Dogs - "{Type} {Name} {Weight} {LivingRegion}"
            this.Name = name;
            this.Weight = weight;
            this.LivingRegion = livingRegion;
        }
        public Dog()
        {
            foodTypes.Add(new Food.Meat());
        }
        public override void Eat(Food.Food foodtype)
        {
            base.EatFood(foodtype, WeightGainPerPiece);
        }
        public override string AskForFood()
        {
            return "Woof!";
        }

        
    }
}
