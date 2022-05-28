using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            double target = double.Parse(Console.ReadLine());

            int drinkPrice = 0;
            int drinkOrders = 0;
            double currentProfit = 0;
            double totalProfit = 0;

            while (true)
            {
                if (totalProfit >= target)
                {
                    break;
                }

                string input = Console.ReadLine();

                if (input == "Party!")
                {
                    break;
                }
                else
                {
                    bool isNumber = int.TryParse(input, out drinkOrders);

                    if (isNumber)
                    {
                        currentProfit = drinkPrice * drinkOrders;

                        if (currentProfit % 2 != 0)
                        {
                            currentProfit -= currentProfit * 0.25;
                        }

                        totalProfit += currentProfit;
                    }
                    else
                    {
                        drinkPrice = input.Length;
                    }
                }
            }

            if (totalProfit >= target)
            {
                Console.WriteLine("Target acquired.");
            }
            else
            {
                Console.WriteLine($"We need {(target - totalProfit):f2} leva more.");
            }

            Console.WriteLine($"Club income - {totalProfit:f2} leva.");
        }
    }
}
