using System;
using System.Linq;

namespace ConsoleApp1
{
    //Sort Even Numbers
    //Create a program that reads one line of integers separated by ", ", then prints the even numbers of that sequence sorted in increasing order.
    //
    //Examples
    //Input 
    //  4, 2, 1, 3, 5, 7, 1, 4, 2, 12
    //Output
    //  2, 2, 4, 4, 12
    //Input
    //  1, 3, 5
    //Output
    //
    //Input
    //  2, 4, 6
    //Output
    //  2, 4, 6

    class Program
    {
        static void Main()
        {
            Console.WriteLine(String.Join(", ", Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToArray()));
        }
    }
}
