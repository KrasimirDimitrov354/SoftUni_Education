using System;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    //Match Full Name
    //Write a program to match full names from a list of names and print them on the console.
    //A valid full name has the following characteristics:
    //  o It consists of two words.
    //  o Each word starts with a capital letter.
    //  o After the first letter, it only contains lowercase letters afterward.
    //  o Each of the two words should be at least two letters long.
    //  o The two words are separated by a single space.
    //Examples
    //Input
    //  Bethany Taylor, Oliver miller, sophia Johnson, SARah Wilson, John Smith, Sam         Smith
    //Output
    //  Bethany Taylor John Smith
    //
    //Input
    //  Elvis Presley a a C C-Muhammad Ali EE PeterpeterJR-a a xi ban D D bb b b-B B-c c EE-Michael Jackson DD peter smith B B PETER BROWN IVAN DAVIES-
    //Output
    //  Elvis Presley Muhammad Ali Michael Jackson

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.Write($"{match.Value} ");
            }
        }
    }
}
