using System;

namespace ConsoleApp4
{
    class Program
    {
        //4.    Centuries to Minutes
        //Create a program to enter an integer number of centuries and convert it to years, days, hours, and minutes.
        //Examples
        //Input   Output
        //1	      1 centuries = 100 years = 36524 days = 876576 hours = 52594560 minutes
        //5	      5 centuries = 500 years = 182621 days = 4382904 hours = 262974240 minutes
        //
        //•	Assume that a year has 365.2422 days on average (the Tropical year).

        static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine());
            int years = centuries * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            int minutes = hours * 60;
           
            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
