using System;

namespace FundamentalsExer8
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 1; i <= input; i++)
            {
                for (int y = 1; y <= i - 1; y++)
                {
                    Console.Write($"{i} ");
                }

                Console.WriteLine(i);
            }
        }
    }
}
