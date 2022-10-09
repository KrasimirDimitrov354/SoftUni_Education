using System;
using System.Linq;

namespace ConsoleApp5
{
    //Reverse and Exclude
    //Create a program that reverses a collection and removes elements that are divisible by a given integer n. Use predicates/functions.
    //
    //Examples
    //Input                 Output
    //1 2 3 4 5 6           5 3 1
    //2
    //
    //Input                 Output
    //20 10 40 30 60 50     50 40 10 20
    //3

    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(num => int.Parse(num))
                .Reverse()
                .ToArray();

            int divisible = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = num => num % divisible == 0;
            Func<int[], int[]> removeElements = nums => nums.Where(num => !isDivisible(num)).ToArray();

            Console.WriteLine(String.Join(' ', removeElements(numbers)));
        }
    }
}
