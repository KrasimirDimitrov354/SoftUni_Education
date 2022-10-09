using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    //Even Times
    //Create a program that prints a number which appears an even number of times.
    //
    //On the first line you will be given n – the count of integers you will receive.
    //On the next n lines you will be receiving the numbers.
    //
    //It is guaranteed that only one of them appears an even number of times. Your task is to find that number and print it. 
    //Examples
    //Input     Output  Input       Output
    //3         2       5           1
    //2                 1
    //-1                2
    //2                 3
    //                  1
    //                  5

    class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<int, int> occurencesOfNumbers = new Dictionary<int, int>();

            for (int i = 0; i < count; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());

                if (!occurencesOfNumbers.ContainsKey(currentNum))
                {
                    occurencesOfNumbers.Add(currentNum, 0);
                }

                occurencesOfNumbers[currentNum]++;
            }

            foreach (var occurence in occurencesOfNumbers)
            {
                if (occurence.Value % 2 == 0)
                {
                    Console.WriteLine(occurence.Key);
                }
            }
        }
    }
}
