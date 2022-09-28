using System;
using System.Linq;

namespace ConsoleApp5
{
    //Snake Moves
    //You have a task to visualize the snake’s path in a square form. A snake is represented by a string. The isle is a rectangular matrix of size NxM.
    //A snake starts going down from the top-left corner and slithers its way down.
    //The first cell is filled with the first symbol of the snake, the second cell is filled with the second symbol, etc.
    //
    //The snake is as long as it takes to fill the stairs – if you reach the end of the string representing the snake, start again at the beginning.
    //
    //You must print the matrix after you fill it with the snake’s path.
    //Input
    //  •	On the first line you’ll receive the dimensions of the stairs in the format: "{rows} {columns}".
    //  •	On the second line you’ll receive the string representing the snake.
    //Output
    //  •	The output must be lines equal to the number of rows.
    //  •	Each line must contain a string representing the respective row of the matrix.
    //Constraints
    //  •	The dimensions of the matrix will be integers in the range [1 … 12].
    //  •	The snake will be a string with length in the range [1 … 20] and will not contain any whitespace characters.
    //Examples
    //Input     Output
    //5 6       SoftUn
    //SoftUni   UtfoSi
    //          niSoft
    //          foSinU
    //          tUniSo

    class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ')
                .Select(d => int.Parse(d))
                .ToArray();

            int rows = dimensions[0];
            int columns = dimensions[1];

            char[,] matrix = new char[rows, columns];

            string snake = Console.ReadLine();
            int snakeIndex = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string currentRow = string.Empty;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (snakeIndex > snake.Length - 1)
                    {
                        snakeIndex = 0;
                    }

                    matrix[i, j] = snake[snakeIndex];
                    snakeIndex++;

                    currentRow += matrix[i, j];
                }

                if (i % 2 != 0)
                {
                    char[] reversed = currentRow.ToCharArray();
                    Array.Reverse(reversed);
                    Console.WriteLine(reversed);
                }
                else
                {
                    Console.WriteLine(currentRow);
                }               
            }
        }
    }
}
