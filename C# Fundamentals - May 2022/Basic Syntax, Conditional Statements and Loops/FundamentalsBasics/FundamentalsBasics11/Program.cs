using System;

namespace FundamentalsBasics11
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            bool isNumber = double.TryParse(input, out double result);

            if (isNumber)
            {
                Console.WriteLine("It is a number.");
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
