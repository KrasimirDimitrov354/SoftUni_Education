using System;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            double area = double.Parse(Console.ReadLine());
            double pricePerMeter = 7.61;
            double discountPercentage = 0.18;

            double priceBeforeDiscount = area * pricePerMeter;
            double discountTotal = discountPercentage * priceBeforeDiscount;
            double finalPrice = priceBeforeDiscount - discountTotal;

            Console.WriteLine($"The final price is: {finalPrice} lv.");
            Console.WriteLine($"The discount is: {discountTotal} lv.");
        }
    }
}
