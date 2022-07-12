using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        //Randomize Words
        //You will be given a string that will contain words separated by a single space. Randomize their order and print each word on a new line.
        //Examples
        //Input
        //Welcome to SoftUni and have fun learning programming
        //
        //Output
        //learning
        //Welcome
        //SoftUni
        //and
        //fun
        //programming
        //have
        //to
        //
        //Comments
        //The order of the words in the output will be different after each program execution.

        static void Main()
        {
            List<string> input = Console.ReadLine()
                .Split(' ')
                .ToList();

            Random rnd = new Random();

            while (input.Count != 0)
            {
                int currentSelection = rnd.Next(0, input.Count - 1);
                Console.WriteLine(input[currentSelection]);
                input.RemoveAt(currentSelection);
            }
        }
    }
}
