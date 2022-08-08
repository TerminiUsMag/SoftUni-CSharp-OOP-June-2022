using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Food
{
    public class Fruit : Food
    {
        public Fruit(int quantity = 1)
            :base(quantity)
        {
            Name = "Fruit";
        }
    }
}
