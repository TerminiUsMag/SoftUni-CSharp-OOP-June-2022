using System;
using System.Collections.Generic;

namespace Cards
{
    public class StartUp
    {
       
        static void Main(string[] args)
        {
            var cards = new List<Card>();
            char[] separators = new char[] { ' ', ',' };
            var cardsInput = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < cardsInput.Length; i++)
            {
                try
                {
                    cards.Add(new Card(cardsInput[i], cardsInput[i+1]));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                i++;
            }
                Console.WriteLine(String.Join(' ',cards));

        }
    }
}
