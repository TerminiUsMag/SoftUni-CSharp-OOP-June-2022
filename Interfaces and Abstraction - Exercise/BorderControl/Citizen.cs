using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : Identifiable
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
        }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
