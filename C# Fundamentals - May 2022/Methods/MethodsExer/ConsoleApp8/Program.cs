using System;

namespace ConsoleApp8
{
    class Program
    {
        //Factorial Division
        //Read two integers. Calculate the factorial of each number.
        //Divide the first result by the second and print the result of the division formatted to the second decimal point.
        //Examples
        //Input     Output  Input   Output
        //5         60.00   6       360.00
        //2			        2

        private static long CalculateFactorial(int number)
        {
            long result = 1;

            for (int i = 1; i <= number; i++)
            {
                result = i * result;
            }

            return result;
        }

        private static double DivideFactorials(long firstFact, long secondFact)
        {
            double result = firstFact * 1.0 / secondFact * 1.0;
            return result;
        }

        static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            long firstFactorial = CalculateFactorial(firstNumber);
            long secondFactorial = CalculateFactorial(secondNumber);
            Console.WriteLine($"{DivideFactorials(firstFactorial, secondFactorial):f2}");
        }
    }
}
