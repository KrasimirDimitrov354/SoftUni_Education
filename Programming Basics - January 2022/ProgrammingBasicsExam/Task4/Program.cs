using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double totalSales = 0;
            double totalRating = 0;
            int counter = 1;

            while (counter <= n)
            {
                string input = Console.ReadLine();

                int possibleSales = int.Parse(input.Substring(0, 2));
                int currentRating = int.Parse(input.Substring(2));

                totalRating += currentRating;

                switch (currentRating)
                {
                    case 2:
                        totalSales += 0;
                        break;
                    case 3:
                        totalSales += possibleSales * 0.5;
                        break;
                    case 4:
                        totalSales += possibleSales * 0.7;
                        break;
                    case 5:
                        totalSales += possibleSales * 0.85;
                        break;
                    case 6:
                        totalSales += possibleSales;
                        break;
                    default:
                        break;
                }               

                if (counter == n)
                {
                    Console.WriteLine($"{totalSales:f2}");
                    Console.WriteLine($"{(totalRating / n):f2}");
                }

                counter++;
            }
        }
    }
}
