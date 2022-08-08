using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Food
{
    public abstract class Food
    {
        private int quantity;
        private string name;

        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }


    }
}
