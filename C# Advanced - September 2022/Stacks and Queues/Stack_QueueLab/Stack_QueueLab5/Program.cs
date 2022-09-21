using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_QueueLab5
{
    //Print Even Numbers
    //Create a program that:
    //  •	Reads an array of integers and adds them to a queue.
    //  •	Prints the even numbers separated by ", ".
    //
    //Examples
    //Input                     Output
    //1 2 3 4 5 6	            2, 4, 6
    //11 13 18 95 2 112 81 46	18, 2, 112, 46

    class Program
    {
        static void Main()
        {
            Queue<int> even = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .ToList());

            Console.WriteLine(String.Join(", ", even));
        }
    }
}
