using System;
using System.Linq;

namespace ConsoleApp2
{
    //Sum Numbers
    //Create a program that reads a line of integers separated by ", ". Print on two lines the count of numbers and their sum.
    //
    //Examples
    //Input
    //  4, 2, 1, 3, 5, 7, 1, 4, 2, 12
    //Output
    //  10
    //  41
    //Input
    //  2, 4, 6
    //Output
    //  3
    //  12

    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            Console.WriteLine($"{numbers.Count()}\n{numbers.Sum()}");
        }
    }
}
