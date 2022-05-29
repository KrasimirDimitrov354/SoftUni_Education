using System;

namespace ConsoleApp7
{
    class Program
    {
        //7.	Water Overflow
        //You have a water tank with a capacity of 255 liters. On the next n lines, you will receive liters of water, which you have to pour into your tank.
        //If the capacity is not enough, print "Insufficient capacity!" and continue reading the next line. On the last line, print the liters in the tank.
        //Input
        //The input will be on two lines:
        //•	On the first line, you will receive n – the number of lines, which will follow
        //•	On the next n lines – you receive quantities of water, which you have to pour into the tank
        //Output
        //Every time you do not have enough capacity in the tank to pour the given liters, print:
        //Insufficient capacity!
        //On the last line, print only the liters in the tank.
        //Constraints
        //•	n will be in the interval [1…20]
        //•	liters will be in the interval [1…1000]
        //Examples
        //Input     Output                  Input     Output
        //5         Insufficient capacity!  1         Insufficient capacity!
        //20        240                     1000      0
        //100
        //100
        //100
        //20
        //Input     Output                  Input     Output
        //7         105                     4         Insufficient capacity!
        //10                                250       Insufficient capacity!
        //20                                10        Insufficient capacity!                              
        //30                                20        250
        //10                                40
        //5
        //10
        //20

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int tankCapacityTotal = 255;
            int tankCapacityCurrent = 0;

            for (int i = 1; i <= n; i++)
            {
                int liters = int.Parse(Console.ReadLine());

                if (tankCapacityTotal - liters >= 0)
                {
                    tankCapacityTotal -= liters;
                    tankCapacityCurrent += liters;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(tankCapacityCurrent);
        }
    }
}
