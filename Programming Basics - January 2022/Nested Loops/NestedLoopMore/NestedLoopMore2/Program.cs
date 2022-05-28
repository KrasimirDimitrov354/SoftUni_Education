using System;

namespace NestedLoopMore2
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char ignore = char.Parse(Console.ReadLine());

            int counter = 0;

            for (double i = (int)start; i <= (int)end; i++)
            {
                bool firstIsValid = false;

                if (i != (int)ignore)
                {
                    firstIsValid = true;
                }

                for (double j = (int)start; j <= (int)end; j++)
                {
                    bool secondIsValid = false;

                    if (j != (int)ignore)
                    {
                        secondIsValid = true;
                    }

                    for (double k = (int)start; k <= (int)end; k++)
                    {
                        bool thirdIsValid = false;

                        if (k != (int)ignore)
                        {
                            thirdIsValid = true;
                        }

                        if (firstIsValid && secondIsValid && thirdIsValid)
                        {
                            Console.Write($"{(char)i}{(char)j}{(char)k} ");
                            counter++;
                        }
                    }
                }
            }

            Console.Write(counter);
        }
    }
}
