using System;

namespace NestedLoopLab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int counter = 0;
            int currentX = 0;
            int currentY = 0;
            bool combinationFound = false;

            for (int i = x; i <= y; i++)
            {
                for (int j = x; j <= y; j++)
                {
                    int result = i + j;
                    counter++;

                    if (result == magicNumber)
                    {
                        currentX = i;
                        currentY = j;
                        combinationFound = true;
                        break;
                    }
                }

                if (combinationFound)
                {
                    break;
                }
            }

            if (combinationFound)
            {
                Console.WriteLine($"Combination N:{counter} ({currentX} + {currentY} = {magicNumber})");
            }
            else
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
            }
        }
    }
}
