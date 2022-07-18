using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                var input = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var name = input[0];
                var country = input[1];
                var age = int.Parse(input[2]);
                var citizen = new Citizen(name, country, age);
                IPerson person = citizen;
                IResident resident = citizen;
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
