using System;

namespace CondStatAdvMore6
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kmPerMonth = double.Parse(Console.ReadLine());

            double profit = 0;

            if (kmPerMonth <= 5000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        profit = (kmPerMonth * 0.75) * 4;
                        break;

                    case "Summer":
                        profit = (kmPerMonth * 0.9) * 4;
                        break;
                    case "Winter":
                        profit = (kmPerMonth * 1.05) * 4;
                        break;
                }
            }
            else if (kmPerMonth > 5000 & kmPerMonth <= 10000)
            {
                switch (season)
                {
                    case "Spring":
                    case "Autumn":
                        profit = (kmPerMonth * 0.95) * 4;
                        break;

                    case "Summer":
                        profit = (kmPerMonth * 1.1) * 4;
                        break;
                    case "Winter":
                        profit = (kmPerMonth * 1.25) * 4;
                        break;
                }
            }
            else
            {
                profit = (kmPerMonth * 1.45) * 4;
            }

            profit = profit - (profit * 0.1);

            Console.WriteLine($"{profit:f2}");
        }
    }
}
