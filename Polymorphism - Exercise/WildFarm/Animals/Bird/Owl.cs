using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Bird
{
    public class Owl : Bird
    {
        private const double WeightGainPerPiece = 0.25;
        public Owl(string name, double weight, double wingSize)
            :this()
        {
            //•	Birds - "{Type} {Name} {Weight} {WingSize}"
            this.Name = name;
            this.Weight = weight;
            this.WingSize = wingSize;
        }
        public Owl()
        {
            foodTypes.Add(new Food.Meat());
        }
        public override void Eat(Food.Food foodtype)
        {
            base.EatFood(foodtype, WeightGainPerPiece);
        }
        public override string AskForFood()
        {
            return "Hoot Hoot";
        }
    }
}
