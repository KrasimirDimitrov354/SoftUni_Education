using System;

namespace WhileLoopExer7
{
    class Program
    {
        static void Main(string[] args)
        {
            int apartmentWidth = int.Parse(Console.ReadLine());
            int apartmentLength = int.Parse(Console.ReadLine());
            int apartmentHeigth = int.Parse(Console.ReadLine());

            int availableSpace = apartmentWidth * apartmentLength * apartmentHeigth;

            while (availableSpace > 0)
            {
                string input = Console.ReadLine();

                if (input != "Done")
                {
                    int box = int.Parse(input);
                    availableSpace -= box;
                }
                else
                {
                    break;
                }
            }

            if (availableSpace <= 0)
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(availableSpace)} Cubic meters more.");
            }
            else
            {
                Console.WriteLine($"{availableSpace} Cubic meters left.");
            }
        }
    }
}
