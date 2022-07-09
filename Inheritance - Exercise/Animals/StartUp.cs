using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var beastList = new List<Animal>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "Beast!")
            {
                var secondInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var name = secondInput[0];
                var age = int.Parse(secondInput[1]);
                var gender = secondInput[2];
                Animal newAnimal;
                switch (cmd)
                {
                    case "Cat":
                        newAnimal = new Cat(name, age, gender);
                        break;
                    case "Dog":
                        newAnimal = new Dog(name, age, gender);
                        break;
                    case "Frog":
                        newAnimal = new Frog(name, age, gender);
                        break;
                    case "Kitten":
                        newAnimal = new Kitten(name, age);
                        break;
                    case "Tomcat":
                        newAnimal = new Tomcat(name, age);
                        break;
                    default:
                        newAnimal = null;
                        break;
                }
                if (newAnimal != null)
                    beastList.Add(newAnimal);
            }
            foreach (var beast in beastList)
            {
                Console.WriteLine(beast);
            }
        }
    }
}
