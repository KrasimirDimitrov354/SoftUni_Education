using System;

namespace FundamentalsExer6
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int factorialCurrent = 1;
            int factorialTotal = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int number = int.Parse(input[i].ToString());

                for (int y = 1; y <= number; y++)
                {
                    factorialCurrent *= y;
                }

                factorialTotal += factorialCurrent;
                factorialCurrent = 1;
            }

            if (factorialTotal == int.Parse(input))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}