using System;
using System.Linq;

namespace ConsoleApp2
{
    //2X2 Squares in Matrix
    //Find the count of 2 x 2 squares of equal chars in a matrix.
    //
    //Input
    //  •	On the first line you are given the integers rows and columns – the matrix’s dimensions.
    //  •	Matrix characters come at the next rows lines (space separated).
    //Output
    //  •	Print the number of all the equal pairs you have found.
    //Examples
    //Input     Output
    //3 4       2
    //A B B D
    //E B B B
    //I J B B
    //
    //Input     Output
    //2 2       0
    //a b
    //c d

    class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(d => int.Parse(d))
                .ToArray();

            int rows = dimensions[0];
            int columns = dimensions[1];

            char[,] matrix = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                char[] symbols = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => char.Parse(s))
                    .ToArray();

                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = symbols[j];
                }
            }

            int equalsCount = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[i, j] == matrix[i, j + 1] &&
                        matrix[i, j] == matrix[i + 1, j] &&
                        matrix[i, j] == matrix[i + 1, j + 1])
                    {
                        equalsCount++;
                    }
                }
            }

            Console.WriteLine(equalsCount);
        }
    }
}
