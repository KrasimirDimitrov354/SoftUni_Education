using System;

namespace ConsoleAppExercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            double pens = double.Parse(Console.ReadLine());
            double markers = double.Parse(Console.ReadLine());
            double detergent = double.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double pensPrice = 5.8;
            double markersPrice = 7.2;
            double detergentPrice = 1.2;
            double discountPercentage = discount / 100;

            double totalNoDiscount = (pens * pensPrice) + (markers * markersPrice) +
                (detergent * detergentPrice);

            double finalPrice = totalNoDiscount -(totalNoDiscount * discountPercentage);

            Console.WriteLine(finalPrice);
        }
    }
}
