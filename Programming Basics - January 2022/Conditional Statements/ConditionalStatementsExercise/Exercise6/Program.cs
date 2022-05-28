using System;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            double timeToBeat = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timePerMeter = double.Parse(Console.ReadLine());

            double finalTime = distance * timePerMeter;
            double timesToAddTime = Math.Floor(distance / 15);
            finalTime = finalTime + (timesToAddTime * 12.5);

            if (finalTime >= timeToBeat)
            {
                Console.WriteLine($"No, he failed! He was {(finalTime - timeToBeat):f2} seconds slower.");
            }
            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {finalTime:f2} seconds.");
            }
        }
    }
}
