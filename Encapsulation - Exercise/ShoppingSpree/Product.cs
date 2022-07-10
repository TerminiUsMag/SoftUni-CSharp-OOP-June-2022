using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private decimal cost;
        private string name;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        public decimal Cost
        {
            get
            {
                return cost;
            }
            set
            {
                //if (value < 0)
                //{
                    
                //}
                this.cost = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Name cannot be empty");
                name = value;
            }
        }
        public override string ToString()
        {
            return this.Name;
        }


    }
}
