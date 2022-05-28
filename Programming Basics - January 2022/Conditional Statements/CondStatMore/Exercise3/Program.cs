using System;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            int vineyardTotal = int.Parse(Console.ReadLine());
            double grapesPerMeter = double.Parse(Console.ReadLine());
            int wineNeeded = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double grapesTotal = vineyardTotal * grapesPerMeter;
            double grapesForWine = grapesTotal * 0.4;
            double wineProduced = grapesForWine / 2.5;

            if (wineProduced >= wineNeeded)
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wineProduced)} liters.");
                Console.WriteLine($"{Math.Ceiling(wineProduced - wineNeeded)} liters left -> {Math.Ceiling((wineProduced - wineNeeded) / workers)} liters per person.");
            }
            else
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(wineNeeded - wineProduced)} liters wine needed.");
            }
        }
    }
}
