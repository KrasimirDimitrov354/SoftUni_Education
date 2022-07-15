using System;

namespace ConsoleApp6
{
    class Program
    {
        //Balanced Brackets
        //You will receive n lines. On those lines you will receive one of the following:
        //  •	Opening bracket – “(“,
        //  •	Closing bracket – “)” or
        //  •	Random string
        //Your task is to find out if the brackets are balanced. That means after every closing bracket should follow an opening one.
        //Nested parentheses are not valid, and if two consecutive opening brackets exist the expression should be marked as unbalanced.
        //Input
        //  •	On the first line you will receive n – the number of lines, which will follow
        //  •	On the next n lines you will receive "(", ")" or another string
        //Output
        //You have to print "BALANCED" if the parentheses are balanced and "UNBALANCED" otherwise.
        //Constraints
        //  •	n will be in the interval [1…20]
        //  •	The length of the stings will be between [1…100] characters
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
            byte linesCount = byte.Parse(Console.ReadLine());

            char leftParentheses = ' ';
            char rightParentheses = ' ';
            byte counter = 1;
            bool isBalanced = true;

            for (int i = 0; i < linesCount; i++)
            {
                string input = Console.ReadLine();

                if (input.Length == 1)
                {
                    char symbol = char.Parse(input);

                    if (symbol == '(' || symbol == ')')
                    {
                        switch (counter)
                        {
                            case 1:
                                leftParentheses = symbol;
                                counter++;
                                break;
                            case 2:
                                rightParentheses = symbol;
                                counter++;
                                break;
                            case 3:
                                leftParentheses = symbol;
                                rightParentheses = ' ';
                                counter++;
                                break;
                            case 4:
                                rightParentheses = symbol;
                                counter = 1;
                                break;
                        }

                        if (leftParentheses == ')' || rightParentheses == '(')
                        {
                            isBalanced = false;
                        }
                    }                   
                }
            }

            if (leftParentheses == ' ' || rightParentheses == ' ')
            {
                Console.WriteLine("UNBALANCED");
            }
            else
            {
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
}
