using System;

namespace DrawingFigures6
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int counterRows = 0;
            string emptySpace = new String(' ', input - 1);
            int spaceToRemove = input - 1;

            for (int i = 1; i <= input; i++)
            {
                counterRows++;

                for (int j = 1; j <= counterRows; j++)
                {                    
                    if (j == 1 && counterRows != input)
                    {
                        Console.Write(emptySpace);
                        spaceToRemove--;
                        emptySpace = emptySpace.Substring(0, spaceToRemove);                       
                    }                   

                    if (j != counterRows)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.WriteLine("*");
                    }
                }

                if (i == input)
                {
                    emptySpace = " ";
                }
            }

            for (int k = 1; k < input; k++)
            {
                counterRows = input - k;

                for (int l = 1; l <= counterRows; l++)
                {
                    if (l == 1)
                    {
                        Console.Write(emptySpace);
                        emptySpace += " ";
                    }

                    if (l != counterRows)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.WriteLine("*");
                    }
                }
            }
        }
    }
}
