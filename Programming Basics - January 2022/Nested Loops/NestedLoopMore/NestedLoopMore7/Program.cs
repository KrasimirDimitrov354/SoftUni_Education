using System;

namespace NestedLoopMore7
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());

            int A = 35;
            int B = 64;
            int counter = 0;
            bool maxReached = false;

            for (int i = 1; i <= a; i++)
            {                
                for (int j = 1; j <= b; j++)
                {
                    Console.Write($"{(char)A}{(char)B}{i}{j}{(char)B}{(char)A}|");
                    A++;
                    B++;
                    counter++;

                    if (A > 55)
                    {
                        A = 35;
                    }

                    if (B > 96)
                    {
                        B = 64;
                    }

                    if (counter == max)
                    {
                        maxReached = true;
                        break;
                    }
                }

                if (maxReached)
                {
                    break;
                }
            }
        }
    }
}
