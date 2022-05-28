using System;

namespace FundamentalsExer11
{
    class Program
    {
        static void Main(string[] args)
        {
            int orders = int.Parse(Console.ReadLine());

            double priceCurrent = 0.0;
            double priceTotal = 0.0;

            for (int i = 1; i <= orders; i++)
            {
                double coffeePrice = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int coffeeCount = int.Parse(Console.ReadLine());

                priceCurrent = coffeePrice * (days * coffeeCount);
                priceTotal += priceCurrent;

                Console.WriteLine($"The price for the coffee is: ${priceCurrent:f2}");
            }

            Console.WriteLine($"Total: ${priceTotal:f2}");
        }
    }
}
