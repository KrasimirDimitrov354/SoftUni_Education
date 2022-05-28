using System;

namespace ConsoleApp15
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string location = Console.ReadLine();
            string season = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            double total = 0.0;

            switch (season)
            {
                case "Winter":
                    switch (location)
                    {
                        case "Dubai":
                            total = days * 45000;
                            break;
                        case "Sofia":
                            total = days * 17000;
                            break;
                        case "London":
                            total = days * 24000;
                            break;
                    }
                    break;

                case "Summer":
                    switch (location)
                    {
                        case "Dubai":
                            total = days * 40000;
                            break;
                        case "Sofia":
                            total = days * 12500;
                            break;
                        case "London":
                            total = days * 20250;
                            break;
                    }
                    break;
            }

            if (location == "Dubai")
            {
                total -= total * 0.3;
            }
            else if (location == "Sofia")
            {
                total += total * 0.25;
            }

            if (budget >= total)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {(budget - total):f2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {(total - budget):f2} leva more!");
            }
            
        }
    }
}
