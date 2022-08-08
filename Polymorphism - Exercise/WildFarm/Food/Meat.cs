using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Food
{
    public class Meat : Food
    {
        public Meat(int quantity=1)
            :base(quantity)
        {
            Name = "Meat";
        }
    }
}
