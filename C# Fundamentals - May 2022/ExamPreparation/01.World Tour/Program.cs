using System;
using System.Linq;
using System.Text;

namespace _01.World_Tour
{
    //World Tour
    //Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
    //Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2518#0.
    //
    //You are a world traveler and your next goal is to make a world tour. To do that you have to plan out everything first.
    //To start with, you would like to plan out all of your stops where you will have a break.
    //
    //On the first line you will be given a string containing all of your stops.
    //Until you receive the command "Travel", you will be given some commands to manipulate that initial string.
    //The commands can be:
    //  •	"Add Stop:{index}:{string}":
    //      o Insert the given string at that index only if the index is valid.
    //  •	"Remove Stop:{start_index}:{end_index}":
    //      o Remove the elements of the string from the starting index to the end index (inclusive) if both indices are valid.
    //  •	"Switch:{old_string}:{new_string}":
    //      o If the old string is in the initial string, replace it with the new one (all occurrences).
    //
    //Note: Print the current state of the string after each command!
    //
    //After the "Travel" command print the following: "Ready for world tour! Planned stops: {string}"
    //
    //Input / Constraints
    //  •	JavaScript: you will receive a list of strings.
    //  •	An index is valid if it is between the first and the last element index(inclusive) (0 ….. Nth) in the sequence.
    //Output
    //  •	Print the proper output messages in the proper cases as described in the problem description.
    //
    //Examples
    //Input                     Output
    //Hawai::Cyprys-Greece      Hawai::RomeCyprys-Greece
    //Add Stop:7:Rome           Hawai::Rome-Greece
    //Remove Stop:11:16         Bulgaria::Rome-Greece
    //Switch:Hawai:Bulgaria     Ready for world tour! Planned stops: Bulgaria::Rome-Greece
    //Travel

    class Program
    {
        private static bool IndexIsValid(StringBuilder worldStops, int index)
        {
            if (index >= 0 && index < worldStops.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void PrintStops(StringBuilder worldStops)
        {
            Console.WriteLine(worldStops);
        }

        private static void AddStop(StringBuilder worldStops, int index, string stop)
        {
            if (IndexIsValid(worldStops, index))
            {
                worldStops.Insert(index, stop);
            }

            PrintStops(worldStops);
        }

        private static void RemoveStop(StringBuilder worldStops, int startIndex, int endIndex)
        {
            if (IndexIsValid(worldStops, startIndex) && IndexIsValid(worldStops, endIndex))
            {
                if (endIndex > startIndex)
                {
                    worldStops.Remove(startIndex, (endIndex - startIndex) + 1);
                }
                else
                {
                    worldStops.Remove(endIndex, (startIndex - endIndex) + 1);
                }
            }

            PrintStops(worldStops);
        }

        private static void SwitchStops(StringBuilder worldStops, string oldStop, string newStop)
        {
            string convertedStops = worldStops.ToString();

            if (convertedStops.Contains(oldStop))
            {
                convertedStops = convertedStops.Replace(oldStop, newStop);
                worldStops.Clear();
                worldStops.Append(convertedStops);                
            }

            PrintStops(worldStops);
        }

        static void Main()
        {
            StringBuilder worldStops = new StringBuilder(Console.ReadLine());

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Travel")
                {
                    Console.Write("Ready for world tour! Planned stops: ");
                    PrintStops(worldStops);
                    break;
                }
                else
                {
                    switch (command[0])
                    {
                        case "Add Stop":
                            AddStop(worldStops, int.Parse(command[1]), command[2]);
                            break;
                        case "Remove Stop":
                            RemoveStop(worldStops, int.Parse(command[1]), int.Parse(command[2]));
                            break;
                        case "Switch":
                            SwitchStops(worldStops, command[1], command[2]);
                            break;
                    }
                }
            }
        }
    }
}
