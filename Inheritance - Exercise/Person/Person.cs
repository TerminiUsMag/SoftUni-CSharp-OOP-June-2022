﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private int age;
        private string name;
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }

        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value >= 0)
                    this.age = value;
                else
                {
                    this.age = 0;
                }
            }
        }
        public override string ToString()
        {
            return $"Name: {this.name}, Age: {this.age}";
        }
    }
}