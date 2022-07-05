using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.Demo
{
    class SoftwareEngineer : Employee
    {
        public SoftwareEngineer(string name, decimal salary) : base(name, salary)
        {
        }

        public Laptop Laptop { get; set; }
        public void Program()
        {
            Console.WriteLine("Doing nothing all day ;) ") ;
        }
    }
}
