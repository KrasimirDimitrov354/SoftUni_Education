using System;

namespace NestedLoopMore6
{
    class Program
    {
        static void Main(string[] args)
        {
            char end = char.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            int seats = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = 65; i <= (int)end; i++)
            {
                for (int j = 1; j <= rows; j++)
                {
                    if (j % 2 == 0)
                    {
                        seats += 2;
                    }
                    else if (j != 1)
                    {
                        seats -= 2;
                    }

                    for (int k = 1; k <= seats; k++)
                    {
                        Console.WriteLine($"{(char)i}{j}{(char)(k + 96)}");
                        counter++;
                    }
                }

                if (rows % 2 == 0)
                {
                    seats -= 2;
                }

                rows++;              
            }

            Console.WriteLine(counter);
        }
    }
}
