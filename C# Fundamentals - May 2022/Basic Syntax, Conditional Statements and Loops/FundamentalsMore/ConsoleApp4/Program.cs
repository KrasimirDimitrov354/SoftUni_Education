using System;

namespace ConsoleApp4
{
    class Program
    {
        //4.	Reverse String
        //Create a program which reverses a string and print it on the console.
        //Examples
        //Input     Output
        //Hello     olleH
        //SoftUni   inUtfoS
        //1234	    4321

        static void Main()
        {
            string input = Console.ReadLine();
            string reverse = "";

            for (int i = 1; i <= input.Length; i++)
            {
                char symbol = input[input.Length - i];
                reverse += symbol;
            }

            Console.WriteLine(reverse);
        }
    }
}
