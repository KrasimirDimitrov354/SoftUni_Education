using System;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    //Match Phone Number
    //Create a regular expression to match a valid phone number from Sofia. After you find all valid phones, print them on the console separated by a comma and a space ", ".
    //A valid number has the following characteristics:
    //  •	It starts with "+359".
    //  •	This is followed by the area code (always 2).
    //  •	After that, it’s followed by the number itself:
    //      o The number consists of 7 digits (separated into two groups of 3 and 4 digits respectively). 
    //  •	The different parts are separated by either a space or a hyphen('-').
    //Examples
    //Input
    //  +359 2 222 2222,359-2-222-2222, +359/2/222/2222, +359-2 222 2222 +359 2-222-2222, +359-2-222-222, +359-2-222-22222 +359-2-222-2222
    //Output
    //  +359 2 222 2222, +359-2-222-2222
    //
    //Input
    //  +359 2 234 2324, 359-2-111-9876, +359/8/655/5432, +359-2 222 2222, +359 2-222-2222, +359-2-234-345, +359-2-123-45678, +359-2-222-2222, +359 2 654 1234
    //Output
    //  +359 2 234 2324, +359-2-222-2222, +359 2 654 1234

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"\+359(?<separator>-| )2(\k<separator>)\d{3}(\k<separator>)\d{4}\b";

            MatchCollection matches = Regex.Matches(input, pattern);

            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
