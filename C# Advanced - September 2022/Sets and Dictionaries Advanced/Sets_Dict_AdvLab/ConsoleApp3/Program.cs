using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    //Largest 3 Numbers
    //Read a list of integers and print the largest 3 of them. If there are less than 3, print all of them.
    //
    //Examples
    //Input
    //  10 30 15 20 50 5
    //Output
    //  50 30 20
    //
    //Input
    //  20 30
    //Output
    //  30 20

    class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToList());

            numbers = numbers
                .OrderByDescending(n => n)
                .ToList();

            if (numbers.Count < 3)
            {
                Console.WriteLine(String.Join(' ', numbers));
            }
            else
            {
                Console.WriteLine($"{numbers[0]} {numbers[1]} {numbers[2]}");
            }
        }
    }
}
