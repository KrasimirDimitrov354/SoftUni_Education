using System;

namespace CondStatAdvMore4
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string carClass = "default";
            string carType = "default";
            double carRent = 0;

            if (budget <= 100)
            {
                carClass = "Economy class";

                switch (season)
                {
                    case "Summer":
                        carType = "Cabrio";
                        carRent = budget - (budget * 0.65);
                        break;
                    case "Winter":
                        carType = "Jeep";
                        carRent = budget - (budget * 0.35);
                        break;
                }
            }
            else if (budget > 100 & budget <= 500)
            {
                carClass = "Compact class";

                switch (season)
                {
                    case "Summer":
                        carType = "Cabrio";
                        carRent = budget - (budget * 0.55);
                        break;
                    case "Winter":
                        carType = "Jeep";
                        carRent = budget - (budget * 0.2);
                        break;
                }
            }
            else
            {
                carClass = "Luxury class";
                carType = "Jeep";
                carRent = budget - (budget * 0.1);
            }

            Console.WriteLine(carClass);
            Console.WriteLine($"{carType} - {carRent:f2}");
        }
    }
}
