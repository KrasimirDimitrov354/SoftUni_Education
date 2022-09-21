using System;
using System.Collections.Generic;

namespace Stack_QueueLab4
{
    //Matching Brackets
    //We are given an arithmetic expression with brackets. Scan through the string and extract each sub-expression.
    //Print the result back at the terminal.
    //
    //Examples
    //Input                                 Output
    //1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5	(2 + 3)
    //                                      (3 + 1)
    //                                      (2 - (2 + 3) * 4 / (3 + 1))
    //Input                                 Output
    //(2 + 3) - (2 + 3)                     (2 + 3)
    //                                      (2 + 3)

    class Program
    {
        static void Main()
        {
            string expression = Console.ReadLine();

            Stack<int> positions = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                char symbol = expression[i];

                switch (symbol)
                {
                    case '(':
                        positions.Push(i);
                        break;
                    case ')':
                        int startIndex = positions.Pop();
                        string subExpression = expression.Substring(startIndex, i - startIndex + 1);

                        Console.WriteLine(subExpression);
                        break;
                }
            }
        }
    }
}
