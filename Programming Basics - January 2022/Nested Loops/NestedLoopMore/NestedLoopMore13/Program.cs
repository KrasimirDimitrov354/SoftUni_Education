using System;

namespace NestedLoopMore13
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int diffX1Y1 = int.Parse(Console.ReadLine());
            int diffX2Y2 = int.Parse(Console.ReadLine());

            for (int i = x1; i <= x1 + diffX1Y1; i++)
            {
                bool firstCondition = ((i % 2 != 0) && (i % 3 != 0) && (i % 5 != 0) && (i % 7 != 0));

                for (int j = x2; j <= x2 + diffX2Y2; j++)
                {
                    bool secondCondition = ((j % 2 != 0) && (j % 3 != 0) && (j % 5 != 0) && (j % 7 != 0));

                    if (firstCondition && secondCondition)
                    {
                        Console.WriteLine($"{i}{j}");
                    }
                }
            }
        }
    }
}
