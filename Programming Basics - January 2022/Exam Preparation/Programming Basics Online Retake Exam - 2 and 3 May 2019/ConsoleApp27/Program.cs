using System;

namespace ConsoleApp27
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double dailySum = 0;
            double totalSum = 0;

            for (int i = 1; i <= days; i++)
            {
                for (int y = 1; y <= hours; y++)
                {
                    if (i % 2 == 0 && y % 2 != 0)
                    {
                        dailySum += 2.5;
                    }
                    else if (i % 2 != 0 && y % 2 == 0)
                    {
                        dailySum += 1.25;
                    }
                    else
                    {
                        dailySum += 1;
                    }
                }

                Console.WriteLine($"Day: {i} - {dailySum:f2} leva");
                totalSum += dailySum;
                dailySum = 0;
            }

            Console.WriteLine($"Total: {totalSum:f2} leva");
        }
    }
}