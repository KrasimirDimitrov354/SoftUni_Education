using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            People = new List<Person>();
        }

        private List<Person> People
        {
            get { return people; }
            set { people = value; }
        }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            return people.Where(person => person.Age == People.Max(p => p.Age))
                .FirstOrDefault();
        }

        public List<Person> SortFamily()
        {
            return people.
                Where(person => person.Age > 30)
                .OrderBy(p => p.Name)
                .ToList();
        }
    }
}
