using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : Soldier
    {
        private List<Mission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            missions = new List<Mission>();
        }

        public void AddMission(Mission mission)
        {
            missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {FormatSalary()}");
            output.AppendLine($"Corps: {Corps}");
            output.AppendLine("Missions:");

            foreach (var mission in missions)
            {
                output.AppendLine($"  {mission.ToString()}");
            }

            return output.ToString().TrimEnd();
        }
    }

    public class Mission
    {
        private string name;
        internal string state;

        public Mission(string name, string state)
        {
            this.name = name;
            this.state = state;
        }

        public override string ToString()
        {
            return $"Code Name: {name} State: {state}";
        }
    }
}
