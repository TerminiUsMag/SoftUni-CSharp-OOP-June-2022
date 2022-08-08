using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Animals.Bird;
using WildFarm.Animals.Mammal;
using WildFarm.Animals.Mammal.Feline;
using WildFarm.Food;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            //Type type = GetType("WildFarm.Animals.Mammal.Dog");
            //object instance = Activator.CreateInstance(type);
            string cmd;
            var animals = new List<Animal>();
            while ((cmd = Console.ReadLine()) != "End")
            {
                Animal currentAnimal = CreateInstance(cmd);
                animals.Add(currentAnimal);

                Console.WriteLine(currentAnimal.AskForFood());

                var foodInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var foodType = foodInput[0];
                var foodQuantity = int.Parse(foodInput[1]);
                Food.Food foodToFeed = CreateFood(foodType, foodQuantity);

                currentAnimal.Eat(foodToFeed);
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food.Food CreateFood(string foodType, int foodQuantity)
        {
            Food.Food food = null;
            switch (foodType)
            {
                case "Fruit":
                    food = new Fruit(foodQuantity);
                    break;
                case "Meat":
                    food = new Meat(foodQuantity);
                    break;
                case "Seeds":
                    food = new Seeds(foodQuantity);
                    break;
                case "Vegetable":
                    food = new Vegetable(foodQuantity);
                    break;
            }
            return food;
        }

        private static Animal CreateInstance(string cmd)
        {
            var input = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var className = input[0];
            string type = "";
            var paramsList = new List<object>();
            paramsList.Add(input[1]);
            paramsList.Add(double.Parse(input[2]));

            if (className == "Owl" || className == "Hen")
            {
                type = "Bird";
                var wingSize = double.Parse(input[3]);
                paramsList.Add(wingSize);
            }
            else if (className == "Mouse" || className == "Dog")
            {
                type = "Mammal";
                var livingRegion = input[3];
                paramsList.Add(livingRegion);
            }
            else if (className == "Cat" || className == "Tiger")
            {
                type = "Mammal.Feline";
                var livingRegion = input[3];
                paramsList.Add(livingRegion);
                var breed = input[4];
                paramsList.Add(breed);
            }
            var paramsArray = paramsList.ToArray();
            return GetClassFromString(className, type, paramsArray);
        }

        public static dynamic GetClassFromString(string className, string typeOfAnimal, object[] paramsArray)
        {
            var classAddress = $"WildFarm.Animals.{typeOfAnimal}.{className}";
            Type type = GetType(classAddress);
            // Check whether the class is existed?
            if (type == null)
                return null;

            // Then create an instance
            object instance = Activator.CreateInstance(type, args: paramsArray);

            return (Animal)instance;
        }
        public static Type GetType(string strFullyQualifiedName)
        {
            Type type = Type.GetType(strFullyQualifiedName);
            if (type != null)
                return type;
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = asm.GetType(strFullyQualifiedName);
                if (type != null)
                    return type;
            }
            return null;
        }
    }
}
