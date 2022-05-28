using System;

namespace WhileLoopExer6
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLength = int.Parse(Console.ReadLine());

            int cake = cakeWidth * cakeLength;

            while (cake > 0)
            {
                string input = Console.ReadLine();

                if (input != "STOP")
                {
                    int piecesTaken = int.Parse(input);
                    cake -= piecesTaken;
                }
                else
                {
                    break;
                }
            }

            if (cake <= 0)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(cake)} pieces more.");
            }
            else
            {
                Console.WriteLine($"{cake} pieces are left.");
            }
        }
    }
}
