using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    //Count Real Numbers
    //Read a list of integers and print them in ascending order, along with their number of occurrences.
    //Examples
    //Input         Output
    //8 2 2 8 2	    2 -> 3
    //              8 -> 2
    //
    //Input         Output
    //1 5 1 3	    1 -> 2
    //              3 -> 1
    //              5 -> 1
    //
    //Input         Output
    //-2 0 0 2		-2 -> 1
    //              0 -> 2
    //              2 -> 1

    class Program
    {
        static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();

            SortedDictionary<double, int> occurencesOfNumbers = new SortedDictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                double currentNum = numbers[i];

                if (occurencesOfNumbers.ContainsKey(currentNum))
                {
                    occurencesOfNumbers[currentNum]++;
                }
                else
                {
                    occurencesOfNumbers.Add(currentNum, 1);
                }
            }

            foreach (var occurence in occurencesOfNumbers)
            {
                Console.WriteLine($"{occurence.Key} -> {occurence.Value}");
            }
        }
    }
}
