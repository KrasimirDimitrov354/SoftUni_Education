using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    //Count Same Values in Array
    //Create a program that counts the number of occurrences of each value in a given array of double values.
    //
    //Examples
    //Input
    //  -2.5 4 3 -2.5 -5.5 4 3 3 -2.5 3
    //Output
    //  -2.5 - 3 times
    //  4 - 2 times
    //  3 - 4 times
    //  -5.5 - 1 times
    //Input
    //  2 4 4 5 5 2 3 3 4 4 3 3 4 3 5 3 2 5 4 3
    //Output
    //  2 - 3 times
    //  4 - 6 times
    //  5 - 4 times
    //  3 - 7 times

    class Program
    {
        static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => double.Parse(n))
                .ToArray();

            Dictionary<double, int> occurencesOfNumbers = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                double currentNum = numbers[i];

                if (!occurencesOfNumbers.ContainsKey(currentNum))
                {
                    occurencesOfNumbers.Add(currentNum, 0);
                }

                occurencesOfNumbers[currentNum]++;
            }

            foreach (var occurence in occurencesOfNumbers)
            {
                Console.WriteLine($"{occurence.Key} - {occurence.Value} times");
            }
        }
    }
}
