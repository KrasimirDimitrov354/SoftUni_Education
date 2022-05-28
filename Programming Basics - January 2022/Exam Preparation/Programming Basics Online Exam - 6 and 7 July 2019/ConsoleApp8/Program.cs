using System;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            string club = Console.ReadLine();
            int matches = int.Parse(Console.ReadLine());

            int counter = 1;
            int countWins = 0;
            int countDraws = 0;
            int countLosses = 0;
            int countTotal = 0;
            int points = 0;

            if (matches == 0)
            {
                Console.WriteLine($"{club} hasn't played any games during this season.");
            }
            else
            {
                while (counter <= matches)
                {
                    char result = char.Parse(Console.ReadLine());
                    countTotal++;

                    switch (result)
                    {
                        case 'W':
                            countWins++;
                            points += 3;
                            break;
                        case 'D':
                            countDraws++;
                            points += 1;
                            break;
                        case 'L':
                            countLosses++;
                            break;
                    }

                    counter++;
                }

                Console.WriteLine($"{club} has won {points} points during this season.");
                Console.WriteLine("Total stats:");
                Console.WriteLine($"## W: {countWins}");
                Console.WriteLine($"## D: {countDraws}");
                Console.WriteLine($"## L: {countLosses}");
                Console.WriteLine($"Win rate: {(((countWins * 1.0) / matches) * 100):f2}%");
            }
        }
    }
}
