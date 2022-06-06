using System;

namespace ConsoleApp8
{
    class Program
    {
        //Magic Sum
        //Create a program, which prints all unique pairs in an array of integers whose sum is equal to a given number.
        //Examples
        //Input                 Output
        //1 7 6 2 19 23         1 7
        //8	                    6 2
        //Input                 Output
        //14 20 60 13 7 19 8    14 13
        //27	                20 7
        //                      19 8

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int target = int.Parse(Console.ReadLine());

            int[] numbers = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                numbers[i] = int.Parse(input[i]);
            }

            for (int j = 0; j < numbers.Length; j++)
            {
                if (j != numbers.Length - 1)
                {
                    for (int k = j + 1; k < numbers.Length; k++)
                    {
                        if (numbers[j] + numbers[k] == target)
                        {
                            Console.WriteLine($"{numbers[j]} {numbers[k]}");
                        }
                    }
                }
            }
        }
    }
}
