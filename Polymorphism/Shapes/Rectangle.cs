using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;
        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value > 0)
                    this.height = value;
            }
        }
        public double Width
        {
            get { return this.width; }
            private set
            {
                if (value > 0)
                    this.width = value;
            }
        }
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }
        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return (this.Height + this.Width) * 2;
        }
        public override string Draw()
        {
            return "Rectangle";
        }
    }
}
