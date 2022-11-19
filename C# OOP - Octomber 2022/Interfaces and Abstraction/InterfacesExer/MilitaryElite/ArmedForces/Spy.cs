using System;
using System.Text;

namespace MilitaryElite
{
    public class Spy : Soldier
    {
        private int codeNumber;

        public Spy(string id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            this.codeNumber = codeNumber;
        }

        public override string ToString()
        {
            return new StringBuilder()
                            .AppendLine($"Name: {FirstName} {LastName} Id: {Id}")
                            .AppendLine($"Code Number: {codeNumber}")
                            .ToString()
                            .TrimEnd();
        }
    }
}
