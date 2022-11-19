using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : Soldier
    {
        private List<RepairPart> repairParts;

        public Engineer(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            repairParts = new List<RepairPart>();
        }

        public void AddPart(RepairPart part)
        {
            repairParts.Add(part);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {FormatSalary()}");
            output.AppendLine($"Corps: {Corps}");
            output.AppendLine("Repairs:");

            foreach (var part in repairParts)
            {
                output.AppendLine($"  {part.ToString()}");
            }

            return output.ToString().TrimEnd();
        }
    }

    public class RepairPart
    {
        private string name;
        private int hoursWorked;

        public RepairPart(string name, int hoursWorked)
        {
            this.name = name;
            this.hoursWorked = hoursWorked;
        }

        public override string ToString()
        {
            return $"Part Name: {name} Hours Worked: {hoursWorked}";
        }
    }
}
