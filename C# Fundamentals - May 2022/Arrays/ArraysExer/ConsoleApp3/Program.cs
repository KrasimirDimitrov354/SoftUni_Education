using System;

namespace ConsoleApp3
{
    class Program
    {
        //Zig-Zag Arrays
        //Create a program that creates 2 arrays. You will be given an integer n.
        //On the next n lines, you will get 2 integers. Form 2 new arrays in a zig-zag pattern as shown below.
        //Examples
        //Input     Output
        //4         1 10 31 20
        //1 5       5 9 81 41
        //9 10
        //31 81
        //41 20	
        //Input     Output
        //2         80 19
        //80 23     23 31
        //31 19

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] firstArray = new string[n];
            string[] secondArray = new string[n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                if (i % 2 == 0)
                {
                    firstArray[i] = input[0];
                    secondArray[i] = input[1];
                }
                else
                {
                    firstArray[i] = input[1];
                    secondArray[i] = input[0];
                }
            }

            foreach (var number in firstArray)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
            foreach (var number in secondArray)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
