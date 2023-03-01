using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    //Enter Numbers
    //Write a method ReadNumber(int start, int end) that enters an integer number in the given range [start - end], excluding the numbers start and end.
    //If an invalid number or a non-number text is entered, the method should throw an exception.
    //  •	When the entered input holds a non-integer value, print “Invalid Number!”.
    //  •	When the entered input holds an integer that is out of range, print "Your number is not in range {currentNumber} - 100!".
    //
    //Using this method write a program that enters 10 numbers: a1, a2, ... a10, such that 1 < a1 < ... < a10 < 100.
    //If the user enters an invalid number, continue while there are 10 valid numbers entered.
    //
    //Print the array elements, separated with comma and space “, ”.
    //
    //Examples
    //Input     Output
    //2         2, 3, 4, 5, 6, 7, 8, 9, 10, 11
    //3
    //4
    //5
    //6
    //7
    //8
    //9
    //10
    //11
    //
    //Input     Output
    //1         Your number is not in range (1 - 100)
    //2         Your number is not in range(2 – 100)
    //1         Invalid Number!
    //3         2, 3, 4, 5, 6, 7, 8, 9, 10, 11
    //p
    //4
    //5
    //6
    //7
    //8
    //9
    //10
    //11

    class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int>();
            int start = 1;
            int end = 100;

            while (numbers.Count < 10)
            {
                try
                {
                    string number = Console.ReadLine();
                    ReadNumber(start, end, number);

                    start = int.Parse(number);
                    numbers.Add(int.Parse(number));
                }
                catch (ArgumentOutOfRangeException outOfRange)
                {
                    Console.WriteLine(outOfRange.ParamName);
                }
                catch (ArgumentException invalid)
                {
                    Console.WriteLine(invalid.Message);
                }
            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        private static void ReadNumber(int start, int end, string number)
        {
            if (!int.TryParse(number, out int num))
            {
                throw new ArgumentException("Invalid Number!");
            }

            if (num <= start || num >= end)
            {
                throw new ArgumentOutOfRangeException($"Your number is not in range {start} - {end}!");
            }
        }
    }
}
