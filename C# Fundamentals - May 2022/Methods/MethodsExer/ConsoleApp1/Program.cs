using System;

namespace ConsoleApp1
{
    class Program
    {
        //Smallest of Three Numbers
        //Create a method that prints out the smallest of three integer numbers.
        //Examples
        //Input     Output
        //2         2
        //5
        //3
        //Input     Output
        //600       123
        //342
        //123
        //Input     Output	
        //25    	4
        //21
        //4

        private static int FindSmallest(int[] numbers)
        {
            int smallestNum = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                int currentNum = numbers[i];

                if (currentNum < smallestNum)
                {
                    smallestNum = currentNum;
                }
            }

            return smallestNum;
        }

        static void Main()
        {
            int[] numbers = new int[3];

            for (int i = 0; i < numbers.Length; i++)
            {
                var input = int.Parse(Console.ReadLine());
                numbers[i] = input;
            }

            Console.WriteLine(FindSmallest(numbers));
        }
    }
}
