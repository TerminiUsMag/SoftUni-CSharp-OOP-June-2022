using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround
{
    public class Shape
    {
        private int ddz;
        public int Ddz
        {
            get
            {
                return ddz;
            }
            set
            {
                ddz = value;
            }
        }
        public Shape()
        {
            Ddz = 10;
        }

        public void CW()
        {
            Console.WriteLine("CW");
        }

    }
}
