using System;
using System.Collections.Generic;

namespace Stack_QueueLab
{
    //Reverse Strings
    //Create a program that:
    //  •	Reads an input string
    //  •	Reverses it using a Stack<T>
    //  •	Prints the result back at the terminal
    //
    //Examples
    //Input                 Output
    //I Love C#	            #C evoL I
    //Stacks and Queues     seueuQ dna skcatS

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                stack.Push(currentChar);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
