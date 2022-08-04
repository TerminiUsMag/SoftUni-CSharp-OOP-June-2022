using INStock.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace INStock
{
    public class Product : IProduct
    {
        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }
        public Product()
        {
            Label = "Default" + new Random().Next(0, 100);
            Price = 1m;
            Quantity = 100;
        }

        public string Label { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int CompareTo([AllowNull] IProduct other)
        {
            if (this.Price > other.Price)
            {
                return 1;
            }
            else if (this.Price < other.Price)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public override string ToString()
        {
            return $"Label: {this.Label} Price: {this.Price} Quantity: {this.Quantity}";
        }
    }
}
