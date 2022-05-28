using System;

namespace Exercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            int magnoliaCount = int.Parse(Console.ReadLine());
            int hyacinthCount = int.Parse(Console.ReadLine());
            int roseCount = int.Parse(Console.ReadLine());
            int cactusCount = int.Parse(Console.ReadLine());
            double giftPrice = double.Parse(Console.ReadLine());

            double beforeTax = (magnoliaCount * 3.25) + (hyacinthCount * 4) + (roseCount * 3.5) + (cactusCount * 8);
            double afterTax = beforeTax - (beforeTax * 0.05);

            if (afterTax >= giftPrice)
            {
                Console.WriteLine($"She is left with {Math.Floor(afterTax - giftPrice)} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(giftPrice - afterTax)} leva.");
            }
        }
    }
}
