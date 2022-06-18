using System;

namespace ConsoleApp1
{
    class Program
    {
        //Sign of Integer Numbers
        //A single integer is given, create a method that checks if the given number is positive, negative, or zero.
        //As a result print:
        //  •	For positive number: "The number {number} is positive."
        //  •	For negative number: "The number {number} is negative."
        //  •	For zero number: "The number {number} is zero."
        //Examples
        //Input     Output
        // 2	    The number 2 is positive.
        //-9	    The number -9 is negative.

        private static void CheckNumber(int number)
        {
            if (number < 0)
            {
                Console.WriteLine($"The number {number} is negative.");
            }
            else if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive.");
            }
            else
            {
                Console.WriteLine($"The number {number} is zero.");
            }
        }
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            CheckNumber(input);
        }
    }
}
