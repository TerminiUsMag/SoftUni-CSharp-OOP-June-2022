using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private const double BoxPropMinValue = 0;
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value <= BoxPropMinValue)
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                }
                this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value <= BoxPropMinValue)
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value <= BoxPropMinValue)
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        double SurfaceArea()
            => (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        double LateralSurfaceArea()
            => (2 * Length * Height) + (2 * Width * Height);
        double Volume()
            => Length * Width * Height;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            return sb
                .AppendLine($"Surface Area - {this.SurfaceArea():f2}")
                .AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}")
                .AppendLine($"Volume - {this.Volume():f2}")
                .ToString();

        }
    }
}
