using System;


namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //var person = new Person("Nikolai", 20);
            //System.Console.WriteLine(person);

            //var child = new Child("Dani", 13);
            //System.Console.WriteLine(child);

            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Child child = new Child(name, age);
            Console.WriteLine(child);

        }
    }
}