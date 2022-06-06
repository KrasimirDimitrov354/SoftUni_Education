using System;

namespace ConsoleApp7
{
    class Program
    {
        // Max Sequence of Equal Elements
        //Create a program that finds the longest sequence of equal elements in an array of integers.
        //If several equal sequences are present in the array, print out the leftmost one.
        //Examples
        //Input                 Output
        //2 1 1 2 3 3 2 2 2 1	2 2 2
        //1 1 1 2 3 1 3 3	    1 1 1
        //4 4 4 4	            4 4 4 4
        //0 1 1 5 2 2 6 3 3	    1 1

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] numbers = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                numbers[i] = int.Parse(input[i]);
            }

            int counterCurrent = 1;
            int counterMax = 1;
            int element = 0;

            for (int j = 0; j < numbers.Length; j++)
            {
                if (j != numbers.Length - 1)
                {
                    if (numbers[j] == numbers[j + 1])
                    {
                        counterCurrent++;

                        if (counterCurrent > counterMax)
                        {
                            counterMax = counterCurrent;
                            element = numbers[j];
                        }
                    }
                    else
                    {
                        counterCurrent = 1;
                    }
                }
            }

            if (element == 0 && counterMax == 1)
            {
                Console.WriteLine(1);
            }
            else
            {
                for (int i = 1; i <= counterMax; i++)
                {

                    Console.Write($"{element} ");
                }
            }
            
        }
    }
}
