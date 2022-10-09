using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    //Sets of Elements
    //Create a program that prints a set of elements.
    //
    //On the first line you will receive two numbers - n and m, which represent the lengths of two separate sets.
    //On the next n + m lines you will receive n numbers, which are the numbers in the first set, and m numbers, which are in the second set.
    //
    //Find all the unique elements that appear in both of them and print them in the order in which they appear in the first set - n.
    //
    //For example:
    //  Set with length n = 4: {1, 3, 5, 7}
    //  Set with length m = 3: {3, 4, 5}
    //  Set that contains all the elements that repeat in both sets -> {3, 5}
    //
    //Examples
    //Input     Output      Input   Output
    //4 3       3 5         2 2     1
    //1                     1
    //3                     3
    //5                     1
    //7                     5
    //3
    //4
    //5

    class Program
    {
        static void Main()
        {
            int[] sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s))
                .ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < sizes[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                firstSet.Add(num);
            }

            for (int i = 0; i < sizes[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                secondSet.Add(num);
            }

            foreach (int uniqueNum in firstSet)
            {
                if (secondSet.Contains(uniqueNum))
                {
                    Console.Write($"{uniqueNum} ");
                }
            }
        }
    }
}
