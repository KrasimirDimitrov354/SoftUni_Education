using System;

namespace ConsoleApp5
{
    class Program
    {
        //Sum Even Numbers
        //Read an array from the console and sum only its even values.
        //Examples
        //Input         Output
        //1 2 3 4 5 6	12
        //3 5 7 9	    0
        //2 4 6 8 10	30

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] numbers = new int[input.Length];
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                numbers[i] = int.Parse(input[i]);

                if (numbers[i] % 2 == 0)
                {
                    sum += numbers[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
