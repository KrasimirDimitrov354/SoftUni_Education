using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp8
{
    //Predicate Party!
    //On the first line you receive a list of all the people that are coming to the party.
    //Until you get the "Party!" command, on the next lines you may be asked to double or remove all the people that apply to the given criteria.
    //
    //There are three different criteria: 
    //  •	Everyone that has his name starting with a given string.
    //  •	Everyone that has a name ending with a given string.
    //  •	Everyone that has a name with a given length.
    //
    //Finally, print all the guests who are going to the party separated by ", " and then add the ending "are going to the party!".
    //If no guests are going to the party print "Nobody is going to the party!".
    //
    //Examples
    //Input                     Output
    //Peter Misha Stephen       Misha, Misha, Stephen are going to the party!
    //Remove StartsWith P
    //Double Length 5
    //Party!
    //
    //Input                     Output
    //Peter                     Peter, Peter, Peter, Peter are going to the party!
    //Double StartsWith Pete
    //Double EndsWith eter
    //Party!
    //
    //Input                     Output
    //Peter                     Nobody is going to the party!
    //Remove StartsWith P
    //Party!

    class Program
    {
        static void Main()
        {
            List<string> people = new List<string>( Console.ReadLine().Split() );

            string[] command = Console.ReadLine().Split();

            while (command[0] != "Party!")
            {
                string action = command[0];
                string criteria = command[1];
                string value = command[2];

                people = Modify(people, action, criteria, value);

                command = Console.ReadLine().Split();
            }

            PartyTime(people);
        }
        private static void PartyTime(List<string> people)
        {
            if (people.Count > 0)
            {
                Console.WriteLine($"{String.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static List<string> Modify(List<string> people, string action, string criteria, string value)
        {
            Predicate<string> condition = CreateCondition(criteria, value);
            Func<List<string>, List<string>> modification = CreateModification(action, condition);

            List<string> peopleToModify = modification(people);

            foreach (string person in peopleToModify)
            {
                switch (action)
                {
                    case "Remove":
                        people.Remove(person);
                        break;
                    case "Double":
                        people.Insert(people.IndexOf(person), person);
                        break;
                }
            }

            return people;
        }

        private static Predicate<string> CreateCondition(string criteria, string value)
        {
            switch (criteria)
            {
                case "StartsWith":
                    return name => name.StartsWith(value);
                case "EndsWith":
                    return name => name.EndsWith(value);
                case "Length":
                    return name => name.Length == int.Parse(value);
                default:
                    throw new NotImplementedException();
            }        
        }

        private static Func<List<string>, List<string>> CreateModification(string action, Predicate<string> condition)
        {
            switch (action)
            {
                case "Remove":
                    return namesToModify => namesToModify.Where(n => condition(n)).ToList();
                case "Double":
                    return namesToModify => namesToModify.FindAll(condition);
                default:
                    throw new NotImplementedException();
            } 
        }
    }
}
