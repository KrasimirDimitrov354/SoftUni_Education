using System;

namespace Exercise8
{
    class Program
    {
        static void Main(string[] args)
        {
            string series = Console.ReadLine();
            double episodeLength = double.Parse(Console.ReadLine());
            double breakLength = double.Parse(Console.ReadLine());

            double lunchLength = breakLength / 8;
            double restLength = breakLength / 4;
            double breakLeft = (breakLength - lunchLength) - restLength;

            if (episodeLength > breakLeft)
            {
                Console.WriteLine($"You don't have enough time to watch {series}, you need {Math.Ceiling(episodeLength - breakLeft)} more minutes.");
            }
            else
            {
                Console.WriteLine($"You have enough time to watch {series} and left with {Math.Ceiling(breakLeft - episodeLength)} minutes free time.");
            }
        }
    }
}
