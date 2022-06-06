using System;

namespace ConsoleApp3
{
    class Program
    {
        //Rounding Numbers
        //Read an array of real numbers (space separated), round them in "away from 0" style, and print the output as in the examples:
        //Examples
        //Input                         Output
        //0.9 1.5 2.4 2.5 3.14	        0.9 => 1
        //                              1.5 => 2
        //                              2.4 => 2
        //                              2.5 => 3
        //                              3.14 => 3
        //Input                         Output
        //-5.01 -1.599 -2.5 -1.50 0	    -5.01 => -5
        //                              -1.599 => -2
        //                              -2.5 => -3
        //                              -1.50 => -2
        //                              0 => 0
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ');
            double[] numbersConverted = new double[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbersConverted[i] = double.Parse(numbers[i]);
                Console.WriteLine($"{numbersConverted[i]} => {(int)Math.Round(numbersConverted[i], MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
