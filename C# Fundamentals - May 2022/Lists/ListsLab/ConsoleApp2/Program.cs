using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        //Gauss' Trick
        //Create a program that sums all numbers in a list in the following order:
        //first + last, first + 1 + last - 1, first + 2 + last - 2, … first + n, last - n.
        //Example
        //Input         Output
        //1 2 3 4 5	    6 6 3
        //1 2 3 4	    5 5


        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> newNumbers = new List<int>();

            bool hasMiddleNumber = false;

            if (numbers.Count % 2 != 0)
            {
                hasMiddleNumber = true;
            }

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                int currentNum = numbers[i];
                int lastNum = numbers[(numbers.Count - 1) - i];

                newNumbers.Add(currentNum + lastNum);
            }

            if (hasMiddleNumber)
            {
                newNumbers.Add(numbers[numbers.Count / 2]);
            }

            Console.WriteLine(string.Join(' ', newNumbers));
        }
    }
}
