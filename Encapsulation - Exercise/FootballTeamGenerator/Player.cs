using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        //The stats a player has are endurance, sprint, dribble, passing, and shooting. 
        private string name;
        private int endurance, sprint, dribble, passing, shooting;
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
            //this.skillLevel = (this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("A name should not be empty.");
                this.name = value;
            }
        }
        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            set
            {
                ValidateStat(nameof(this.Endurance), value);
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            set
            {
                ValidateStat(nameof(this.Sprint), value);
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            set
            {
                ValidateStat(nameof(this.Dribble), value);
                this.dribble = value;
            }
        }
        public int Passing
        {
            get
            {
                return this.passing;
            }
            set
            {
                ValidateStat(nameof(this.Passing), value);
                this.passing = value;
            }
        }
        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            set
            {
                ValidateStat(nameof(this.Shooting), value);
                this.shooting = value;
            }
        }
        private void ValidateStat(string statName, int value)
        {
            if (value < 0 || value > 100)
                throw new ArgumentException($"{statName} should be between 0 and 100.");
        }
    }
}
