using System;

namespace ConsoleApp17
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "ACTION")
                {
                    Console.WriteLine($"We are left with {budget:f2} leva.");
                    break;
                }
                else
                {
                    bool isNumber = double.TryParse(input, out double pay);

                    if (isNumber)
                    {
                        budget -= pay;
                    }
                    else
                    {
                        if (input.Length > 15)
                        {
                            budget -= budget * 0.2;
                        }
                    }

                    if (budget <= 0)
                    {
                        Console.WriteLine($"We need {Math.Abs(budget):f2} leva for our actors.");
                        break;
                    }
                }
            }
        }
    }
}
