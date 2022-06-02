using System;

namespace ConsoleApp6
{
    class Program
    {
        //Even and Odd Subtraction
        //Create a program that calculates the difference between the sum of the even and the sum of the odd numbers in an array.
        //Examples
        //Input         Output  Comments
        //1 2 3 4 5 6	3	    Even: 2 + 4 + 6 = 12
        //                      Odd: 1 + 3 + 5 = 9
        //                      Result: 12 – 9 = 3
        //Input         Output  Comments
        //3 5 7 9	    -24	    Even: 0
        //                      Odd: 3 + 5 + 7 + 9 = 24
        //                      Result: 0 – 24 = -24
        //Input         Output  Comments
        //2 4 6 8 10	30	    Even: 2 + 4 + 6 + 8 + 10 = 30
        //                      Odd: 0
        //                      Result: 30 – 0 = 30

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] numbers = new int[input.Length];

            int evenSum = 0;
            int oddSum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                numbers[i] = int.Parse(input[i]);

                if (numbers[i] % 2 == 0)
                {
                    evenSum += numbers[i];
                }
                else
                {
                    oddSum += numbers[i];
                }
            }

            Console.WriteLine(evenSum - oddSum);
        }
    }
}
