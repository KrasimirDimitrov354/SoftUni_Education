using System;

namespace ConsoleApp1
{
    class Program
    {
        //Day of Week
        //Enter a number in range 1-7 and print out the word representing it or "Invalid day!". Use an array of strings.
        //Examples
        //Input     Output
        //1	        Monday
        //2	        Wednesday
        //10	    Invalid day!

        static void Main()
        {

            int day = int.Parse(Console.ReadLine());
            string[] days = { "zero element", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            if (day < 1 || day > 7)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(days[day]);
            }
        }
    }
}
