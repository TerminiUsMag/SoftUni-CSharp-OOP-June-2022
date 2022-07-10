using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> bagOfProducts;
        private Person()
        {
            bagOfProducts = new List<Product>();
        }
        public Person(string name, decimal money)
            : this()
        {
            this.Name = name;
            this.Money = money;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Name cannot be empty");
                this.name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");
                this.money = value;
            }
        }
        public IReadOnlyCollection<Product> BagOfProducts
        {
            get
            {
                return (IReadOnlyCollection<Product>)bagOfProducts;
            }
        }

        public void Buy(Product product)
        {
            if (product.Cost > this.Money)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
                return;
            }
            Console.WriteLine($"{this.Name} bought {product.Name}");
            this.Money -= product.Cost;
            bagOfProducts.Add(product);
        }

        public string PrintProductBag()
        {
            if (bagOfProducts.Count == 0)
            {
                return "Nothing bought";
            }
            return $"{string.Join(", ", this.bagOfProducts)}";
        }
    }
}
