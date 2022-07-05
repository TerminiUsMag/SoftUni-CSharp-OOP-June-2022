using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var newAnimal = new Animal();
            var newDog = new Dog();
            var newPuppy = new Puppy();

            newAnimal.Eat();
            newDog.Bark();
            newDog.Eat();
            //newAnimal.Bark();
            newPuppy.Weep();
            newPuppy.Eat();
        }
    }
}
