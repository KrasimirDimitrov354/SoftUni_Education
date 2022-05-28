using System;

namespace NestedLoopMore9
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int target = int.Parse(Console.ReadLine());

            int x = 0;
            int y = 0;
            int result = 0;
            int counter = 0;
            bool targetFound = false;

            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    result += i + j;
                    counter++;

                    if (result == target)
                    {
                        x = i;
                        y = j;
                        targetFound = true;
                        break;
                    }
                    else
                    {
                        result = 0;
                    }
                }

                if (targetFound)
                {
                    break;
                }
            }

            if (targetFound)
            {
                Console.WriteLine($"Combination N:{counter} ({x} + {y} = {result})");
            }
            else
            {
                Console.WriteLine($"{counter} combinations - neither equals {target}");
            }
        }
    }
}
