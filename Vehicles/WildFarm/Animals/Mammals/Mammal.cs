using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Animals;

namespace WildFarm.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        private string livingRegion;

        public string LivingRegion
        {
            get { return livingRegion; }
            set { livingRegion = value; }
        }

    }
}
