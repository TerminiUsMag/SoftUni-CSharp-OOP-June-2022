﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : Identifiable, IBirthdayable
    {
        public Citizen(string name, int age, string id,string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
            this.BirthDate = birthdate;
        }
        public int Age { get; set; }
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
