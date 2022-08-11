using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Formula1.Utilities;

namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsePower;
        private double engineDisplacement;

        public FormulaOneCar(string model,int horsePower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsePower;
            this.EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get => this.model;
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1CarModel, value));
                }
                this.model = value;
            }
        }

        public int Horsepower
        {
            get => this.horsePower;
            protected set
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }
                this.horsePower = value;
            }
        }

        public double EngineDisplacement
        {
            get => this.engineDisplacement;
            protected set
            {
                if (value < 1.6 || value > 2)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }
                this.engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            return EngineDisplacement / Horsepower * laps;
        }
    }
}
