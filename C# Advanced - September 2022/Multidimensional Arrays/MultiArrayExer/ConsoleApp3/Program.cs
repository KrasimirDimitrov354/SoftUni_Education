using System;
using System.Linq;

namespace ConsoleApp3
{
    //Maximal Sum
    //Create a program that reads a rectangular integer matrix of size N x M and finds in it the square 3 x 3 that has a maximal sum of its elements.
    //
    //Input
    //  •	On the first line you will receive the rows N and columns M. On the next N lines you will receive each row with its columns.
    //Output
    //  •	Print the elements of the 3 x 3 square as a matrix, along with their sum.
    //Examples
    //Input             Output
    //4 5               Sum = 75
    //1 5 5 2 4         1 4 14
    //2 1 4 14 3        7 11 2
    //3 7 11 2 8        8 12 16
    //4 8 12 16 4

    class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(d => int.Parse(d))
                .ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }

            int maxSum = int.MinValue;
            int[,] maxMatrix = new int[3, 3];

            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    int currentSum = 0;
                    int[,] currentMatrix = new int[,] {
                        { matrix[i, j], matrix[i, j + 1], matrix[i, j + 2] },
                        { matrix[i + 1, j], matrix[i + 1, j + 1], matrix[i + 1, j + 2] },
                        { matrix[i + 2, j], matrix[i + 2, j + 1], matrix[i + 2, j + 2] }
                        };

                    foreach (int num in currentMatrix)
                    {
                        currentSum += num;
                    }

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxMatrix = currentMatrix;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = 0; i < maxMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < maxMatrix.GetLength(1); j++)
                {
                    Console.Write($"{maxMatrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
