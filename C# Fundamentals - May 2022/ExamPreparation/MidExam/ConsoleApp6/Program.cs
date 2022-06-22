using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6
{
    class Program
    {
        //Numbers
        //  Write a program to read a sequence of integers then find and print the top 5 numbers greater than the average value in the sequence, sorted in descending order.
        //Input
        //  •	Read from the console a single line holding space-separated integers.
        //Output
        //  •	Print the above-described numbers on a single line, space-separated.
        //  •	If less than 5 numbers hold the property mentioned above, print less than 5 numbers.
        //  •	Print "No" if no numbers hold the above property.
        //Constraints
        //  •	All input numbers are integers in the range [-1 000 000 … 1 000 000]. 
        //  •	The count of numbers is in the range [1…10 000].
        //
        //Examples
        //Input             Output      Comments
        //10 20 30 40 50	50 40	    Average number = 30.
        //                              Numbers greater than 30 are: {40, 50}. 
        //                              The top 5 numbers among them in descending order are: {50, 40}.
        //                              Note that we have only 2 numbers, so all of them are included in the top 5.
        //
        //Input                                 Output              Comments
        //5 2 3 4 -10 30 40 50 20 50 60 60 51	60 60 51 50 50	    Average number = 28.08.
        //                                                          Numbers greater than 28.08 are: {30, 40, 50, 50, 60, 60, 51}.
        //                                                          The top 5 numbers among them in descending order are: {60, 60, 51, 50, 50}.
        //Input     Output      Comments
        //1	        No          Average number = 1.
        //                      There are no numbers greater than 1.
        //
        //Input                 Output      Comments
        //-1 -2 -3 -4 -5 -6	    -1 -2 -3	Average number = -3.5.
        //                                  Numbers greater than -3.5 are: {-1, -2, -3}.
        //                                  The top 5 numbers among them in descending order are: {-1, -2, -3}.

        private static double FindAverage(List<int> numbers)
        {
            double average = 0.0;

            for (int i = 0; i < numbers.Count; i++)
            {
                average += numbers[i];
            }

            return average / numbers.Count;
        }

        private static void FindGreaterThanAverage(List<int> numbers, double average)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] <= average)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }
        }

        private static void PrintResult(List<int> numbers)
        {
            if (numbers.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                numbers = numbers.OrderByDescending(i => i).ToList();

                if (numbers.Count > 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write($"{numbers[i]} ");
                    }
                }
                else
                {
                    Console.WriteLine(string.Join(' ', numbers));
                }
                
            }
        }

        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
           
            double average = FindAverage(numbers);
            FindGreaterThanAverage(numbers, average);
            PrintResult(numbers);
        }
    }
}
