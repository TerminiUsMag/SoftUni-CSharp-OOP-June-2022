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

            }
        }

        public void Call()
        {
            throw new NotImplementedException();
        }
    }
}
