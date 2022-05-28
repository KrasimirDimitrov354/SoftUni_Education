using System;

namespace ForStatExer8
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournamentsCount = int.Parse(Console.ReadLine());
            int playerPoints = int.Parse(Console.ReadLine());

            double earnedPoints = 0;
            double tournamentsWon = 0;

            for (int i = 1; i <= tournamentsCount; i++)
            {
                string tournamentOutcome = Console.ReadLine();

                switch (tournamentOutcome)
                {
                    case "W":
                        earnedPoints += 2000;
                        tournamentsWon++;
                        break;
                    case "F":
                        earnedPoints += 1200;
                        break;
                    case "SF":
                        earnedPoints += 720;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Final points: {playerPoints + earnedPoints}");
            Console.WriteLine($"Average points: {Math.Floor(earnedPoints / tournamentsCount)}");
            Console.WriteLine($"{((tournamentsWon / tournamentsCount) * 100):f2}%");
        }
    }
}
