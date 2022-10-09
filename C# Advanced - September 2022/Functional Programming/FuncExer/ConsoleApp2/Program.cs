using System;
using System.Linq;

namespace ConsoleApp2
{
    //Custom Min Function
    //Create a simple program that reads from the console a set of integers and prints back on the console the smallest number from the collection.
    //Use Func<T, T>.
    //
    //Examples
    //Input             Output
    //1 4 3 2 1 7 13	1
    //4 5 -2 3 -5 8	    -5

    class Program
    {
        static void Main()
        {
            Func<int[], int> findSmallest = nums => nums.Min();

            Console.WriteLine(findSmallest(Console.ReadLine()
                .Split()
                .Select(num => int.Parse(num))
                .ToArray()));
        }
    }
}
