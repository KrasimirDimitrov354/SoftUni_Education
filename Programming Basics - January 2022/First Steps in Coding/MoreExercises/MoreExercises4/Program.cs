using System;

namespace MoreExercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceVegetables = double.Parse(Console.ReadLine());
            double priceFruits = double.Parse(Console.ReadLine());
            double totalVegetables = double.Parse(Console.ReadLine());
            double totalFruits = double.Parse(Console.ReadLine());

            double priceBGN = (priceVegetables * totalVegetables) +
                (priceFruits * totalFruits);
            double priceEUR = priceBGN / 1.94;

            string final = priceEUR.ToString("0.00");

            Console.WriteLine(final);
        }
    }
}
