using System;

namespace ConsoleApp1
{
    //Sum Matrix Elements
    //Write a program that reads a matrix from the console and prints:
    //  •	Count of rows
    //  •	Count of columns
    //  •	Sum of all matrix elements
    //On the first line, you will get matrix sizes in format [rows, columns].
    //
    //Examples
    //Input                 Output
    //3, 6                  3
    //7, 1, 3, 3, 2, 1      6
    //1, 3, 9, 8, 5, 6      76
    //4, 6, 7, 9, 1, 0

    class Program
    {
        static void Main()
        {
            string[] matrixData = Console.ReadLine().Split(", ");
            int rows = int.Parse(matrixData[0]);
            int columns = int.Parse(matrixData[1]);

            int[,] matrix = new int[rows, columns];
            int total = 0;

            for (int i = 0; i < rows; i++)
            {
                string[] rowData = Console.ReadLine().Split(", ");

                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = int.Parse(rowData[j]);
                    total += matrix[i, j];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(columns);
            Console.WriteLine(total);
        }
    }
}
