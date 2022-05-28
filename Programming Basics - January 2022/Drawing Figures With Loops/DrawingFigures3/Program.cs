using System;

namespace DrawingFigures4
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int counter = 1;

            for (int i = 1; i <= input; i++)
            {
                for (int j = 1; j <= counter; j++)
                {
                    Console.Write("$ ");
                }

                counter++;
                Console.WriteLine();
            }
        }
    }
}
