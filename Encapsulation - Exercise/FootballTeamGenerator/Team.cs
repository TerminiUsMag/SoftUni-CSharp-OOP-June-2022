using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private int rating;
        private int numberOfPlayers;
        private List<Player> players;
        private Team()
        {
            players = new List<Player>();
            numberOfPlayers = players.Count;
            SetRating();
        }
        public Team(string name)
            : this()
        {
            this.Name = name;
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
        public int Rating
        {
            get
            {
                return this.rating;
            }
        }
        private void SetRating()
        {
            if (numberOfPlayers == 0)
            {
                this.rating = 0;
                return;
            }

            double sumOfAllStats = 0;
            for (int i = 0; i < this.players.Count; i++)
            {
                Player player = this.players[i];
                sumOfAllStats += player.Endurance + player.Sprint + player.Dribble + player.Passing + player.Shooting;
            }
            var result = (int)Math.Round(sumOfAllStats / (numberOfPlayers * 5));
            this.rating = result;
        }
        public void Add(Player player)
        {
            this.players.Add(player);
            numberOfPlayers++;
            SetRating();
        }
        public void Remove(string playerName)
        {
            bool removed = false;
            for (int i = 0; i < this.players.Count; i++)
            {
                if (this.players[i].Name == playerName)
                {
                    players.Remove(players[i]);
                    removed = true;
                }
            }
            if (!removed)
                Console.WriteLine($"Player {playerName} is not in {this.Name} team.");
            else
            {
                numberOfPlayers--;
                SetRating();
            }
        }
    }
}
