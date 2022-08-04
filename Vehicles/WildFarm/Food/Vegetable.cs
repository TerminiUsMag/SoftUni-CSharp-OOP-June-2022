﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Food
{
    public class Vegetable : Food
    {
        public Vegetable(int quantity = 1) : base(quantity)
        {
            Name = "Vegetable";
        }
    }
}
