using System;

namespace BorderControl
{
    public class Person : I_Identifiable
    {
        public Person(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }

        public void Detain(string identifier)
        {
            if (Id.EndsWith(identifier))
            {
                Console.WriteLine(Id);
            }
        }
    }
}
