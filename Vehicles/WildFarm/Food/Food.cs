﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Food
{
    public abstract class Food
    {
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

    }
}
