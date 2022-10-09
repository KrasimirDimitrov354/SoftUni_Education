using System;
using System.Linq;

namespace ConsoleApp8
{
    //Bombs - 90/100
    //You will be given a square matrix of integers. Each integer is separated by a single space, and each row is on a new line.
    //On the last line of input you will receive indexes - coordinates to several cells separated by a single space in the format {rowN,columnM}.
    //
    //On those cells there are bombs. You have to proceed with every bomb, one by one in the order they were given.
    //When a bomb explodes, it deals damage equal to its integer value to all the cells around it (in every direction and all diagonals).
    //
    //One bomb can't explode more than once. After it does, its value becomes 0.
    //When a cell’s value reaches 0 or below, it becomes inactive. Inactive cells can't explode.
    //
    //You must print the count of all active cells and their sum. Afterward, print the matrix with all of its cells (including the inactive ones).
    //
    //Input
    //  •	On the first line you are given the integer N – the size of the square matrix.
    //  •	The next N lines hold the values for every row – N numbers separated by a space.
    //  •	On the last line you will receive the coordinates of the cells with the bombs in the format described above.
    //Output
    //  •	On the first line you need to print the count of all active cells in the format: 
    //      "Alive cells: {aliveCells}"
    //  •	On the second line you need to print the sum of all active cells in the format: 
    //      "Sum: {sumOfCells}"
    //  •	At the end print the matrix. The cells must be separated by a single space.
    //Constraints
    //  •	The size of the matrix will be between [0…1000].
    //  •	The bomb coordinates will always be in the matrix.
    //  •	The bomb’s values will always be greater than 0.
    //  •	The integers of the matrix will be in the range [1…10000].
    //
    //Examples
    //Input         Output              Comments
    //4             Alive cells: 3      The bomb at coordinates {1,2} and with value 7 will explode first and reduce the values of the cells around.
    //8 3 2 5       Sum: 12             The bomb at coordinates {2,1} and with value 2 (initially 9, then 9 - 7) will explode next.
    //6 4 7 9       8 -4 -5 -2          The bomb at coordinates {2,0} and with value 7 (initially 9, then 9 - 2) will explode last.
    //9 9 3 6       -3 -3 0 2           The count of the active cells is 3 - {0,0}, {1,3} and {3,3}. Their sum is 12.
    //6 8 1 2       0 0 -4 -1
    //1,2 2,1 2,0   -3 -1 -1 2
    //
    //Input         Output
    //3             Alive cells: 3
    //7 8 4         Sum: 8
    //3 1 5         4 1 0
    //6 4 9         0 -3 -8
    //0,2 1,0 2,2   3 -8 0

    class Program
    {
        static bool RowIsValid(int row, int[,] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0))
            {
                return true;
            }

            return false;
        }

        static bool ColIsValid(int col, int[,] matrix)
        {
            if (col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }

        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] fieldWithBombs = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    fieldWithBombs[row, col] = currentRow[col];
                }
            }

            string[] bombCoordinates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombCoordinates.Length; i++)
            {
                int bombRow = int.Parse(bombCoordinates[i][0].ToString());
                int bombCol = int.Parse(bombCoordinates[i][2].ToString());

                int bombValue = fieldWithBombs[bombRow, bombCol];

                if (bombValue < 0)
                {
                    fieldWithBombs[bombRow, bombCol] = 0;
                }

                for (int currentRow = bombRow - 1; currentRow <= bombRow + 1; currentRow++)
                {
                    if (RowIsValid(currentRow, fieldWithBombs))
                    {
                        for (int currentCol = bombCol - 1; currentCol <= bombCol + 1; currentCol++)
                        {
                            if(ColIsValid(currentCol, fieldWithBombs))
                            {
                                if (fieldWithBombs[currentRow, currentCol] > 0)
                                {
                                    fieldWithBombs[currentRow, currentCol] -= bombValue;
                                }
                            }
                        }
                    }
                }
            }

            int activeCellsCount = 0;
            int activeCellsSum = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (fieldWithBombs[row, col] > 0)
                    {
                        activeCellsCount++;
                        activeCellsSum += fieldWithBombs[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {activeCellsCount}");
            Console.WriteLine($"Sum: {activeCellsSum}");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{fieldWithBombs[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
