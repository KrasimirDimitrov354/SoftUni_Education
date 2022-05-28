using System;

namespace DrawingFigures8
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int counterStars = input * 2;
            string stars = new String('*', counterStars);
            int counterTilted = (2 * input) - 2;
            string tilted = new String('/', counterTilted);
            string emptySpaces = new String(' ', input);
            string lines = new String('|', input);

            int rowLines = ((input - 1) / 2) + 1;

            for (int i = 1; i <= input; i++)
            {
                if (i == 1 || i == input)
                {
                    Console.Write(stars);
                    Console.Write(emptySpaces);
                    Console.WriteLine(stars);
                }
                else
                {
                    Console.Write($"*{tilted}*");

                    if (i == rowLines)
                    {
                        Console.Write(lines);
                    }
                    else
                    {
                        Console.Write(emptySpaces);
                    }

                    Console.WriteLine($"*{tilted}*");
                }
            }
        }
    }
}
