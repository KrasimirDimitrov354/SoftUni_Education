using System;

namespace ConsoleApp1
{
    class Program
    {
    //1.    Convert Meters to Kilometers
    //You will be given an integer that will be a distance in meters. Create a program that converts meters to kilometers formatted to the second decimal point.
    //Examples
    //Input Output
    //1852	1.85
    //798	0.80
        static void Main()
        {
            int meters = int.Parse(Console.ReadLine());

            float kilometers = meters / 1000.0f;

            Console.WriteLine($"{kilometers:f2}");
        }
    }
}
