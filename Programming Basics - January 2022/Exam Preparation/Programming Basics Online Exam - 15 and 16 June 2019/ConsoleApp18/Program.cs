using System;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int count = int.Parse(Console.ReadLine());

            int counter = 0;
            string seriesName = "";
            double seriesPrice = 0;

            while (true)
            {
                string input = Console.ReadLine();
                counter++;

                bool isNumber = double.TryParse(input, out seriesPrice);

                if (!isNumber)
                {
                    seriesName = input;
                }
                else
                {
                    switch (seriesName)
                    {
                        case "Thrones":
                            budget -= seriesPrice - (seriesPrice * 0.5);
                            break;
                        case "Lucifer":
                            budget -= seriesPrice - (seriesPrice * 0.4);
                            break;
                        case "Protector":
                            budget -= seriesPrice - (seriesPrice * 0.3);
                            break;
                        case "TotalDrama":
                            budget -= seriesPrice - (seriesPrice * 0.2);
                            break;
                        case "Area":
                            budget -= seriesPrice - (seriesPrice * 0.1);
                            break;
                        default:
                            budget -= seriesPrice;
                            break;
                    }
                }

                if (counter == (count * 2))
                {
                    break;
                }
            }

            if (budget >= 0)
            {
                Console.WriteLine($"You bought all the series and left with {budget:f2} lv.");
            }
            else
            {
                Console.WriteLine($"You need {Math.Abs(budget):f2} lv. more to buy the series!");
            }
        }
    }
}
