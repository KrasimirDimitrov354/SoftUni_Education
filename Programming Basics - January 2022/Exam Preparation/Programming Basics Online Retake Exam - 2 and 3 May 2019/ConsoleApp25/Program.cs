using System;

namespace ConsoleApp25
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            double expenses = 0;
            int discountCounter = 0;
            int totalCounter = 0;
            bool notEnoughMoney = false;
            
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Stop" || notEnoughMoney)
                {
                    break;
                }
                else
                {
                    bool isNumber = double.TryParse(input, out double price);

                    if (isNumber)
                    {
                        if (discountCounter == 3)
                        {
                            price /= 2;
                            discountCounter = 0;
                        }

                        budget -= price;
                        expenses += price;

                        if (budget < 0)
                        {
                            notEnoughMoney = true;
                        }
                    }
                    else
                    {
                        discountCounter++;
                        totalCounter++;
                    }
                }
            }

            if (notEnoughMoney)
            {
                Console.WriteLine("You don't have enough money!");
                Console.WriteLine($"You need {(Math.Abs(budget)):f2} leva!");
            }
            else
            {
                Console.WriteLine($"You bought {totalCounter} products for {expenses:f2} leva.");
            }
        }
    }
}
