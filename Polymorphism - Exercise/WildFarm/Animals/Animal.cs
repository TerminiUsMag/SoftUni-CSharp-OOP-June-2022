using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
    public abstract class Animal
    {
        private const double WeightGainPerPiece = 0;
        private string name;
        private double weight;
        private int foodEaten;
        protected List<Food.Food> foodTypes ;
        public Animal()
        {
            foodTypes = new List<Food.Food>();
        }
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

        protected void EatFood(Food.Food foodtype, double weightGain)
        {
            //if (foodtype is Food.Vegetable || foodtype is Food.Fruit)
            for (int i = 0; i < foodTypes.Count; i++)
            {
                if (foodTypes[i].Name == foodtype.Name)
                {
                    {
                        this.FoodEaten += foodtype.Quantity;
                        this.Weight += weightGain * foodtype.Quantity;
                        return;
                    }
                }
            }
            Console.WriteLine($"{this.GetType().Name} does not eat {foodtype.GetType().Name}!");
        }
        public abstract void Eat(Food.Food foodtype);

        public abstract string AskForFood();

    }
}
