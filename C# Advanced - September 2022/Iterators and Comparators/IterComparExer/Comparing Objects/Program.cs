using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    //Comparing Objects
    //Create a class Person. Each person should have a name, age and town.
    //
    //You must implement the interface IComparable<T> and its CompareTo method.
    //When you compare two people, first you should compare their names, after that – their age and finally – their towns.
    //
    //You will be receiving input with information about the people until you receive the "END" command in the following format:
    //  "{name} {age} {town}"
    //
    //After that, you will receive n – the n'th person from your collection, starting from 1.
    //You should print statistics about how many people are equal to him, how many people are not equal to him, and the total people in your collection, in the following format:
    //  "{count of matches} {number of not equal people} {total number of people}"
    //If there are no equal people print: "No matches".
    //
    //Input
    //  •	You will be receiving lines in the format described above until the "END" command.
    //  •	After the "END" command, you will receive the position of the person you should compare the others to. 
    //      Note: Start counting the people in your collection from 1.
    //Output
    //  •	Print a single line of output in the format described above.
    //Constraints
    //  •	Input names, ages and addresses will be valid.
    //  •	Input number will always be а valid integer in the range [2 … 100].
    //
    //Examples
    //Input             Output
    //Peter 22 Varna    No matches
    //George 14 Sofia
    //END
    //2
    //
    //Input             Output
    //Peter 22 Varna    2 1 3
    //George 22 Varna
    //George 22 Varna
    //END
    //2

    class Program
    {
        static void Main()
        {
            List<Person> people = GetPeople();

            int index = int.Parse(Console.ReadLine()) - 1;
            Person personToCompare = people[index];
            int matchesEquals = 1;
            int matchesNotEquals = 0;

            for (int i = 0; i < people.Count; i++)
            {
                if (i != index)
                {
                    if (personToCompare.CompareTo(people[i]) == 1)
                    {
                        matchesEquals++;
                    }
                    else
                    {
                        matchesNotEquals++;
                    }
                }
            }

            if (matchesEquals == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matchesEquals} {matchesNotEquals} {people.Count}");
            }

        }

        private static List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            string[] personData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (personData[0] != "END")
            {
                string name = personData[0];
                int age = int.Parse(personData[1]);
                string town = personData[2];

                Person person = new Person(name, age, town);
                people.Add(person);

                personData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            return people;
        }
    }
}
