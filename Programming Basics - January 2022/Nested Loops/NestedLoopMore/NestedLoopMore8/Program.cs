using System;

namespace NestedLoopMore8
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());

            for (int i = 2; i <= x; i++)
            {
                bool isEven = (i % 2 == 0);

                for (int j = 2; j <= y; j++)
                {
                    bool isPrime = (j == 2 || j == 3 || j == 5 || j == 7);

                    for (int k = 2; k <= z; k++)
                    {
                        if (isEven && isPrime && (k % 2 == 0))
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                }
            }
        }
    }
}
