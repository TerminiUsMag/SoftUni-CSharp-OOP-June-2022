using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            var products = new List<Product>();
            var separators = new char[] { '=', ';', ' ' };
            try
            {
                var input = Console.ReadLine().Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (input.Length % 2 != 0)
                    throw new ArgumentException("Name cannot be empty");
                for (int i = 0; i < input.Length; i++)
                {
                    string name = input[i];
                    decimal money = decimal.Parse(input[i + 1]);
                    people.Add(new Person(name, money));
                    i++;
                }
                input = Console.ReadLine().Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (input.Length % 2 != 0)
                    throw new ArgumentException("Name cannot be empty");
                for (int i = 0; i < input.Length; i++)
                {
                    string name = input[i];
                    decimal cost = decimal.Parse(input[i + 1]);
                    products.Add(new Product(name, cost));
                    i++;
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Environment.Exit(1);
            }
            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                var inputTokens = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = inputTokens[0];
                string productName = inputTokens[1];
                foreach (var person in people)
                {
                    if (person.Name == personName)
                    {
                        foreach (var product in products)
                        {
                            if (product.Name == productName)
                            {
                                person.Buy(product);
                            }
                        }
                    }
                }
            }
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} - {person.PrintProductBag()}");
            }
        }
    }
}
