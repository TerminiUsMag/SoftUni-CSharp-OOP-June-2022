using System;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mammals;
using WildFarm.Animals.Mammals.Feline;
using WildFarm.Food;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var cat = new Cat("Ivan", 10, "Bulgaria", "Coyote");
            var food = new Food.Meat(10);
            cat.Eat(food);
            Console.WriteLine();
            
        }
    }
}
