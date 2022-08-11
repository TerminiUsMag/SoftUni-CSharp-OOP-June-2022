using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilots;
        private RaceRepository races;
        private FormulaOneCarRepository cars;
        public Controller()
        {
            pilots = new PilotRepository();
            races = new RaceRepository();
            cars = new FormulaOneCarRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = pilots.FindByName(pilotName);
            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            if (cars.FindByName(carModel) == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            pilots.FindByName(pilotName).AddCar(cars.FindByName(carModel));
            var car = cars.FindByName(carModel);
            cars.Remove(car);
            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, car.Model);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = races.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            var pilot = pilots.FindByName(pilotFullName);
            if (pilot == null || !pilot.CanRace || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            FormulaOneCar car = type switch
            {
                "Ferrari" => new Ferrari(model, horsepower, engineDisplacement),
                "Williams" => new Williams(model, horsepower, engineDisplacement),
                _ => throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type))
            };

            if (cars.FindByName(model) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            cars.Add(car);
            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            if (pilots.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            pilots.Add(new Pilot(fullName));
            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (races.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            races.Add(new Race(raceName, numberOfLaps));
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            var listOfPilots = pilots.Models.OrderByDescending(p => p.NumberOfWins).ToList();
            var sb = new StringBuilder();
            foreach (var pilot in listOfPilots)
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            var sb = new StringBuilder();
            foreach (var race in races.Models)
            {
                if (race.TookPlace)
                {
                    sb.AppendLine(race.RaceInfo());
                    sb.AppendLine();
                }
            }
            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            var race = races.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            var pilotsInRace = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();
            Pilot firstPlace = (Pilot)pilotsInRace[0];
            Pilot secondPlace = (Pilot)pilotsInRace[1];
            Pilot thirdPlace = (Pilot)pilotsInRace[2];
            firstPlace.WinRace();
            race.TookPlace = true;

            var sb = new StringBuilder();
            sb.AppendLine(String.Format(OutputMessages.PilotFirstPlace, firstPlace.FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotSecondPlace, secondPlace.FullName, raceName));
            sb.AppendLine(string.Format(OutputMessages.PilotThirdPlace, thirdPlace.FullName, raceName));

            return sb.ToString().Trim();
        }
    }
}
