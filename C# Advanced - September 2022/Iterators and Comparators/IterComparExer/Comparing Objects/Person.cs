using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
        public string Town { get { return town; } set { town = value; } }

        public int CompareTo(Person other)
        {
            int result = 0;

            if (Name == other.Name && Age == other.Age && Town == other.Town)
            {
                result = 1;
            }

            return result;
        }
    }
}
