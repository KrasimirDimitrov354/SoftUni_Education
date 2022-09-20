using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.Destination_Mapper
{
    //Destination Mapper
    //Problem for exam preparation for the Programming Fundamentals Course @SoftUni.
    //Submit your solutions in the SoftUni judge system at https://judge.softuni.org/Contests/Practice/Index/2518#1.
    //
    //Now that you have planned out your tour, you are ready to go! Your next task is to mark all the points on the map that you are going to visit.
    //
    //You will be given a string representing some places on the map. You have to filter only the valid ones. A valid location is:
    //  •	Surrounded by "=" or "/" on both sides (the first and the last symbols must match)
    //  •	After the first "=" or "/" there should be only letters (the first must be upper-case, other letters could be upper or lower-case)
    //  •	The letters must be at least 3
    //
    //Example: In the string "=Hawai=/Cyprus/=Invalid/invalid==i5valid=/I5valid/=i=" only the first two locations are valid.
    //
    //After you have matched all the valid locations, you have to calculate travel points.
    //They are calculated by summing the lengths of all the valid destinations that you have found on the map.
    //
    //Print two lines of output. On the first line print: "Destinations: {destinations joined by ', '}". 
    //On the second line print: "Travel Points: {travel_points}".
    //
    //Input / Constraints
    //  •	You will receive a string representing the locations on the map
    //  •	JavaScript: you will receive a single parameter: string
    //Output
    //  •	Print the messages described above
    //Examples
    //Input
    //  =Hawai=/Cyprus/=Invalid/invalid==i5valid=/I5valid/=i=
    //Output
    //  Destinations: Hawai, Cyprus
    //  Travel Points: 11
    //Input
    //  ThisIs some InvalidInput
    //Output
    //  Destinations:
    //  Travel Points: 0

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string locationPattern = @"(?<splitter>=|\/)(?<location>[A-Z][a-zA-Z]{2,})\k<splitter>";

            MatchCollection locationMatches = Regex.Matches(input, locationPattern);

            int travelPoints = 0;
            List<string> locations = new List<string>();

            foreach (Match locationMatch in locationMatches)
            {
                locations.Add(locationMatch.Groups["location"].Value);
                travelPoints += locationMatch.Groups["location"].Value.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", locations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
