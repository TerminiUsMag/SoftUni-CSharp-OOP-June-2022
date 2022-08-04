using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double WeightGainPerPiece = 0.1;
        public Mouse(string name, double weight, string livingRegion)
            :this()
        {
            //•	Mice and Dogs - "{Type} {Name} {Weight} {LivingRegion}"
            this.Name = name;
            this.Weight = weight;
            this.LivingRegion = livingRegion;
        }
        public Mouse()
        {
            foodTypes.Add(new Food.Vegetable());
            foodTypes.Add(new Food.Fruit());
        }
        public override string AskForFood()
        {
            return "Squeak";
        }

        public override void Eat(Food.Food foodtype)
        {
            base.EatFood(foodtype, WeightGainPerPiece);
        }

        //public override sealed void Eat(Food.Food foodtype)
        //{
        //    //if (foodtype is Food.Vegetable || foodtype is Food.Fruit)
        //    for(int i = 0; i < foodTypes.Count; i++)
        //    {
        //        if(foodTypes[i].Name == foodtype.Name)
        //        {
        //            {
        //                this.FoodEaten += foodtype.Quantity;
        //                this.Weight += WeightGainPerPiece * foodtype.Quantity;
        //                return;
        //            }
        //        }
        //    }
        //    Console.WriteLine($"{this.GetType().Name} does not eat {foodtype.GetType().Name}!");
        //}
    }
}
