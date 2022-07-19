using System;

namespace SquareRoot
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                if (n < 0)
                    throw new ArgumentException("Invalid number.");
                Console.WriteLine(Math.Sqrt(n));

            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }

        }
    }
}
