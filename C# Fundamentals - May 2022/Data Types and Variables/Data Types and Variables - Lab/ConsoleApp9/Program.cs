using System;

namespace ConsoleApp9
{
    class Program
    {
        //9.	Chars to String
        //Create a program that reads 3 lines of input. On each line, you get a single character. Combine all the characters into one string and print it on the console.
        //Examples
        //Input     Output
        //a
        //b
        //c         abc
        //Input     Output
        //%
        //2
        //o	        %2o
        //Input     Output
        //1
        //5
        //p	        15p

        static void Main()
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char third = char.Parse(Console.ReadLine());

            string result = first.ToString() + second.ToString() + third.ToString();

            Console.WriteLine(result);
        }
    }
}
