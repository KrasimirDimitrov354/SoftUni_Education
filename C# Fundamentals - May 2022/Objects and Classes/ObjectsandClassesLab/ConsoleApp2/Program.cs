using System;
using System.Numerics;

namespace ConsoleApp2
{
    class Program
    {
        //Big Factorial
        //You will receive a number N in the range [0 - 1000]. Calculate the Factorial of N and print out the result.
        //Examples
        //Input Output
        //50	30414093201713378043612608166064768844377641568960512000000000000
        //125	188267717688892609974376770249160085759540364871492425887598231508353156331613598866882932889495923133646405445930057740630161919341380597818883457558547055524326375565007131770880000000000000000000000000000000

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);
        }
    }
}
