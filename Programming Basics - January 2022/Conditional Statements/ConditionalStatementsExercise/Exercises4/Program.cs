using System;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripSum = double.Parse(Console.ReadLine());
            double puzzleOrders = double.Parse(Console.ReadLine());
            double dollOrders = double.Parse(Console.ReadLine());
            double bearOrders = double.Parse(Console.ReadLine());
            double hellspawnOrders = double.Parse(Console.ReadLine());
            double truckOrders = double.Parse(Console.ReadLine());

            double discountSum = 0;
            double rentSum = 0;
            double remainderSum = 0;

            double puzzlePrice = 2.6;
            double dollPrice = 3;
            double bearPrice = 4.1;
            double hellspawnPrice = 8.2;
            double truckPrice = 2;
            double discoutPercentage = 0.25;
            double rentPercentage = 0.1;

            double totalOrders = puzzleOrders + dollOrders + bearOrders +
                hellspawnOrders + truckOrders;
            double totalPrice = (puzzleOrders * puzzlePrice) + (dollOrders * dollPrice) +
                (bearOrders * bearPrice) + (hellspawnOrders * hellspawnPrice) + (truckOrders * truckPrice);

            if (totalOrders >= 50)
            {
                discountSum = totalPrice * discoutPercentage;
                totalPrice = totalPrice - discountSum;
            }

            rentSum = totalPrice * rentPercentage;
            totalPrice = totalPrice - rentSum;

            if (totalPrice >= tripSum)
            {
                remainderSum = totalPrice - tripSum;
                Console.WriteLine($"Yes! {remainderSum:f2} lv left.");
            }
            else
            {
                remainderSum = tripSum - totalPrice;
                Console.WriteLine($"Not enough money! {remainderSum:f2} lv needed.");
            }
        }
    }
}
