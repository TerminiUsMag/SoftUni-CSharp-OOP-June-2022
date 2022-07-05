using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var newAnimal = new Animal();
            var newDog = new Dog();

            newAnimal.Eat();
            newDog.Bark();
            newDog.Eat();
            //newAnimal.Bark();
        }
    }
}
