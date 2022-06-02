using System;

namespace ConsoleApp2
{
    class Program
    {
        //Print Numbers in Reverse Order
        //Read n numbers and print them in reverse order, separated by a single space.
        //Examples
        //Input     Output
        //3         30 20 10
        //10
        //20
        //30
        //Input     Output
        //3         10 20 30
        //30
        //20
        //10
        //Input     Output
        //1         10
        //10

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            for (int k = n - 1; k >= 0; k--)
            {
                Console.Write($"{numbers[k]} ");
            }
        }
    }
}
