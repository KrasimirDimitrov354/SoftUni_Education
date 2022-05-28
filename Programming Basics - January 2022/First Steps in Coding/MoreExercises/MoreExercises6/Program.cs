using System;

namespace MoreExercises6
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceSkumria = double.Parse(Console.ReadLine());
            double priceTsatsa = double.Parse(Console.ReadLine());
            double countPalamud = double.Parse(Console.ReadLine());
            double countSafrid = double.Parse(Console.ReadLine());
            double countMidi = double.Parse(Console.ReadLine());

            double priceMidi = 7.5;
            double pricePalamud = priceSkumria * 1.6;
            double priceSafrid = priceTsatsa * 1.8;

            double priceTotal = (countMidi * priceMidi) + (countPalamud * pricePalamud) +
                (countSafrid * priceSafrid);

            string final = priceTotal.ToString("0.00");

            Console.WriteLine(final);
        }
    }
}
