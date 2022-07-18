using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    public interface IResident
    {
        string GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
        public string Country { get; set; }
        public string Name { get; set; }
    }
}
