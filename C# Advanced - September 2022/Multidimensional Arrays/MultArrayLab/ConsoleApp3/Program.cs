using System;

namespace ConsoleApp3
{
    //Primary Diagonal
    //Create a program that finds the sum of matrix primary diagonal - [0,0] + [1,1] + [2,2] ... + [N, N].
    //
    //Input
    //  •	On the first line you are given the integer N – the size of the square matrix.
    //  •	The next N lines hold the values for every row – N numbers separated by a space.
    //
    //Examples
    //Input     Output      Input       Output
    //3         4           3           15
    //11 2 4                1 2 3
    //4 5 6                 4 5 6
    //10 8 -12              7 8 9

    class Program
    {
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            int primDiagonal = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                string[] rowData = Console.ReadLine().Split(" ");

                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = int.Parse(rowData[j]);

                    if (i == j)
                    {
                        primDiagonal += matrix[i, j];
                    }
                }
            }

            Console.WriteLine(primDiagonal);
        }
    }
}
