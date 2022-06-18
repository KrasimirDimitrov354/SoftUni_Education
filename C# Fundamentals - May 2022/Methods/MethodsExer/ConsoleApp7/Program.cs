using System;

namespace ConsoleApp7
{
    class Program
    {
        //NxN Matrix
        //Create a method that receives a single integer n and prints an NxN matrix using this number as a filler.
        //Examples
        //Input     Output  Input       Output
        //3	        3 3 3   7           7 7 7 7 7 7 7
        //          3 3 3               7 7 7 7 7 7 7
        //          3 3 3               7 7 7 7 7 7 7
        //                              7 7 7 7 7 7 7
        //                              7 7 7 7 7 7 7
        //                              7 7 7 7 7 7 7
        //                              7 7 7 7 7 7 7
        //Input     Output
        //2	        2 2
        //          2 2

        private static void PrintMatrix(int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j != size - 1)
                    {
                        Console.Write($"{size} ");
                    }
                    else
                    {
                        Console.WriteLine(size);
                    }
                }
            }
        }

        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            PrintMatrix(matrixSize);
        }
    }
}
