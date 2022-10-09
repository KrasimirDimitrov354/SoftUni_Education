using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp9
{
    //Party Reservation Filter Module
    //You need to implement a filtering module to a party reservation software.
    //
    //First, the Party Reservation Filter Module (PRFM for short) is passed a list with invitations.
    //Next, the PRFM receives a sequence of commands that specify whether you need to add or remove a given filter.
    //
    //Each PRFM command is in the given format:
    //  "{command;filter type;filter parameter}"
    //You can receive the following PRFM commands: 
    //  •	"Add filter"
    //  •	"Remove filter"
    //  •	"Print" 
    //The possible PRFM filter types are: 
    //  •	"Starts with"
    //  •	"Ends with"
    //  •	"Length"
    //  •	"Contains"
    //
    //All PRFM filter parameters will be a string (or an integer only for the "Length" filter)
    //Each command will be valid e.g. you won’t be asked to remove a non-existent filter.
    //
    //The input will end with a "Print" command, after which you should print all the party-goers that are left after the filtration.
    //
    //Examples
    //Input                         Output
    //Peter Misha Slav              Slav
    //Add filter; Starts with; P
    //Add filter;Starts with; M
    //Print
    //
    //Input                         Output
    //Peter Misha John              Misha John
    //Add filter; Starts with; P
    //Add filter;Starts with; M
    //Remove filter;Starts with; M
    //Print

    class Program
    {
        static void Main()
        {
            List<string> names = new List<string>(Console.ReadLine().Split());
            Dictionary<string, Predicate<string>> filterModule = new Dictionary<string, Predicate<string>>();

            string[] input = Console.ReadLine().Split(';');

            while (input[0] != "Print")
            {
                string command = input[0];
                string filterType = input[1];
                string filterParam = input[2];

                filterModule = ModifyModule(filterModule, command, filterType, filterParam);

                input = Console.ReadLine().Split(';');
            }

            foreach (var filter in filterModule)
            {
                names = names
                    .Where(n => !filter.Value(n))
                    .ToList();
            }

            Console.WriteLine(String.Join(' ', names));
        }

        private static Dictionary<string, Predicate<string>> ModifyModule(Dictionary<string, Predicate<string>> filterModule, string command, string filterType, string filterParam)
        {
            Predicate<string> currentFilter = CreateFilter(filterType, filterParam);          

            switch (command)
            {
                case "Add filter":
                    filterModule.Add(filterType + filterParam, currentFilter);
                    break;
                case "Remove filter":
                    filterModule.Remove(filterType + filterParam);
                    break;
            }

            return filterModule;
        }

        private static Predicate<string> CreateFilter(string filterType, string filterParam)
        {
            switch (filterType)
            {
                case "Starts with":
                    return name => name.StartsWith(filterParam);
                case "Ends with":
                    return name => name.EndsWith(filterParam);
                case "Length":
                    return name => name.Length == int.Parse(filterParam);
                case "Contains":
                    return name => name.Contains(filterParam);
                default:
                    throw new NotImplementedException();
            }  
        }
    }
}
