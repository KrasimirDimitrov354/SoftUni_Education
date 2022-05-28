using System;

namespace NestedLoopMore10
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());
            int target = int.Parse(Console.ReadLine());

            for (int i = 0; i <= x; i++)
            {
                for (int j = 0; j <= y; j++)
                {
                    for (int k = 0; k <= z; k++)
                    {
                        if ((i * 1) + (j * 2) + (k * 5) == target)
                        {
                            Console.WriteLine($"{i} * 1 lv. + {j} * 2 lv. + {k} * 5 lv. = {target} lv.");
                        }
                    }
                }
            }
        }
    }
}
