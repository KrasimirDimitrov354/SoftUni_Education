using System;

namespace BorderControl
{
    public class Citizen : Person, IOrganic, IBuyer
    {
        public Citizen(string name, int age, string id)
            : base(id)
        {
            Name = name;
            Age = age;
            Food = 0;
        }

        public Citizen(string name, int age, string id, string birthdate)
            : this(name, age, id)
        {
            Birthdate = birthdate;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Birthdate { get; private set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 10;
        }

        public void Celebrate(string year)
        {
            if (Birthdate.EndsWith(year))
            {
                Console.WriteLine(Birthdate);
            }
        }
    }
}
