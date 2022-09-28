using System;
using System.Linq;

namespace ConsoleApp1
{
    //Diagonal Difference
    //Create a program that finds the difference between the sums of the square matrix diagonals (absolute value).
    //
    //Input
    //  •	On the first line you are given the integer N – the size of the square matrix.
    //  •	The next N lines hold the values for every row – N numbers separated by a space.
    //Output
    //  •	Print the absolute difference between the sums of the primary and the secondary diagonal.
    //Examples
    //Input     Output      Comments
    //3         15          Primary diagonal: sum = 11 + 5 + (-12) = 4
    //11 2 4                Secondary diagonal: sum = 4 + 5 + 10 = 19
    //4 5 6                 Difference: |4 - 19| = 15
    //10 8 -12
    //
    //

    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int rows = size;
            int columns = size;

            int[,] matrixOfNums = new int[rows,columns];

            int primDiagonal = 0;
            int secDiagonal = 0;

            for (int i = 0; i < rows; i++)
            {
                int[] nums = Console.ReadLine()
                    .Split()
                    .Select(n => int.Parse(n))
                    .ToArray();

                for (int j = 0; j < columns; j++)
                {
                    matrixOfNums[i, j] = nums[j];

                    if (i == j)
                    {
                        primDiagonal += matrixOfNums[i, j];
                    }

                    if (j == columns - (i + 1))
                    {
                        secDiagonal += matrixOfNums[i, j];
                    }
                }
            }

            Console.WriteLine(Math.Abs(primDiagonal - secDiagonal));
        }
    }
}
