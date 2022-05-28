using System;

namespace NestedLoopMore4
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start + 1; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    for (int k = start; k <= end; k++)
                    {
                        for (int l = start; l <= end; l++)
                        {
                            bool firstCondition = (i > l);
                            bool secondCondition = ((j + k) % 2 == 0);
                            bool thirdCondition = (i % 2 == 0 && l % 2 == 1) || (i % 2 == 1 && l % 2 == 0);

                            if (firstCondition && secondCondition && thirdCondition)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
