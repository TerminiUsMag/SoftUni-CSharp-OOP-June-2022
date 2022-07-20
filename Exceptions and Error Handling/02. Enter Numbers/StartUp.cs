using System;
using System.Collections.Generic;

namespace _02._Enter_Numbers
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var arr = ReadNumber(1, 100);
                Console.WriteLine(String.Join(", ", arr));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static int[] ReadNumber(int start, int end)
        {
            var arr = new List<int>();
            var minValue = start;
            var maxValue = end;
            while (arr.Count < 10)
            {
                int currNum = 0;
                try
                {
                    currNum = int.Parse(Console.ReadLine());
                }
                catch (FormatException fex)
                {
                    Console.WriteLine("Invalid Number!");
                    continue;
                }
                if (currNum > minValue && currNum < maxValue)
                {
                    arr.Add(currNum);
                    minValue = currNum;
                }
                else
                    Console.WriteLine($"Your number is not in range {minValue} - 100!");
            }
            return arr.ToArray();
        }
    }
}
