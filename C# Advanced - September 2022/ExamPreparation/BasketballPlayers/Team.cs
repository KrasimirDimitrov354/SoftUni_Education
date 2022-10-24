using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            Players = new List<Player>();
            Name = name;
            OpenPositions = openPositions;
            Group = group;
        }

        public List<Player> Players { get; set; }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }

        public int Count { get { return Players.Count; } }
        
        public string AddPlayer(Player player)
        {
            if (String.IsNullOrEmpty(player.Name) || String.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            else if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            else if (player.Rating < 80.0)
            {
                return "Invalid player's rating.";
            }
            else
            {
                Players.Add(player);
                OpenPositions--;

                return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
            }
        }

        public bool RemovePlayer(string name)
        {
            if (Players.Exists(p => p.Name == name))
            {
                Players.RemoveAll(p => p.Name == name);
                OpenPositions++;
                return true;
            }

            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            if (Players.Exists(p => p.Position == position))
            {
                int removedPlayers = Players.RemoveAll(p => p.Position == position);
                OpenPositions += removedPlayers;
                return removedPlayers;
            }

            return 0;
        }

        public Player RetirePlayer(string name)
        {
            if (Players.Exists(p => p.Name == name))
            {
                int playerIndex = Players.FindIndex(p => p.Name == name);
                Players[playerIndex].Retired = true;

                return Players[playerIndex];
            }

            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            return Players.Where(p => p.Games >= games).ToList();
        }

        public string Report()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            var activePlayers = Players.Where(p => p.Retired == false).ToList();

            foreach (var player in activePlayers)
            {
                output.AppendLine(player.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
