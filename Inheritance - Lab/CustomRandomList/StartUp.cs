using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var customList = new RandomList();
            customList.Add("Nikolai");
            customList.Add("Ivan");
            customList.Add("Krasi");
            customList.Add("Aleks");
            customList.Add("Genadi");
            customList.Add("Dani");

            Console.WriteLine(customList.RandomString());

        }
    }
}
