using System;

namespace BorderControl
{
    public class Rebel : I_Identifiable, IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Id = group;
            Food = 0;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Food { get; private set; }
        public string Id { get; private set; }

        public void BuyFood()
        {
            Food += 5;
        }

        public void Detain(string identifier)
        {
            Console.WriteLine("Cannot detain me!");
        }
    }
}
