using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_QueueLab3
{
    //Simple Calculator
    //Create a simple calculator that can evaluate simple expressions with only addition and subtraction. There will not be any parentheses.
    //Solve the problem using a Stack.
    //Examples
    //Input                 Output
    //2 + 5 + 10 - 2 - 1	14
    //2 - 2 + 5	            5

    class Program
    {
        static void Main()
        {
            string[] expression = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Stack<string> stack = new Stack<string>(expression.Reverse());
            int result = 0;

            while (stack.Count > 1)
            {
                int num1 = int.Parse(stack.Pop());
                string symbol = stack.Pop();
                int num2 = int.Parse(stack.Pop());

                switch (symbol)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                }

                stack.Push(result.ToString());
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
