using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IWebAccecable
    {
        public void Browse(string url)
        {
            for (int i = 0; i < url.Length; i++)
            {
                char currCh = url[i];
                if (char.IsDigit(currCh))
                {
                    Console.WriteLine("Invalid URL!");
                    return;
                }
            }
                Console.WriteLine($"Browsing: {url}!");
        }

        public void Call(string number)
        {
            for(int i =0; i < number.Length; i++)
            {
                char currCh = number[i];
                if (!char.IsDigit(currCh))
                {
                    Console.WriteLine("Invalid number!");
                    return;
                }
            }
            Console.WriteLine($"Calling... {number}");
        }
    }
}
