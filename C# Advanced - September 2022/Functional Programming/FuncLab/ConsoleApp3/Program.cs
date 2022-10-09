using System;
using System.Linq;

namespace ConsoleApp3
{
    //Count Uppercase Words
    //Create a program that reads a line of text from the console. Print all the words that start with an uppercase letter in the same order you've received them in the text.
    //Examples
    //Input
    //  The following example shows how to use Function
    //Output
    //  The
    //  Function
    //
    //Input
    //  Write a program that reads one line of text from console.
    //  Print count of words that start with Uppercase, after that print all those words in the same order like you find them in text.
    //Output
    //  Write
    //  Print
    //  Uppercase,

    class Program
    {
        static void Main()
        {
            Func<string, bool> isUpper = w => Char.IsUpper(w[0]);

            Console.Write(String.Join('\n', Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(w => isUpper(w))
                .ToArray()));
        }
    }
}
