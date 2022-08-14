using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;
        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.EnduranceLevel = 1;
        }
        public double Cost
        {
            get => cost;
            protected set => cost = value;
        }

        public int EnduranceLevel
        {
            get => enduranceLevel;
            private set
            {
                if (value > 20)
                {
                    enduranceLevel = 20;
                    throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
                }
                enduranceLevel = value;
            }
        }

        public void IncreaseEndurance()
        {
            //if (this.EnduranceLevel == 20)
            //{
            //    throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            //}
            //else
            this.EnduranceLevel++;
        }
    }
}
