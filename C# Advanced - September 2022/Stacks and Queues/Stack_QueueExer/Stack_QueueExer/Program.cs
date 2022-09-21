using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_QueueExer
{
    //Basic Stack Operations
    //
    //You will be given:
    //  -   an integer N representing the number of elements to push into the stack.
    //  -   an integer S representing the number of elements to pop from the stack.
    //  -   an integer X, an element that you should look for in the stack.
    //      If it’s found, print "true" on the console. If it isn't, print the smallest element currently present in the stack.
    //      If there are no elements in the sequence, print 0 on the console.
    //
    //Input
    //  •	On the first line, you will be given N, S, and X, separated by a single space
    //  •	On the next line, you will be given N number of integers
    //Output
    //  •	On a single line print either true if X is present in the stack, otherwise print the smallest element in the stack. If the stack is empty, print 0
    //
    //Examples
    //Input             Output      Comments
    //5 2 13            true        We have to push 5 elements. Then we pop 2 of them. Then we have to check whether 13 is present in the stack. Since it is we print true.
    //1 13 45 32 4
    //Input             Output
    //4 1 666           13
    //420 69 13 666	

    class Program
    {
        static void Main()
        {
            int[] variables = Console.ReadLine()
                .Split()
                .Select(n => int.Parse(n))
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(n => int.Parse(n))
                .ToArray();

            Stack<int> stackOfNums = new Stack<int>(numbers.Skip(0).Take(variables[0]));

            for (int i = 0; i < variables[1]; i++)
            {
                if (stackOfNums.Count > 0)
                {
                    stackOfNums.Pop();
                }
                else
                {
                    break;
                }               
            }

            if (stackOfNums.Contains(variables[2]))
            {
                Console.WriteLine("true");
            }
            else if (stackOfNums.Count > 0)
            {
                Console.WriteLine(stackOfNums.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
