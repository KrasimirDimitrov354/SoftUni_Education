using System;

namespace NestedLoopMore14
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            for (int i = 1; i <= x; i++)
            {
                for (int j = 1; j <= x; j++)
                {
                    for (int k = 97; k < 97 + y; k++)
                    {
                        for (int l = 97; l < 97 + y; l++)
                        {
                            for (int m = 2; m <= x; m++)
                            {
                                if (m > i && m > j)
                                {
                                    Console.Write($"{i}{j}{(char)k}{(char)l}{m} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
