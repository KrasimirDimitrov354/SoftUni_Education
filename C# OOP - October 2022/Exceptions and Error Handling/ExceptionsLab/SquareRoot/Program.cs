using System;

namespace SquareRoot
{
    //Square Root
    //Write a program that reads an integer number and calculates and prints its square root.
    //  •	If the number is negative, print "Invalid number."
    //  •	In all cases finally, print "Goodbye."
    //Use try-catch-finally.
    //
    //Examples
    //Input     Output
    //9         3
    //          Goodbye.
    //
    //Input     Output
    //-1        Invalid number.
    //          Goodbye.

    class Program
    {
        static void Main()
        {
            try
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 0)
                {
                    throw new ArgumentException();
                }

                Console.WriteLine(Math.Sqrt(number));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
