using System;

namespace MilitaryElite
{
    public class Private : Soldier
    {
        public Private(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {

        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} Salary: {FormatSalary()}";
        }
    }
}
