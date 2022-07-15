using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;
        public double Radius
        {
            get { return this.radius; }
            private set
            {
                if (value > 0)
                    this.radius = value;
            }
        }
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public override double CalculateArea()
        {
            return (this.Radius * this.Radius) * Math.PI;
        }

        public override double CalculatePerimeter()
        {
            return (this.Radius * 2) * Math.PI;
        }
        public override string Draw()
        {
            return "Circle";
        }
    }
}
