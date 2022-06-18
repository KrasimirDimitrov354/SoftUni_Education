using System;

namespace ConsoleApp8
{
    class Program
    {
        //Math Power
        //Create a method which receives two numbers as parameters:
        //  •	The first number – the base
        //  •	The second number – the power
        //The method should return the base raised to the given power.
        //Examples
        //Input     Output
        //2         256
        //8
        //Input     Output
        //3         81
        //4

        private static double Power(double baseNum, int powerNum)
        {
            double result = 0;

            if (powerNum == 0)
            {
                result = 1;
            }
            else
            {
                result = baseNum;

                for (int i = 2; i <= powerNum; i++)
                {
                    result = result * baseNum;
                }
            }            

            return result;
        }

        static void Main()
        {
            double baseNumber = double.Parse(Console.ReadLine());
            int powerNumber = int.Parse(Console.ReadLine());
            double result = Power(baseNumber, powerNumber);
            Console.WriteLine(result);
        }
    }
}
