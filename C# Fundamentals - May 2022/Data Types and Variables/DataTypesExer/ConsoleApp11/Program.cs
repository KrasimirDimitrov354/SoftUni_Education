using System;
using System.Numerics;

namespace ConsoleApp11
{
    class Program
    {
        //11.	Snowballs
        //Write a program which calculates snowball data and outputs the best snowball value.
        //
        //You will receive N – an integer, the number of snowballs being made.
        //For each snowball you will receive 3 input lines:
        //•	On the first line, you will get the snowballSnow – an integer.
        //•	On the second line, you will get the snowballTime – an integer.
        //•	On the third line, you will get the snowballQuality – an integer.
        //
        //For each snowball you must calculate its snowballValue by the following formula:
        //(snowballSnow / snowballTime) ^ snowballQuality
        //In the end, you must print the highest calculated snowballValue.
        //
        //Input
        //•	On the first input line, you will receive N – the number of snowballs.
        //•	On the next N * 3 input lines you will be receiving data about snowballs.
        //Output
        //•	The output format is: {snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})
        //Constraints
        //•	The number of snowballs (N) will be an integer in the range [0, 100].
        //•	The snowballSnow is an integer in the range [0, 1000].
        //•	The snowballTime is an integer in the range [1, 500].
        //•	The snowballQuality is an integer in the range [0, 100].
        //Examples
        //Input	    Output              Input	    Output
        //2         10 : 2 = 125(3)     3           10 : 5 = 128(7)
        //10                            10
        //2                             5
        //3                             7
        //5                             16
        //5                             4
        //5                             2
        //                              20
        //                              2
        //                              2

        static void Main()
        {
            byte snowballsMade = byte.Parse(Console.ReadLine());
            short bestSnow = 0;
            short bestTime = 0;
            short bestQuality = 0;
            short currentSnow = 0;
            short currentTime = 0;
            short currentQuality = 0;
            BigInteger currentValue = 0;
            BigInteger bestValue = 0;
            byte counter = 1;

            for (int i = 1; i <= snowballsMade * 3; i++)
            {
                short number = short.Parse(Console.ReadLine());

                switch (counter)
                {
                    case 1:
                        currentSnow = number;
                        counter++;
                        break;
                    case 2:
                        currentTime = number;
                        counter++;
                        break;
                    case 3:
                        currentQuality = number;
                        currentValue = BigInteger.Pow(currentSnow / currentTime, currentQuality);

                        if (currentValue > bestValue)
                        {
                            bestValue = currentValue;
                            bestSnow = currentSnow;
                            bestTime = currentTime;
                            bestQuality = currentQuality;
                        }
                        counter = 1;
                        break;
                }
            }

            Console.WriteLine($"{bestSnow} : {bestTime} = {bestValue} ({bestQuality})");
        }
    }
}
