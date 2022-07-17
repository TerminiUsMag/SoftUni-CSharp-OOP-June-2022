using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var urls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            ICallable phone;
            for (int i = 0; i < numbers.Length; i++)
            {
                var currNumber = numbers[i];
                if (currNumber.Length == 7)
                    phone = new StationaryPhone();
                else
                    phone = new Smartphone();
                phone.Call(currNumber);
            }
            var smartPhone = new Smartphone();
            for (int x = 0; x < urls.Length; x++)
            {
                var currentURL = urls[x];
                smartPhone.Browse(currentURL);
            }
        }
    }
}
