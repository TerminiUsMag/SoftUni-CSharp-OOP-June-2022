using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != null)
                    this.name = value;
                else
                    throw new Exception("Invalid input!");
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                    throw new Exception("Invalid input!");
                else
                    this.age = value;
            }
        }
        public Gender Gender { get; set; }


        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            if (gender == "Male")
                this.Gender = Gender.Male;
            else if (gender == "Female")
                this.Gender = Gender.Female;
            else
            {
                throw new Exception("Invalid input!");
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $@"{this.GetType().Name}
{this.Name} {this.Age} {this.Gender}
{this.ProduceSound()}";
        }
    }
}
