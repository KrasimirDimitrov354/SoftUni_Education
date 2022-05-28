using System;

namespace CondStatAdvMore3
{
    class Program
    {
        static void Main(string[] args)
        {
            int countChrysanthemum = int.Parse(Console.ReadLine());
            int countRoses = int.Parse(Console.ReadLine());
            int countTulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char isHoliday = char.Parse(Console.ReadLine());

            double flowersPrice = 0;

            switch (season)
            {
                case "Spring":
                case "Summer":
                    flowersPrice = (countChrysanthemum * 2) + (countRoses * 4.1) + (countTulips * 2.5);
                    break;

                case "Autumn":
                case "Winter":
                    flowersPrice = (countChrysanthemum * 3.75) + (countRoses * 4.5) + (countTulips * 4.15);
                    break;
            }

            if (isHoliday == 'Y')
            {
                flowersPrice = flowersPrice + (flowersPrice * 0.15);
            }

            if (countTulips > 7 && season == "Spring")
            {
                flowersPrice = flowersPrice - (flowersPrice * 0.05);
            }

            if (countRoses >= 10 && season == "Winter")
            {
                flowersPrice = flowersPrice - (flowersPrice * 0.1);
            }

            if ((countChrysanthemum + countRoses + countTulips) > 20)
            {
                flowersPrice = flowersPrice - (flowersPrice * 0.2);
            }

            Console.WriteLine($"{(flowersPrice + 2):f2}");
        }
    }
}
