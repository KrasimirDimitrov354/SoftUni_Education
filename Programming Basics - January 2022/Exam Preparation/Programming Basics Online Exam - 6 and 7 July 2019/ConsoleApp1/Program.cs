using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nightsCount = int.Parse(Console.ReadLine());
            double nightsPrice = double.Parse(Console.ReadLine());
            double expensesPercent = double.Parse(Console.ReadLine());

            double expensesTotal = (budget * expensesPercent) / 100;

            if (nightsCount > 7)
            {
                nightsPrice -= nightsPrice * 0.05;
            }

            expensesTotal += nightsCount * nightsPrice;

            if (budget >= expensesTotal)
            {
                Console.WriteLine($"Ivanovi will be left with {(budget - expensesTotal):f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{(expensesTotal - budget):f2} leva needed.");
            }
        }
    }
}
