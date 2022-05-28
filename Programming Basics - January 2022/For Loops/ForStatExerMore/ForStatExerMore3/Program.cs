using System;

namespace ForStatExerMore3
{
    class Program
    {
        static void Main(string[] args)
        {
            int cargoCount = int.Parse(Console.ReadLine());

            double totalTonnage = 0;
            double totalCost = 0;
            double cargoByVan = 0;
            double cargoByTruck = 0;
            double cargoByTrain = 0;

            for (int i = 1; i <= cargoCount; i++)
            {
                int cargoTonnage = int.Parse(Console.ReadLine());
                totalTonnage += cargoTonnage;

                if (cargoTonnage <= 3)
                {
                    cargoByVan += cargoTonnage;
                    totalCost += 200 * cargoTonnage;
                }
                else if (cargoTonnage > 3 & cargoTonnage <= 11)
                {
                    cargoByTruck += cargoTonnage;
                    totalCost += 175 * cargoTonnage;
                }
                else if (cargoTonnage > 11)
                {
                    cargoByTrain += cargoTonnage;
                    totalCost += 120 * cargoTonnage;
                }
            }

            Console.WriteLine($"{(totalCost / totalTonnage):f2}");
            Console.WriteLine($"{((cargoByVan / totalTonnage) * 100):f2}%");
            Console.WriteLine($"{((cargoByTruck / totalTonnage) * 100):f2}%");
            Console.WriteLine($"{((cargoByTrain / totalTonnage) * 100):f2}%");
        }
    }
}
