using System;

namespace CondStatAdvMore10
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = 0;

            do
            {
                number = double.Parse(Console.ReadLine());

                if (number >= 0)
                {
                    Console.WriteLine($"Result: {(number * 2):f2}");
                }
                else
                {
                    Console.WriteLine("Negative number!");
                    break;
                }
            } while (number >= 0);         
        }
    }
}
