using System;

namespace CondStatAdvExer5
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalBudget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double spentBudget = 0;
            string destination = "default";
            string establishment = "default";

            if (totalBudget <= 100)
            {
                destination = "Bulgaria";
            }
            else if (totalBudget > 100 & totalBudget <= 1000)
            {
                destination = "Balkans";
            }
            else
            {
                destination = "Europe";
            }

            switch (destination)
            {
                case "Bulgaria":
                    switch (season)
                    {
                        case "summer":
                            establishment = "Camp";
                            spentBudget = totalBudget * 0.3;
                            break;
                        case "winter":
                            establishment = "Hotel";
                            spentBudget = totalBudget * 0.7;
                            break;
                    }
                    break;
                case "Balkans":
                    switch (season)
                    {
                        case "summer":
                            establishment = "Camp";
                            spentBudget = totalBudget * 0.4;
                            break;
                        case "winter":
                            establishment = "Hotel";
                            spentBudget = totalBudget * 0.8;
                            break;
                    }
                    break;
                case "Europe":
                    switch (season)
                    {
                        case "summer":
                        case "winter":
                            establishment = "Hotel";
                            spentBudget = totalBudget * 0.9;
                            break;
                    }
                    break;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{establishment} - {spentBudget:f2}");
        }
    }
}
