using System;
using System.Linq;

namespace ConsoleApp6
{
    //Jagged Array Manipulator
    //Create a program that populates, analyzes and manipulates the elements of a matrix with an unequal length of its rows.
    //
    //First you will receive an integer N equal to the number of rows in your matrix.
    //On the next N lines you will receive sequences of integers separated by a single space. Each sequence is a row in the matrix.
    //
    //Start analyzing the matrix after populating it. If a row and the one below it have equal length, multiply each element in the rows by 2. Otherwise - divide them by 2.
    //
    //Then you will receive commands. There are three possible commands:
    //  •	"Add {row} {column} {value}" - add {value} to the element at the given indexes, if they are valid.
    //  •	"Subtract {row} {column} {value}" - subtract {value} from the element at the given indexes, if they are valid.
    //  •	"End" - print the final state of the matrix (all elements separated by a single space) and stop the program.
    //
    //Input
    //  •	On the first line you will receive the number of rows of the matrix - integer N.
    //  •	On the next N lines you will receive each row - sequence of integers separated by a single space.
    //  •	{value} will always be an integer number.
    //  •	You will be receiving commands until the "End" command.
    //Output
    //  •	The output should be printed on the console and it should consist of N lines.
    //  •	Each line should contain a string representing the respective row of the final matrix - elements separated by a single space.
    //Constraints
    //  •	The number of rows N of the matrix will be an integer in the range [2 … 12].
    //  •	The input will always follow the format above.
    //
    //Examples
    //Input         Output      Input               Output
    //5             20 40 60    5                   30 40 60
    //10 20 30      1 2 3       10 20 30            1 2 3
    //1 2 3         2           1 2 3               2
    //2             2           2                   -8
    //2             5 5         2                   5 5
    //10 10                     10 10
    //End                       Add 0 10 10
    //                          Add 0 0 10
    //                          Subtract -3 0 10
    //                          Subtract 3 0 10
    //                          End

    class Program
    {
        private static void Multiply(int[] row)
        {
            for (int i = 0; i < row.Length; i++)
            {
                row[i] *= 2;
            }
        }

        private static void Divide(int[] row)
        {
            for (int i = 0; i < row.Length; i++)
            {
                row[i] /= 2;
            }
        }

        private static bool CoordinatesAreValid(int rowCoordinates, int columnCoordinates, int[][] matrix)
        {
            if (rowCoordinates >= 0 && rowCoordinates < matrix.Length)
            {
                if (columnCoordinates >= 0 && columnCoordinates < matrix[rowCoordinates].Length)
                {
                    return true;
                }
            }

            return false;
        }

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                int[] nums = Console.ReadLine()
                    .Split()
                    .Select(n => int.Parse(n))
                    .ToArray();

                matrix[i] = new int[nums.Length];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = nums[j];
                }
            }

            for (int i = 0; i < matrix.Length - 1; i++)
            {
                int[] currentRow = matrix[i];
                int[] nextRow = matrix[i + 1];

                if (currentRow.Length == nextRow.Length)
                {
                    Multiply(matrix[i]);
                    Multiply(matrix[i + 1]);
                }
                else
                {
                    Divide(matrix[i]);
                    Divide(matrix[i + 1]);
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "End")
                {
                    foreach (int[] row in matrix)
                    {
                        Console.WriteLine(String.Join(' ', row));
                    }

                    break;
                }
                else
                {
                    int rowCoordinates = int.Parse(command[1]);
                    int columnCoordinates = int.Parse(command[2]);
                    int value = int.Parse(command[3]);

                    if (CoordinatesAreValid(rowCoordinates, columnCoordinates, matrix))
                    {
                        switch (command[0])
                        {
                            case "Add":
                                matrix[rowCoordinates][columnCoordinates] += value;
                                break;
                            case "Subtract":
                                matrix[rowCoordinates][columnCoordinates] -= value;
                                break;
                        }
                    }
                }
            }
        }
    }
}
