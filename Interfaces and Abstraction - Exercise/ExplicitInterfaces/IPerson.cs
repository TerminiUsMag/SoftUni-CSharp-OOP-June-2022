using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    public interface IPerson
    {
        string GetName()
        {
            return this.Name;
        }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
