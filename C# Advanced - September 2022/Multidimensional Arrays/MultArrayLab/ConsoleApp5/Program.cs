using System;

namespace ConsoleApp5
{
    //Square with Maximum Sum
    //Create a program that reads a matrix from the console. Then find the biggest sum of the 2x2 submatrix and print it to the console.
    //
    //On the first line you will get matrix sizes in format {rows, columns}.
    //On the following lines you will get elements for each column separated with a comma.
    //
    //Print the biggest top-left square which you find and the sum of its elements.
    //
    //Examples
    //Input                 Output      Input               Output
    //3, 6                  9 8         2, 4                12 13
    //7, 1, 3, 3, 2, 1      7 9         10, 11, 12, 13      16 17
    //1, 3, 9, 8, 5, 6      33          14, 15, 16, 17      58
    //4, 6, 7, 9, 1, 0

    class Program
    {
        static void Main()
        {
            string[] matrixSize = Console.ReadLine().Split(", ");

            int rows = int.Parse(matrixSize[0]);
            int columns = int.Parse(matrixSize[1]);
            int[,] matrix = new int[rows, columns];

            int bestTop = 0;
            int bestBottom = 0;
            int[][] bestMatrix = new int[2][];

            for (int i = 0; i < rows; i++)
            {
                string[] rowData = Console.ReadLine().Split(", ");

                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = int.Parse(rowData[j]);
                }
            }

            for (int i = 0; i < rows - 1; i++)
            {
                int currentTop = 0;
                int currentBottom = 0;

                for (int j = 0; j < columns - 1; j++)
                {
                    currentTop = matrix[i, j] + matrix[i, j + 1];
                    currentBottom = matrix[i + 1, j] + matrix[i + 1, j + 1];

                    if (currentTop + currentBottom > bestTop + bestBottom)
                    {
                        bestTop = currentTop;
                        bestBottom = currentBottom;

                        bestMatrix[0] = new int[2]
                            { matrix[i, j], matrix[i, j + 1] };
                        bestMatrix[1] = new int[2]
                            { matrix[i + 1, j], matrix[i + 1, j + 1] };
                    }
                }
            }

            foreach (int[] row in bestMatrix)
            {
                Console.WriteLine(String.Join(' ', row));
            }
            Console.WriteLine(bestTop + bestBottom);
        }
    }
}
