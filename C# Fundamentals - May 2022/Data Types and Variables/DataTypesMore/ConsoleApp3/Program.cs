using System;

namespace ConsoleApp3
{
    class Program
    {
        //3.       Floating Equality
        //Write a program that safely compares floating-point numbers(double) with precision eps = 0.000001.
        //Note that we cannot directly compare two floating-point numbers a and b by using (a == b) because of the nature of the floating-point arithmetic.
        //Therefore, we assume two numbers are equal if they are more close to each other than some fixed constant eps.
        //You will receive two lines, each containing a floating - point number.Your task is to compare the values of the two numbers.
        //Examples
        //Number a      Number b    Equal(with precision eps = 0.000001)    Explanation
        //5.3           6.01        False                                   The difference of 0.71 is too big (> eps)
        //5.00000001    5.00000003  True                                    The difference 0.00000002 < eps
        //5.00000005    5.00000001  True                                    The difference 0.00000004 < eps
        //-0.0000007    0.00000007  True                                    The difference 0.00000077 < eps
        //-4.999999     -4.999998   False                                   Border case. The difference 0.0000001 == eps. We consider the numbers are different.
        //4.999999      4.999998    False                                   Border case.

        static void Main()
        {
            double eps = 0.000001;
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());

            bool areEqual = (Math.Abs(num1 - num2) < eps);
            Console.WriteLine(areEqual);
        }
    }
}
