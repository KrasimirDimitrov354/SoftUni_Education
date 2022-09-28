using System;
using System.Collections.Generic;

namespace Stack_QueueExer8
{
    //Balanced Parentheses
    //Given a sequence consisting of parentheses, determine whether the expression is balanced.
    //A sequence of parentheses is balanced if every open parenthesis can be paired uniquely with a closing parenthesis that occurs after the former.
    //The interval between them must also be balanced. You will be given three types of parentheses: (, {, and [.
    //
    //{[()]} - This is a balanced parenthesis.
    //{[(])} - This is not a balanced parenthesis.
    //
    //Input
    //  •	Each input consists of a single line - the sequence of parentheses.
    //Output
    //  •	For each test case, print on a new line "YES" if the parentheses are balanced. Otherwise, print "NO". Do not print the quotes.
    //Constraints
    //  •	1 ≤ lens ≤ 1000, where the lens is the length of the sequence.
    //  •	Each character of the sequence will be one of {, }, (, ), [, ].
    //
    //Examples
    //Input             Output
    //{[()]}            YES
    //{[(])}            NO
    //{ {[[(())]]} }    YES

    class Program
    {
        private static bool CheckChars(char char1, char char2)
        {
            if (char1 == 32 && char2 == 32)
            {
                return true;
            }
            else if (char1 + 1 == char2 || char1 + 2 == char2)
            {
                return true;
            }

            return false;
        }

        static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Queue<char> queueOfChars = new Queue<char>(input);
                Stack<char> stackOfChars = new Stack<char>(input);

                bool isBalanced = true;

                while (queueOfChars.Count > 0)
                {
                    char queueChar = queueOfChars.Dequeue();
                    char nextInQueue = queueOfChars.Peek();

                    if (queueOfChars.Count <= (input.Length / 2) - 1 &&
                        stackOfChars.Count != input.Length)
                    {
                        break;
                    }
                    else
                    {
                        if (CheckChars(queueChar, nextInQueue))
                        {
                            queueOfChars.Dequeue();                           
                        }
                        else
                        {
                            char stackChar = stackOfChars.Pop();

                            if (CheckChars(queueChar, stackChar) == false)
                            {
                                isBalanced = false;
                                break;
                            }
                        }
                    }
                }

                if (isBalanced)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
        }
    }
}
