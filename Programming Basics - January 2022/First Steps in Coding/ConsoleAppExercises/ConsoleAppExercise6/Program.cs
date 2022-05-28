using System;

namespace ConsoleAppExercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            double cover = double.Parse(Console.ReadLine());
            double paint = double.Parse(Console.ReadLine());
            double diluent = double.Parse(Console.ReadLine());
            double workHours = double.Parse(Console.ReadLine());

            double coverPrice = 1.5;
            double paintPrice = 14.5;
            double diluentPrice = 5;
            double bagsPrice = 0.4;

            double additionalCover = 2;
            double additionalPaint = paint / 10;

            double totalPriceCover = (cover + additionalCover) * coverPrice;
            double totalPricePaint = (paint + additionalPaint) * paintPrice;
            double totalPriceDiluent = diluent * diluentPrice;

            double totalPriceMaterials = totalPriceCover + totalPricePaint +
                totalPriceDiluent + bagsPrice;

            double workPriceHour = totalPriceMaterials * 0.30;

            double final = totalPriceMaterials + (workPriceHour * workHours);

            Console.WriteLine(final);
        }
    }
}
