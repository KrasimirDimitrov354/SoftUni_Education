using System;

namespace DateModifier
{
    //Date Modifier
    //Create a class DateModifier which stores the difference of the days between two dates.
    //It should have a method that takes two string parameters representing a date as strings and calculates the difference in the days between them.  
    //Examples
    //Input         Output
    //1992 05 31    8783
    //2016 06 17
    //
    //Input         Output
    //2016 05 31    42
    //2016 04 19

    class DateModifier
    {
        static void Main()
        {
            DateTime firstDate = DateTime.Parse(Console.ReadLine());
            DateTime secondDate = DateTime.Parse(Console.ReadLine());

            TimeSpan difference = firstDate - secondDate;

            Console.WriteLine(Math.Abs(difference.Days));
        }
    }
}
