using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : Identifiable
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.ID = id;
        }
        public string Model { get; set; }
    }
}
