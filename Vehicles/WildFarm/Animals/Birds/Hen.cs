using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double WeightGainPerPiece = 0.35;
        public Hen(string name, double weight, double wingSize)
            : this()
        {
            //•	Birds - "{Type} {Name} {Weight} {WingSize}"
            this.Name = name;
            this.Weight = weight;
            this.WingSize = wingSize;
        }
        public Hen()
        {
            foodTypes.Add(new Food.Fruit());
            foodTypes.Add(new Food.Meat());
            foodTypes.Add(new Food.Seeds());
            foodTypes.Add(new Food.Vegetable());
        }
        public override void Eat(Food.Food foodtype)
        {
            base.EatFood(foodtype, WeightGainPerPiece);
        }
        public override string AskForFood()
        {
            return "Cluck";
        }
    }
}
