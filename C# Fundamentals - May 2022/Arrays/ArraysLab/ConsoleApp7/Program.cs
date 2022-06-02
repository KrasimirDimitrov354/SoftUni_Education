using System;

namespace ConsoleApp7
{
    class Program
    {
        //Equal Arrays
        //Read two arrays and determine whether they are identical or not. The arrays are identical if all their elements are equal.
        //If the arrays are identical find the sum of the elements of one of them and print the following message to the console: "Arrays are identical. Sum: {sum}"
        //Otherwise, find the first index where the arrays differ and print the following message to the console:  "Arrays are not identical. Found difference at {index} index."
        //Examples
        //Input         Output
        //10 20 30      Arrays are identical. Sum: 60
        //10 20 30
        //Input         Output
        //1 2 3 4 5     Arrays are not identical. Found difference at 2 index
        //1 2 4 3 5
        //Input         Output
        //1             Arrays are not identical. Found difference at 0 index
        //10

        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split(' ');
            string[] array2 = Console.ReadLine().Split(' ');

            double[] numbers1 = new double[array1.Length];
            double[] numbers2 = new double[array2.Length];

            double sum = 0.0;
            bool areIdentical = true;

            for (int i = 0; i < array1.Length; i++)
            {
                numbers1[i] = double.Parse(array1[i]);
                numbers2[i] = double.Parse(array2[i]);

                if (numbers1[i] == numbers2[i])
                {
                    sum += numbers1[i];
                }
                else
                {
                    areIdentical = false;
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    break;
                }
            }

            if (areIdentical)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
        }
    }
}
