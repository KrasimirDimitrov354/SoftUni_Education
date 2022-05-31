using System;

namespace ConsoleApp6
{
    class Program
    {
        //6. Balanced Brackets
        //You will receive n lines. On those lines you will receive one of the following:
        //•	Opening bracket – “(“,
        //•	Closing bracket – “)” or
        //•	Random string
        //Your task is to find out if the brackets are balanced. That means after every closing bracket should follow an opening one.
        //Nested parentheses are not valid, and if two consecutive opening brackets exist the expression should be marked as unbalanced.
        //Input
        //•	On the first line you will receive n – the number of lines, which will follow
        //•	On the next n lines you will receive "(", ")" or another string
        //Output
        //You have to print "BALANCED" if the parentheses are balanced and "UNBALANCED" otherwise.
        //Constraints
        //•	n will be in the interval [1…20]
        //•	The length of the stings will be between [1…100] characters
        //Examples
        //Input     Output      Input       Output
        //8         BALANCED    6           UNBALANCED
        //(                     12 *
        //5 + 10                )
        //)                     10 + 2 -
        //* 2 +                 (
        //(                     5 + 10
        //5                     )
        //)
        //-12

        static void Main()
        {
            byte n = byte.Parse(Console.ReadLine());
            byte counterTwoConsecutive = 0;
            byte counterLeft = 0;
            byte counterRight = 0;
            bool isBalanced = false;

            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();

                if (input.Length > 1)
                {
                    for (int j = 0; j < input.Length; j++)
                    {
                        char symbol = input[j];

                        if (symbol == '(')
                        {
                            counterTwoConsecutive++;
                        }
                        else if (symbol == ')')
                        {
                            counterTwoConsecutive--;
                        }

                        if (counterTwoConsecutive == 2)
                        {
                            isBalanced = false;
                        }

                    }
                }
                else
                {
                    bool isBracket = input == "(" || input == ")";

                    if (isBracket)
                    {
                        switch (input)
                        {
                            case "(":
                                counterLeft++;
                                break;
                            case ")":
                                counterRight++;
                                break;
                        }

                        if (counterLeft == counterRight)
                        {
                            isBalanced = true;
                        }
                        else
                        {
                            isBalanced = false;
                        }
                    }
                }     
            }

            if (isBalanced)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
