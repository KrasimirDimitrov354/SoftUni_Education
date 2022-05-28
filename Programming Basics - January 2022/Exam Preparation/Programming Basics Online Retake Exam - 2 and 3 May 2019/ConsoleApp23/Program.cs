using System;

namespace ConsoleApp23
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double fuel = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            double expenses = 100 + (fuel * 2.1);

            if (day == "Saturday")
            {
                expenses -= (expenses * 0.1);
            }
            else
            {
                expenses -= (expenses * 0.2);
            }

            if (budget - expenses >= 0)
            {
                Console.WriteLine($"Safari time! Money left: {(budget - expenses):f2} lv. ");
            }
            else
            {
                Console.WriteLine($"Not enough money! Money needed: {(expenses - budget):f2} lv.");
            }
        }
    }
}
