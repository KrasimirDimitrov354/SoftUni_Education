using System;

namespace ConsoleApp10
{
    class Program
    {
        //10.	Pokemon
        //The Pokemon pokes his target and then proceeds to poke another target. The distance between his targets reduces his poke power.
        //You will be given the poke power the Pokemon has, N – an integer.
        //Then you will be given the distance between the poke targets, M – an integer.
        //Then you will be given the exhaustionFactor Y – an integer.
        //Your task is to start subtracting M from N until N becomes less than M, i.e. the Pokemon does not have enough power to reach the next target. 
        //Every time you subtract M from N that means you’ve reached a target and poked it successfully. Count how many targets you’ve poked.
        //
        //The Pokemon becomes gradually more exhausted. If N becomes equal to exactly 50% of its original value, you must divide N by Y. This division is between integers.
        //Note: 505 is not 50% from 1000, it is 50.5%.
        //If an exact division is not possible, it should not be done. Instead, you should continue subtracting.
        //
        //After dividing, you should continue subtracting from N, until it becomes less than M.
        //When N becomes less than M, you must take what has remained of N and the count of targets you’ve poked, and print them as output.
        //Input
        //•	The input consists of 3 lines.
        //•	On the first line, you will receive N – an integer.
        //•	On the second line, you will receive M – an integer.
        //•	On the third line, you will receive Y – an integer.
        //Output
        //•	The output consists of 2 lines.
        //•	On the first line print what has remained of N, after subtracting from it.
        //•	On the second line print the count of targets, you’ve managed to poke.
        //Constrains
        //•	The integer N will be in the range [1, 2.000.000.000].
        //•	The integer M will be in the range [1, 1.000.000].
        //•	The integer Y will be in the range [0, 9].
        //Examples
        //Input     Output      Comments                                                    Input     Output    Comments
        //5	        1           N = 5, M = 2, Y = 3.                                        10          2       N = 10, M = 5, Y = 2.
        //2         2           We start subtracting M from N.                              5           1       N – M = 5. (N is still not less than M, they are equal).
        //3                     N – M = 3. 1 target poked. N – M = 1. 2 targets poked.      2                   5 is 50% from 10.
        //                      N < M.                                                                          N / Y = 5 / 2 = 2. (integer division).
        //                      We print what has remained of N, which is 1.                                    N = 2. Pokes performed - 1.
        //                      We print the count of pokes, which is 2.

        static void Main()
        {
            int powerOriginal = int.Parse(Console.ReadLine());
            int distanceToPoke = int.Parse(Console.ReadLine());
            int pokingExhaustion = int.Parse(Console.ReadLine());

            int pokes = 0;
            int powerModified = powerOriginal;

            while (powerModified >= distanceToPoke)
            {
                powerModified -= distanceToPoke;
                pokes++;

                bool isHalf = (((powerModified * 1.0) / (powerOriginal * 1.0)) * 100.0) == 50.0;

                if (isHalf && pokingExhaustion != 0)
                {
                    powerModified /= pokingExhaustion;
                }
            }

            Console.WriteLine(powerModified);
            Console.WriteLine(pokes);
        }
    }
}
