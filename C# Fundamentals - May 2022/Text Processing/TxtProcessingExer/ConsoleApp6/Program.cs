using System;
using System.Text;

namespace ConsoleApp6
{
    //Replace Repeating Chars
    //Create a program that reads a string from the console and replaces any sequence of the same letters with a single corresponding letter.
    //Examples
    //Input                     Output
    //aaaaabbbbbcdddeeeedssaa   abcdedsa
    //qqqwerqwecccwd            qwerqwecwd

    class Program
    {
        static void Main()
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                for (int j = i + 1; j < input.Length; j++)
                {
                    char nextChar = input[j];

                    if (currentChar == nextChar)
                    {
                        input.Remove(j, 1);
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(input);
        }
    }
}
