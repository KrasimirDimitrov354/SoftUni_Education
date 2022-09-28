using System;

namespace ConsoleApp7
{
    //Pascal Triangle
    //In row 0 (the topmost row), there is a unique non-zero entry 1.
    //Each entry of each subsequent row is constructed by adding the number above and to the left with the number above and to the right, treating blank entries as 0.
    //
    //For example, the initial number in the first (or any other) row is 1 (the sum of 0 and 1).
    //The numbers 1 and 3 in the third row are added to produce the number 4 in the fourth row.
    //If you want more info about Pascal’s triangle here.
    //Print each row element separated with whitespace.
    //Examples
    //Input
    //  4
    //Output
    //  1 
    //  1 1 
    //  1 2 1 
    //  1 3 3 1
    //
    //Input
    //  13
    //Output
    //  1 
    //  1 1 
    //  1 2 1 
    //  1 3 3 1 
    //  1 4 6 4 1 
    //  1 5 10 10 5 1 
    //  1 6 15 20 15 6 1 
    //  1 7 21 35 35 21 7 1 
    //  1 8 28 56 70 56 28 8 1 
    //  1 9 36 84 126 126 84 36 9 1 
    //  1 10 45 120 210 252 210 120 45 10 1 
    //  1 11 55 165 330 462 462 330 165 55 11 1 
    //  1 12 66 220 495 792 924 792 495 220 66 12 1 

    class Program
    {
        static void Main()
        {
            int triangleSize = int.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[triangleSize][];

            for (int i = 0; i < pascalTriangle.Length; i++)
            {
                pascalTriangle[i] = new long[i + 1];

                if (i == 0)
                {
                    pascalTriangle[i][0] = 1;
                }
                else
                {
                    for (int j = 0; j < pascalTriangle[i].Length; j++)
                    {
                        long elementAbove = 0;
                        long elementToTheLeft = 0;

                        if (j < pascalTriangle[i - 1].Length)
                        {
                            elementAbove = pascalTriangle[i - 1][j];
                        }

                        if (j - 1 >= 0 )
                        {
                            elementToTheLeft = pascalTriangle[i - 1][j - 1];
                        }

                        pascalTriangle[i][j] = elementAbove + elementToTheLeft;
                    }
                }

                Console.WriteLine(String.Join(' ', pascalTriangle[i]));
            }
        }
    }
}
