using System;

namespace Exercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double videocardsCount = double.Parse(Console.ReadLine());
            double processorsCount = double.Parse(Console.ReadLine());
            double memoryCount = double.Parse(Console.ReadLine());
            double discount = 0;

            double videocardsPrice = videocardsCount * 250;
            double processorPrice = (videocardsPrice * 0.35) * processorsCount;
            double memoryPrice = (videocardsPrice * 0.1) * memoryCount;

            double totalPrice = videocardsPrice + processorPrice + memoryPrice;

            if (videocardsCount > processorsCount)
            {
                discount = totalPrice * 0.15;
                totalPrice = totalPrice - discount;
            }

            if (totalPrice <= budget)
            {
                Console.WriteLine($"You have {(budget - totalPrice):f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(totalPrice - budget):f2} leva more!");
            }
        }
    }
}
