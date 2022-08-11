using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;
        private ICollection<IPilot> pilots;
        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            this.pilots = new List<IPilot>();
            this.tookPlace = false;
        }
        public string RaceName
        {
            get => raceName;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => numberOfLaps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                this.numberOfLaps = value;
            }
        }

        public bool TookPlace
        {
            get => tookPlace;
            set => this.tookPlace = value;
        }

        public ICollection<IPilot> Pilots
        {
            get => this.pilots;
            //private set => this.pilots = value;
        }

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            var raceTookPlace = this.TookPlace ? "Yes" : "No";
            var sb = new StringBuilder();
            sb.AppendLine($"The {raceName} race has:");
            sb.AppendLine($"Participants: {pilots.Count}");
            sb.AppendLine($"Number of laps: {numberOfLaps}");
            sb.AppendLine($"Took place:{(this.TookPlace ? "Yes" : "No")}");
            //sb.AppendLine("Took place: " + (this.TookPlace ? "Yes" : "No"));

            return sb.ToString().Trim();


            //return @$"The {raceName} race has:
            //Participants: {pilots.Count}
            //Number of laps: {numberOfLaps}
            //Took place: {raceTookPlace}";

            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"The {}")

        }
    }
}
