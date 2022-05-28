using System;

namespace DrawingFigures7
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int emptySpacesCounter = n + 1;
            string emptySpaces = new String(' ', emptySpacesCounter);
            int rows = 0;
            int leftCounter = 1;
            int rightCounter = 1;
            bool treeLeft = true;

            for (int i = 1; i <= n; i++)
            {
                rows++;

                for (int j = 1; j <= rows; j++)
                {
                    if (j == 1 && rows == 1)
                    {
                        Console.Write(emptySpaces);
                        Console.WriteLine("|");
                        emptySpacesCounter -= 2;
                        emptySpaces = emptySpaces.Substring(0, emptySpacesCounter);
                    }

                    if (rows > 1)
                    {
                        Console.Write(emptySpaces);

                        for (int k = 1; k <= leftCounter; k++)
                        {
                            Console.Write("*");
                        }

                        Console.Write(" | ");

                        for (int l = 1; l <= rightCounter; l++)
                        {
                            if (l != rightCounter)
                            {
                                Console.Write("*");
                            }
                            else
                            {
                                Console.WriteLine("*");
                            }
                        }

                        leftCounter++;
                        rightCounter++;

                        emptySpacesCounter--;

                        if (emptySpacesCounter > -1)
                        {
                            emptySpaces = emptySpaces.Substring(0, emptySpacesCounter);
                        }
                        else
                        {
                            treeLeft = false;
                            break;
                        }
                    }
                }

                if (n == 1)
                {
                    Console.WriteLine("* | *");
                }

                if (!treeLeft)
                {
                    break;
                }
            }
        }
    }
}
