using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals;

namespace WildFarm.Animals.Birds
{
    public abstract class Bird : Animal
    {
        private double windSize;

        public double WingSize
        {
            get { return windSize; }
            set { windSize = value; }
        }

    }
}
