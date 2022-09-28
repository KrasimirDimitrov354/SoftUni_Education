using System;
using System.Linq;

namespace ConsoleApp4
{
    //Matrix Shuffling
    //Write a program that reads a string matrix from the console and performs certain operations with its elements.
    //User input is provided in a similar way as in the problems above – first, you read the dimensions and then the data.
    //
    //The program will receive commands in the format: "swap row1 col1 row2 col2" where row1, col1, row2, col2 are coordinates in the matrix.
    //The values at the given coordinates must be swapped (cell[row1, col1] with cell[row2, col2]) and the matrix must be printed at each step.
    //
    //For a command to be valid, it must start with the "swap" keyword along with four valid coordinates.
    //The command is not valid if it:
    //  - doesn't contain the keyword "swap".
    //  - has fewer or more coordinates entered.
    //  - the given coordinates do not exist.
    //If the command is invalid, print "Invalid input!" and move on to the next command.
    //
    //The program must finish when the string "END" is entered.
    //
    //Examples
    //Input             Output
    //2 3               5 2 3
    //1 2 3             4 1 6
    //4 5 6             Invalid input!
    //swap 0 0 1 1      5 4 3
    //swap 10 9 8 7     2 1 6
    //swap 0 1 1 0
    //END
    //
    //Input             Output
    //1 2               Invalid input!
    //Hello World       World Hello
    //0 0 0 1           Hello World
    //swap 0 0 0 1
    //swap 0 1 0 0
    //END

    class Program
    {
        private static bool CoordinatesAreValid(int rowCoordinates, int columnCoordinates, int rows, int columns)
        {
            if (rowCoordinates >= 0 && columnCoordinates >= 0)
            {
                if (rowCoordinates < rows && columnCoordinates < columns)
                {
                    return true;
                }             
            }

            return false;
        }

        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ')
                .Select(d => int.Parse(d))
                .ToArray();

            int rows = dimensions[0];
            int columns = dimensions[1];

            string[,] matrix = new string[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                string[] row = Console.ReadLine().Split(' ');

                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "END")
                {
                    break;
                }
                else
                {
                    bool firstCondition = command[0] == "swap";
                    bool secondCondition = command.Length == 5;

                    if (firstCondition && secondCondition)
                    {
                        int[] firstCoordinates = new int[] { int.Parse(command[1]), int.Parse(command[2]) };
                        int[] secondCoordinates = new int[] { int.Parse(command[3]), int.Parse(command[4]) };

                        if (CoordinatesAreValid(firstCoordinates[0], firstCoordinates[1], rows, columns) &&
                            CoordinatesAreValid(secondCoordinates[0], secondCoordinates[1], rows, columns))
                        {
                            string temp = matrix[firstCoordinates[0], firstCoordinates[1]];
                            matrix[firstCoordinates[0], firstCoordinates[1]] = matrix[secondCoordinates[0], secondCoordinates[1]];
                            matrix[secondCoordinates[0], secondCoordinates[1]] = temp;

                            for (int i = 0; i < matrix.GetLength(0); i++)
                            {
                                for (int j = 0; j < matrix.GetLength(1); j++)
                                {
                                    Console.Write($"{matrix[i, j]} ");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
            }
        }
    }
}
