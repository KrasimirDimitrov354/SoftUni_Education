using System;

namespace BorderControl
{
    public class Pet : IOrganic
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }
        public string Birthdate { get; private set; }

        public void Celebrate(string year)
        {
            if (Birthdate.EndsWith(year))
            {
                Console.WriteLine(Birthdate);
            }
        }
    }
}
