using System;
using System.Linq;

namespace ConsoleApp6
{
    //Jagged-Array Modification
    //Create a program that reads a matrix from the console.
    //On the first line you will get N - matrix rows. On the next N lines you will get elements for each column separated with space.
    //
    //After that you will be receiving commands in the following format:
    //  •	Add {row} {col} {value} – Increase the number at the given coordinates with the value.
    //  •	Subtract {row} {col} {value} – Decrease the number at the given coordinates by the value.
    //
    //Coordinates might be invalid. You should print "Invalid coordinates" if they are. When you receive "END" you should print the matrix and stop the program.
    //
    //Examples
    //Input             Output
    //3                 6 2 3
    //1 2 3             4 3 6
    //4 5 6             7 8 9
    //7 8 9
    //Add 0 0 5
    //Subtract 1 1 2
    //END
    //	
    //Input                 Output
    //4                     Invalid coordinates
    //1 2 3 4               Invalid coordinates
    //5 6 7 8               -41 2 3 4
    //8 7 6 5               5 6 7 8
    //4 3 2 1               8 7 6 5
    //Add 4 4 100           4 3 2 101
    //Add 3 3 100
    //Subtract -1 -1 42
    //Subtract 0 0 42
    //END

    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedMatrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] row = Console.ReadLine()
                    .Split()
                    .Select(c => int.Parse(c))
                    .ToArray();

                jaggedMatrix[i] = row;
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "END")
                {
                    foreach (int[] row in jaggedMatrix)
                    {
                        Console.WriteLine(String.Join(' ', row));
                    }

                    break;
                }
                else
                {
                    int row = int.Parse(command[1]);
                    int column = int.Parse(command[2]);
                    int value = int.Parse(command[3]);

                    if (row < 0 || row > jaggedMatrix.Length - 1 ||
                        column < 0 || column > jaggedMatrix[row].Length)
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                    else
                    {
                        switch (command[0])
                        {
                            case "Add":
                                jaggedMatrix[row][column] += value;
                                break;
                            case "Subtract":
                                jaggedMatrix[row][column] -= value;
                                break;
                        }
                    }
                }
            }
        }
    }
}
