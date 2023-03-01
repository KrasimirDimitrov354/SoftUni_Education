using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            try
            {
                Name = name;
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Age = age;
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Gender = gender;
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                age = value;
            }
        }

        public string Gender
        {
            get { return gender; }
            private set
            {
                if (value == "Male" || value == "Female")
                {
                    gender = value;
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }

        public bool IsValid()
        {
            if (Name != null && Age > 0 && Gender != null)
            {
                return true;
            }

            return false;
        }

        public virtual string ProduceSound()
        {
            return "Default noise";
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(GetType().Name);
            output.AppendLine($"{Name} {Age} {Gender}");
            output.AppendLine(ProduceSound());

            return output.ToString().TrimEnd();
        }
    }
}
