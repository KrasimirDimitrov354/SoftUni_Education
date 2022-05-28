using System;

namespace ConsoleApp6
{
    class Program
    {
        //        6.	Reversed Chars
        //Create a program that takes 3 lines of characters and prints them in reversed order with a space between them.
        //Examples
        //Input   Output
        //A
        //B
        //C       C B A
        //Input   Output
        //1
        //L
        //&	      & L 1

        static void Main()
        {
            string firstLine = Console.ReadLine();
            string secondLine = Console.ReadLine();
            string thirdLine = Console.ReadLine();

            Console.WriteLine($"{thirdLine} {secondLine} {firstLine}");
        }
    }
}
