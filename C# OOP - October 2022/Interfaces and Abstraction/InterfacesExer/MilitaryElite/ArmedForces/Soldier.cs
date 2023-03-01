using System;

namespace MilitaryElite
{
    public abstract class Soldier
    {
        private string id;
        private string firstName;
        private string lastName;
        private decimal salary;
        private string corps;

        public Soldier(string id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Soldier(string id, string firstName, string lastName, decimal salary)
            : this(id, firstName, lastName)
        {
            this.salary = salary;
        }

        public Soldier(string id, string firstName, string lastName, decimal salary, string corps)
            : this(id, firstName, lastName, salary)
        {
            this.corps = corps;
        }

        internal string Id { get { return id; } }
        internal string FirstName { get { return firstName; } }
        internal string LastName { get { return lastName; } }
        internal string Corps { get { return corps; } }

        protected string FormatSalary()
        {
            return $"{salary:f2}";
        }
    }
}
