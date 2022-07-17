using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public abstract class Identifiable
    {
        public string ID { get; set; }

        string GetId()
        {
            return this.ID;
        }
    }
}
