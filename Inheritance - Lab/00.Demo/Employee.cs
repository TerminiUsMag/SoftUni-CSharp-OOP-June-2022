using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00.Demo
{
    class Employee
    {
        public int Experience { get; set; }
        public int WorkHours { get; set; }
        public decimal Salary { get; set; }
        public string Name { get; set; }

        public Employee(string name,decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }
    }
}
