using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            const string InvalidTeam = "Team {0} does not exist.";
            var teams = new List<Team>();
            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                var input = cmd.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                var teamName = input[1];
                var playerName = string.Empty;
                bool teamExists = false;
                int teamIndex = -1;
                for (int x = 0; x < teams.Count; x++)
                {
                    if (teams[x].Name == teamName)
                    {
                        teamExists = true;
                        teamIndex = x;
                    }
                }
                switch (command)
                {
                    case "Team":
                        try
                        {
                            teams.Add(new Team(teamName));
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                        break;

                    case "Add":
                        if (teamExists)
                        {
                            playerName = input[2];
                            var endurance = int.Parse(input[3]);
                            var sprint = int.Parse(input[4]);
                            var dribble = int.Parse(input[5]);
                            var passing = int.Parse(input[6]);
                            var shooting = int.Parse(input[7]);
                            try
                            {
                                teams[teamIndex].Add(new Player(playerName, endurance, sprint, dribble, passing, shooting));
                            }
                            catch (ArgumentException ae)
                            {
                                Console.WriteLine(ae.Message);
                            }
                        }
                        else
                            Console.WriteLine(string.Format(InvalidTeam, teamName));
                        break;
                    case "Remove":
                        if (teamExists)
                        {
                            playerName = input[2];
                            teams[teamIndex].Remove(playerName);
                        }
                        else
                        {
                            Console.WriteLine(string.Format(InvalidTeam, teamName));
                        }
                        break;
                    case "Rating":
                        if (teamExists)
                        {
                            Console.WriteLine($"{teamName} - {teams[teamIndex].Rating}");
                        }
                        else
                        {
                            Console.WriteLine(string.Format(InvalidTeam, teamName));
                        }
                        break;
                    default:
                        break;
                }



            }
        }
    }
}
