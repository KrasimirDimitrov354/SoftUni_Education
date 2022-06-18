using System;

namespace ConsoleApp4
{
    class Program
    {
        //Printing Triangle
        //Create a method for printing triangles as shown below.
        //Examples
        //Input     Output
        //3	        1
        //          1 2
        //          1 2 3
        //          1 2
        //          1
        //Input     Output
        //2	        1
        //          1 2
        //          1

        private static void CreateTriangle(int size)
        {
            int totalSize = 1 + ((size - 1) * 2);

            for (int i = 1; i <= totalSize; i++)
            {
                if (i <= size)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        if (j != i)
                        {
                            Console.Write($"{j} ");
                        }
                        else
                        {
                            Console.WriteLine(j);
                        }
                    }
                }
                else
                {
                    for (int k = 1; k <= totalSize - i + 1; k++)
                    {
                        if (k != totalSize - i + 1)
                        {
                            Console.Write($"{k} ");
                        }
                        else
                        {
                            Console.WriteLine(k);
                        }
                    }
                }
            }
        }

        static void Main()
        {
            int triangleSize = int.Parse(Console.ReadLine());
            CreateTriangle(triangleSize);
        }
    }
}
