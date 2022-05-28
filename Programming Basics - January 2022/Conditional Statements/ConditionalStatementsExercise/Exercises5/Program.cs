using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double extrasCount = double.Parse(Console.ReadLine());
            double costumePrice = double.Parse(Console.ReadLine());

            double decorPrice = budget * 0.1;
            double allCostumesPrices = extrasCount * costumePrice;
            double costumesDiscount = 0;
            double totalPrice = 0;

            if (extrasCount >= 150)
            {
                costumesDiscount = allCostumesPrices * 0.1;
                allCostumesPrices = allCostumesPrices - costumesDiscount;
            }

            totalPrice = decorPrice + allCostumesPrices;

            if (totalPrice > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(totalPrice - budget):f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {(budget - totalPrice):f2} leva left.");
            }
        }
    }
}
