using System;

namespace Combinatorics
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter combinatorics operation - permutation, variation, combination:");
            string operation = Console.ReadLine();

            Console.WriteLine("Enter count of elements n:");
            int n = int.Parse(Console.ReadLine());

            long result = 0;

            switch (operation)
            {
                case "permutation":
                    result = CalculatePermutation(n);
                    Console.WriteLine($"The {operation} of {n} n elements is {result}.");
                    break;
                case "variation":
                case "combination":
                    Console.WriteLine("Enter count of elements k:");
                    int k = int.Parse(Console.ReadLine());

                    if (operation == "variation")
                    {
                        result = CalculateVariation(n, k);
                    }
                    else
                    {
                        result = CalculateCombination(n, k);
                    }

                    Console.WriteLine($"The {operation} of {k} k elements within {n} n elements is {result}.");
                    break;
            }
        }

        private static long CalculatePermutation(int n)
        {
            long result = 1;

            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        private static long CalculateVariation(int n, int k)
        {
            long result = n;

            for (int i = 2; i <= k; i++)
            {
                result *= n - i + 1;
            }

            return result;
        }

        private static long CalculateCombination(int n, int k)
        {
            return CalculateVariation(n, k) / CalculatePermutation(k); 
        }
    }
}
