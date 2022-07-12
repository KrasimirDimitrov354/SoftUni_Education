using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp7
{
    //Order by Age
    //You will receive an unknown number of lines. On each line you will receive an array with 3 elements:
    //  •	The first element is a string - the name of the person
    //  •	The second element a string - the ID of the person
    //  •	The third element is an integer - the age of the person
    //If you get a person whose ID you have already received before, update the name and age for that ID with that of the new person.
    //When you receive the command "End", print all the people ordered by age.
    //Examples
    //Input
    //  George 123456 20
    //  Peter 78911 15
    //  Stephen 524244 10
    //  End
    //Output
    //  Stephen with ID: 524244 is 10 years old.
    //  Peter with ID: 78911 is 15 years old.
    //  George with ID: 123456 is 20 years old.
    //
    //Input
    //  Lewis 123456 20
    //  James 78911 15
    //  Robert 523444 11
    //  Jennifer 345244 13
    //  Mary 52424678 22
    //  Patricia 567343 54
    //  End
    //Output
    //  Robert with ID: 523444 is 11 years old.
    //  Jennifer with ID: 345244 is 13 years old.
    //  James with ID: 78911 is 15 years old.
    //  Lewis with ID: 123456 is 20 years old.
    //  Mary with ID: 52424678 is 22 years old.
    //  Patricia with ID: 567343 is 54 years old.

    class Person
    {
        public Person(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"{this.Name} with ID: {this.ID} is {this.Age} years old.");
        }
    }

    class Program
    {
        private static bool PersonExists(List<Person> people, string id)
        {
            if (people.Count != 0)
            {
                for (int i = 0; i < people.Count; i++)
                {
                    string currentID = people[i].ID;

                    if (currentID == id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void UpdateInfo(List<Person> people, string[] info)
        {
            for (int i = 0; i < people.Count; i++)
            {
                string currentID = people[i].ID;

                if (currentID == info[1])
                {
                    people[i].Name = info[0];
                    people[i].Age = int.Parse(info[2]);
                    break;
                }
            }
        }

        static void Main()
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    people = people.OrderBy(p => p.Age).ToList();

                    foreach (Person person in people)
                    {
                        person.PrintInfo();
                    }
                    break;
                }
                else
                {
                    string[] info = input.Split(' ').ToArray();

                    if (PersonExists(people, info[1]))
                    {
                        UpdateInfo(people, info);
                    }
                    else
                    {
                        Person person = new Person(info[0], info[1], int.Parse(info[2]));
                        people.Add(person);
                    }
                }
            }
        }
    }
}
