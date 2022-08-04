namespace INStock
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Product product;
            //ProductStock stock = new ProductStock();
            //for (int i = 0; i < 10; i++)
            //{
            //    product = new Product();
            //    stock.Add(product);
            //}
            //product = new Product("Asus", 100, 1);
            ////stock.Add(product);
            //Console.WriteLine(stock.Count);
            //foreach(var item in stock)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(stock.Contains(product));

            ProductStock stock = new ProductStock();
            var product = new Product("Asus", 1000, 1);
            stock.Add(new Product("Samsung", 10, 100));
            stock.Add(new Product("Apple", 100, 10));
            stock.Add(product);
            Console.WriteLine(stock.Count);
            Console.WriteLine(stock.Find(1));
            Console.WriteLine(stock.Remove(product));
            Console.WriteLine(stock.Count);
        }
    }
}
