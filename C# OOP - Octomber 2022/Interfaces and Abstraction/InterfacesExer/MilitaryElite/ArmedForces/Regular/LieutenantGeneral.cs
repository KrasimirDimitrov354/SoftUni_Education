using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Soldier
    {
        private List<Private> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            privates = new List<Private>();
        }

        public void AddSoldier(Private soldier)
        {
            privates.Add(soldier);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {FormatSalary()}");
            output.AppendLine("Privates:");

            foreach (Private soldier in privates)
            {
                 output.AppendLine($"  {soldier.ToString()}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
