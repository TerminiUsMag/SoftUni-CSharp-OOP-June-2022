using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> data;
        public IProduct this[int index]
        {
            get
            {
                ValidateIndex(index);
                return (IProduct)this[index];
            }
            set
            {
                ValidateIndex(index);
                this[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }
        public ProductStock()
        {
            this.data = new List<IProduct>();
        }

        public void ValidateIndex(int index)
        {
            if (index >= 0 && index < this.Count)
            {
                return;
            }
            throw new ArgumentOutOfRangeException("Index is out of range");
        }
        public void Add(IProduct product)
        {
            this.data.Add(product);
        }

        public bool Contains(IProduct product)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (product.Label == data[i].Label)
                {
                    return true;
                }
            }
            return false;
        }
        //public void FindSomething(Action action)
        //{
        //    for (int i = 0; i < this.Count; i++)
        //    {
        //        action();
        //    }
        //}

        public IProduct Find(int index)
        {
            ValidateIndex(index);
            return this.data[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            var result = new ProductStock();
            for (int i = 0; i < this.Count; i++)
            {
                if (data[i].Price == Convert.ToDecimal(price))
                {
                    result.Add(data[i]);
                }
            }
            return result;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            var result = new ProductStock();
            for (int i = 0; i < this.Count; i++)
            {
                if (data[i].Quantity == quantity)
                {
                    result.Add(data[i]);
                }
            }
            return result;
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            var allInRange = new ProductStock();
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Price >= Convert.ToDecimal(lo) && data[i].Price <= Convert.ToDecimal(hi))
                {
                    allInRange.Add(data[i]);
                }
            }
            return allInRange;
        }

        public IProduct FindByLabel(string label)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (label == data[i].Label)
                {
                    return data[i];
                }
            }
            throw new ArgumentException("No such product in stock");
        }

        public IProduct FindMostExpensiveProduct()
        {
            IProduct result = null;
            decimal maxPrice = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (maxPrice < data[i].Price)
                {
                    maxPrice = data[i].Price;
                    result = data[i];
                }
            }
            return result;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            for (int i = 0; i < data.Count; i++)
            {
                yield return data[i];
            }
        }

        public bool Remove(IProduct product)
        {
            return data.Remove(product);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
