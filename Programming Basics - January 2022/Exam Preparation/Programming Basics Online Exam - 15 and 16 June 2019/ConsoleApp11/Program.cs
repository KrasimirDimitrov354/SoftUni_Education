using System;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            string seriesName = Console.ReadLine();
            int seriesSeasons = int.Parse(Console.ReadLine());
            int episodesCount = int.Parse(Console.ReadLine());
            double episodeDuration = double.Parse(Console.ReadLine());

            double commercialsDuration = episodeDuration * 0.2;
            double episodeDurationTotal = episodeDuration + commercialsDuration;
            int seasonFinaleExtraTime = seriesSeasons * 10;

            Console.WriteLine($"Total time needed to watch the {seriesName} series is {Math.Floor((seriesSeasons * episodesCount * episodeDurationTotal) + seasonFinaleExtraTime)} minutes.");
        }
    }
}
