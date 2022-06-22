using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp5
{
    class Program
    {
        //Remove Negatives and Reverse
        //Read a list of integers, remove all negative numbers from it and print the remaining elements in reversed order.
        //If there are no elements left in the list, print "empty".
        //Examples
        //Input                 Output
        //10 -5 7 9 -33 50	    50 9 7 10
        //7 -2 -10 1	        1 7
        //-1 -2 -3	            empty

        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNum = numbers[i];

                if (currentNum < 0)
                {
                    numbers.Remove(currentNum);
                    i--;
                }
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                numbers.Reverse();
                Console.WriteLine(string.Join(' ', numbers));
            }
        }
    }
}
