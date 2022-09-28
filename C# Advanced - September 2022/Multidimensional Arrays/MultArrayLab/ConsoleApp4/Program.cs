using System;

namespace ConsoleApp4
{
    //Symbol in Matrix
    //Create a program that reads N - a number representing rows and columns of a matrix.
    //On the next N lines you will receive rows of the matrix. Each row consists of ASCII characters.
    //
    //After that you will receive a symbol. Find the first occurrence of that symbol in the matrix and print its position in the format: "({row}, {col})".
    //If there is no such symbol print an error message "{symbol} does not occur in the matrix".
    //
    //Examples
    //Input     Output      Input       Output
    //3         (2, 1)      4           4 does not occur in the matrix
    //ABC                   asdd
    //DEF                   xczc
    //X!@                   qwee
    //!                     qefw
    //                      4

    class Program
    {
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrixOfChars = new char[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrixSize; j++)
                {
                    matrixOfChars[i, j] = rowData[j];
                }
            }

            char symbolToFind = char.Parse(Console.ReadLine());
            bool isNotFound = true;

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (matrixOfChars[i, j] == symbolToFind)
                    {
                        Console.WriteLine($"({i}, {j})");
                        isNotFound = false;
                        break;
                    }
                }

                if (isNotFound == false)
                {
                    break;
                }
            }

            if (isNotFound)
            {
                Console.WriteLine($"{symbolToFind} does not occur in the matrix");
            }
        }
    }
}
