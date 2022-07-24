using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals.Mammals.Feline
{
    public abstract class Feline : Mammal
    {
        private string breed;

        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }

    }
}
