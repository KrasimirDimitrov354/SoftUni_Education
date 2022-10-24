using System;
using System.Text;

namespace Basketball
{
    public class Player
    {
        public Player(string name, string position, double rating, int games)
        {
            Name = name;
            Position = position;
            Rating = rating;
            Games = games;
            Retired = false;
        }

        public string Name { get; set; }
        public string Position { get; set; }
        public double Rating { get; set; }
        public int Games { get; set; }
        public bool Retired { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"-Player: {Name}");
            output.AppendLine($"--Position: {Position}");
            output.AppendLine($"--Rating: {Rating}");
            output.AppendLine($"--Games played: {Games}");

            return output.ToString().TrimEnd();
        }
    }
}
