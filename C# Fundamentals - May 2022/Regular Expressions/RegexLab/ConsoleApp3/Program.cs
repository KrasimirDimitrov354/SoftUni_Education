using System;
using System.Text.RegularExpressions;

namespace ConsoleApp3
{
    //Match Dates
    //Write a program which matches a date in the format "dd{separator}MMM{separator}yyyy". Use named capturing groups in your regular expression.
    //Every valid date has the following characteristics:
    //  •	Always starts with two digits, followed by a separator.
    //  •	After that, it has one uppercase and two lowercase letters (e.g. Jan, Mar).
    //  •	After that, it has a separator and exactly 4 digits (for the year).
    //  •	The separator could be either of three things: a period ("."), a hyphen ("-") or a forward-slash ("/").
    //  •	The separator needs to be the same for the whole date (e.g. 13.03.2016 is valid, 13.03/2016 is NOT). Use a group backreference to check for this.
    //Examples
    //Input
    //  13/Jul/1928, 10-Nov-1934, , 01/Jan-1951, f 25.Dec.1937 23/09/1973, 1/Feb/2016
    //Output
    //  Day: 13, Month: Jul, Year: 1928
    //  Day: 10, Month: Nov, Year: 1934
    //  Day: 25, Month: Dec, Year: 1937
    //
    //Input
    //  03-Mar-1878, 25/Apr/1915, 31-May-1916, 22/Jun-1941, 25.Dec.1937, 23/09/1973
    //Output
    //  Day: 03, Month: Mar, Year: 1878
    //  Day: 25, Month: Apr, Year: 1915
    //  Day: 31, Month: May, Year: 1916
    //  Day: 25, Month: Dec, Year: 1937

    class Program
    {
        static void Main()
        {
            string inputDates = Console.ReadLine();
            string datesPattern = @"(?<day>[0-9]{2})(?<separator>\.|-|/)(?<month>[A-Z][a-z]{2})(\k<separator>)(?<year>[0-9]{4})";

            MatchCollection matchedDates = Regex.Matches(inputDates, datesPattern);

            foreach (Match matchedDate in matchedDates)
            {
                Console.Write($"Day: {matchedDate.Groups["day"].Value}, ");
                Console.Write($"Month: {matchedDate.Groups["month"].Value}, ");
                Console.WriteLine($"Year: {matchedDate.Groups["year"].Value}");
            }
        }
    }
}
