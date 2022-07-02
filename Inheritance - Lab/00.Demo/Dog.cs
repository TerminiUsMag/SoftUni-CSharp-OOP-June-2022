using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.Demo
{
    internal class Dog : Animal
    {
        public string Owner { get; set; }
        public string Bark()
        {
            return "Bark";
        }
    }
}
