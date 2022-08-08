using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Food
{
    public class Seeds : Food
    {
        public Seeds(int quantity = 1)
            :base(quantity)
        {
            Name = "Seeds";
        }
    }
}
