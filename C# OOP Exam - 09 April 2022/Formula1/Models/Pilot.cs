using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private int numberOfWins;
        private bool canRace;

        public Pilot(string fullName)
        {
            this.FullName = fullName;
            this.NumberOfWins = 0;
            this.CanRace = false;
            this.car = null;
        }
        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                this.fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get => this.car;
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
                this.car = value;
            }
        }

        public int NumberOfWins
        {
            get => numberOfWins;
            private set => numberOfWins = value;
        }

        public bool CanRace
        {
            get => canRace;
            private set => canRace = value;
        }

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.numberOfWins++;
        }
        public override string ToString()
        {
            return $"Pilot {this.fullName} has {this.numberOfWins} wins.";
        }
    }
}
