using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public void Call(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                char currCh = number[i];
                if (!char.IsDigit(currCh))
                {
                    Console.WriteLine("Invalid number!");
                    return;
                }
            }
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
