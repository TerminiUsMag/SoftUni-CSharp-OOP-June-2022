//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Cards
//{
//    public class Card
//    {
//        private string face;
//        private string suit;
//        public Card(string face, string suit)
//        {
//            try
//            {
//                this.Face = face;
//                this.Suit = suit;
//            }
//            catch (ArgumentException ae)
//            {
//                throw new ArgumentException(ae.Message);
//            }
//        }
//        public string Face
//        {
//            get
//            {
//                return face;
//            }
//            set
//            {
//                if (value == "2" || value == "3" || value == "4" || value == "5" || value == "6" || value == "7" || value == "8" || value == "9" || value == "10" || value == "J" || value == "Q" || value == "K" || value == "A")
//                {
//                    face = value;
//                }
//                else
//                    throw new ArgumentException("Invalid card!");
//            }
//        }
//        public string Suit
//        {
//            get
//            {
//                return face;
//            }
//            set
//            {
//                if (value == "S")
//                    suit = "\u2660";
//                else if (value == "H")
//                    suit = "\u2665";
//                else if (value == "D")
//                    suit = "\u2666";
//                else if (value == "C")
//                    suit = "\u2663";
//                else
//                    throw new ArgumentException("Invalid card!");
//            }
//        }
//        public override string ToString()
//        {
//            return $"{this.Face}{this.Suit}";
//        }
//    }
//}
