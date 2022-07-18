using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : IBirthdayable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.BirthDate = birthdate;
        }
        public string Name { get; set; }
        public string BirthDate { get; set; }

        public string GetBirthYear()
        {
            string birthYear = "";
            for (int i = 6; i < this.BirthDate.Length; i++)
            {
                 birthYear += this.BirthDate[i];
            }
            return birthYear;
        }
    }
}
