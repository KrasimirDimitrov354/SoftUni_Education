using System;

namespace ConsoleApp2
{
    //Sum Matrix Columns
    //Create a program that reads a matrix from the console and prints the sum for each column.
    //On the first line you will get matrix rows. On the next rows lines you will get elements for each column separated with a space.
    //
    //Examples
    //Input         Output      Input       Output
    //3, 6          12          3, 3        12
    //7 1 3 3 2 1   10          1 2 3       15
    //1 3 9 8 5 6   19          4 5 6       18
    //4 6 7 9 1 0   20          7 8 9
    //              8
    //              7

    class Program
    {
        static void Main()
        {
            string[] matrixData = Console.ReadLine().Split(", ");

            int rows = int.Parse(matrixData[0]);
            int columns = int.Parse(matrixData[1]);
            int[,] matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                string[] rowData = Console.ReadLine().Split(" ");

                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = int.Parse(rowData[j]);
                }
            }

            for (int k = 0; k < columns; k++)
            {
                int totalCol = 0;

                for (int l = 0; l < rows; l++)
                {
                    totalCol += matrix[l, k];
                }

                Console.WriteLine(totalCol);
            }
        }
    }
}
