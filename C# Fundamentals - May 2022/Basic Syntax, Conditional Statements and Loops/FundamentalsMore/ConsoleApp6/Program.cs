using System;

namespace ConsoleApp6
{
    class Program
    {
        //Problem 1.	X
        //Write a program, which prints an X figure with height n.
        //N will be an odd number in the range[3…99].

        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int emptySpaceInner = height - 2;
            int emptySpaceOuter = 0;
            string outerSpaces = "";
            string innerSpaces = "";
            bool pastTheMiddle = false;

            for (int i = 1; i <= height; i++)
            {
                outerSpaces = new String(' ', emptySpaceOuter);
                innerSpaces = new String(' ', emptySpaceInner);

                if (emptySpaceInner == 0)
                {
                    Console.Write(outerSpaces);
                    Console.Write('x');
                    Console.WriteLine(outerSpaces);
                    pastTheMiddle = true;
                    emptySpaceInner++;
                    emptySpaceOuter--;
                }
                else
                {
                    Console.Write(outerSpaces);
                    Console.Write('x');
                    Console.Write(innerSpaces);
                    Console.Write('x');
                    Console.WriteLine(outerSpaces);

                    if (pastTheMiddle)
                    {
                        emptySpaceInner += 2;
                        emptySpaceOuter--;
                    }
                    else
                    {
                        emptySpaceInner -= 2;
                        emptySpaceOuter++;

                        if (emptySpaceInner < 0)
                        {
                            emptySpaceInner = 0;
                        }
                    }
                }
            }
        }
    }
}
