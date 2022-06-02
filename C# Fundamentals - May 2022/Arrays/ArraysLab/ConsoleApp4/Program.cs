using System;

namespace ConsoleApp4
{
    class Program
    {
        //Reverse Array of Strings
        //Create a program that reads an array of strings, reverses it, and prints its elements.
        //The input consists of a sequence of space-separated Strings. Print the output on a single line (space separated).
        //Examples
        //Input         Output
        //a b c d e     e d c b a
        //-1 hi ho w    w ho hi -1

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            for (int i = input.Length - 1; i >= 0; i--)
            {
                Console.Write($"{input[i]} ");
            }
        }
    }
}
