using System;

namespace NestedLoopMore1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());

            for (int i = 1; i <= x; i++)
            {
                bool validX = Convert.ToBoolean(i % 2);

                for (int j = 1; j <= y; j++)
                {
                    bool validY = false;

                    if (j == 2 || j == 3 || j == 5 || j == 7)
                    {
                        validY = true;
                    }
                    for (int k = 1; k <= z; k++)
                    {
                        bool validZ = Convert.ToBoolean(k % 2);

                        if (!validX && validY && !validZ)
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                }
            }
        }

    }
}
