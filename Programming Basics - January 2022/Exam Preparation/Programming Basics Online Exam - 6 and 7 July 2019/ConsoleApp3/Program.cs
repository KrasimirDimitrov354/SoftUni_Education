using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string drink = Console.ReadLine();
            string sugar = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            double total = 0;

            switch (drink)
            {
                case "Espresso":
                    switch (sugar)
                    {
                        case "Without":
                            total = count * 0.9;
                            break;
                        case "Normal":
                            total = count * 1;
                            break;
                        case "Extra":
                            total = count * 1.2;
                            break;
                    }
                    break;
                case "Cappuccino":
                    switch (sugar)
                    {
                        case "Without":
                            total = count * 1;
                            break;
                        case "Normal":
                            total = count * 1.2;
                            break;
                        case "Extra":
                            total = count * 1.6;
                            break;
                    }
                    break;
                case "Tea":
                    switch (sugar)
                    {
                        case "Without":
                            total = count * 0.5;
                            break;
                        case "Normal":
                            total = count * 0.6;
                            break;
                        case "Extra":
                            total = count * 0.7;
                            break;
                    }
                    break;
                default:
                    break;
            }

            if (sugar == "Without")
            {
                total -= total * 0.35;
            }

            if (drink == "Espresso" && count >= 5)
            {
                total -= total * 0.25;
            }

            if (total > 15)
            {
                total -= total * 0.2;
            }

            Console.WriteLine($"You bought {count} cups of {drink} for {total:f2} lv.");
        }
    }
}
