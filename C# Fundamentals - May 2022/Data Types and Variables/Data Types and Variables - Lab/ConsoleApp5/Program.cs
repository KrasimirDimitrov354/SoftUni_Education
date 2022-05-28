using System;

namespace ConsoleApp5
{
    class Program
    {
        //        5.	Special Numbers
        //A number is special when its sum of digits is 5, 7, or 11.
        //Write a program to read an integer n and for all numbers in the range 1…n to print the number and if it is special or not(True / False).
        //Examples
        //Input   Output
        //7	       1 -> False
        //         2 -> False
        //         3 -> False
        //         4 -> False
        //         5 -> True
        //         6 -> False
        //         7 -> True
        //Input    Output
        //15	   1 -> False
        //         2 -> False
        //         3 -> False
        //         4 -> False
        //         5 -> True
        //         6 -> False
        //         7 -> True
        //         8 -> False
        //         9 -> False
        //         10 -> False
        //         11 -> False
        //         12 -> False
        //         13 -> False
        //         14 -> True
        //         15 -> False

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                string number = i.ToString();

                for (int y = 0; y < number.Length; y++)
                {
                    int digit = int.Parse(number[y].ToString());
                    sum += digit;

                    if (y == number.Length - 1)
                    {
                        if (sum == 5 || sum == 7 || sum == 11)
                        {
                            Console.WriteLine($"{i} -> True");
                        }
                        else
                        {
                            Console.WriteLine($"{i} -> False");
                        }

                        sum = 0;
                    }
                }
            }
        }
    }
}
