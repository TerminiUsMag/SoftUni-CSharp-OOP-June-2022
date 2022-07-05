using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.Demo
{
    internal class Intern : SoftwareEngineer
    {
        public Intern(string name, decimal salary) : base(name, salary)
        {
        }

        public void GetHelp()
        {
            Console.WriteLine("Dai go na drug");
        }
    }
}
