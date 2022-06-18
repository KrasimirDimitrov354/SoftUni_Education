using System;

namespace ConsoleApp5
{
    class Program
    {
        //Orders
        //Create a program that calculates and prints the total price of an order.
        //The method should receive two parameters:
        //  •	A string, representing a product - "coffee",  "water", "coke", "snacks"
        //  •	An integer, representing the quantity of the product
        //The prices for a single item of each product are:
        //  •	coffee – 1.50
        //  •	water – 1.00
        //  •	coke – 1.40
        //  •	snacks – 2.00
        //Print the result rounded to the second decimal place.
        //Example
        //Input     Output      Input   Output
        //water     5.00        coffee  3.00
        //5                     2

        private static void CalculateOrder(string product, int quantity)
        {
            double sum = 0.0;

            switch (product)
            {
                case "coffee":
                    sum += 1.5 * quantity;
                    break;
                case "water":
                    sum += 1 * quantity;
                    break;
                case "coke":
                    sum += 1.4 * quantity;
                    break;
                case "snacks":
                    sum += 2 * quantity;
                    break;
            }

            Console.WriteLine($"{sum:f2}");
        }

        static void Main()
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            CalculateOrder(product, quantity);
        }
    }
}
