using System;

namespace Virtual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mouse = new Mouse();
            var elephant = new Elephant();

            Eat(mouse);
            Eat(elephant);
        }
        static void Eat(Animal animal)
        {
            animal.Eat();
            Console.WriteLine(animal.Food);
        }
    }
}
