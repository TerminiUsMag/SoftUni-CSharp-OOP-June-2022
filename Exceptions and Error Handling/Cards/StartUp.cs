using System;
using System.Collections.Generic;

namespace Cards
{
    public class StartUp
    {
        public class Card
        {
            private string face;
            private string suit;
            public Card(string face, string suit)
            {
                try
                {
                    this.Face = face;
                    this.Suit = suit;
                }
                catch (ArgumentException ae)
                {
                    throw new ArgumentException(ae.Message);
                }
            }
            public string Face
            {
                get
                {
                    return face;
                }
                set
                {
                    if (value == "2" || value == "3" || value == "4" || value == "5" || value == "6" || value == "7" || value == "8" || value == "9" || value == "10" || value == "J" || value == "Q" || value == "K" || value == "A")
                    {
                        face = value;
                    }
                    else
                        throw new ArgumentException("Invalid card!");
                }
            }
            public string Suit
            {
                get
                {
                    return suit;
                }
                set
                {
                    if (value == "S")
                        suit = "\u2660";
                    else if (value == "H")
                        suit = "\u2665";
                    else if (value == "D")
                        suit = "\u2666";
                    else if (value == "C")
                        suit = "\u2663";
                    else
                        throw new ArgumentException("Invalid card!");
                }
            }
            public override string ToString()
            {
                return $"[{this.Face}{this.Suit}]";
            }
        }
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
