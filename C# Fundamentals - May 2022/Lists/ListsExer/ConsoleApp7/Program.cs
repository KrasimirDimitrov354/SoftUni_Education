using System;
using System.Collections.Generic;

namespace ConsoleApp7
{
    class Program
    {
        //Append Arrays - 75/100
        //Create a program to append several arrays of numbers one after another.
        //  •	Arrays are separated by '|'
        //  •	Their values are separated by spaces (' ', one or several)
        //  •	Take all arrays starting from the rightmost and going to the left and place them in a new array in that order
        //Examples
        //Input                     Output
        //1 2 3 |4 5 6 |  7  8	    7 8 4 5 6 1 2 3
        //7 | 4  5|1 0| 2 5 |3	    3 2 5 1 0 4 5 7
        //1| 4 5 6 7  |  8 9	    8 9 4 5 6 7 1

        private static bool SymbolIsNotNumber(char symbol)
        {
            if (symbol == '|' || symbol == ' ')
            {
                return true;
            }

            return false;
        }

        private static bool SymbolIsSeparator(char symbol)
        {
            if (symbol == '|')
            {
                return true;
            }

            return false;
        }

        static void Main()
        {
            string input = Console.ReadLine();
            List<char> numbers = new List<char>();

            byte counter = 0;
            bool separateArray = false;

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (SymbolIsNotNumber(symbol))
                {
                    if (SymbolIsSeparator(symbol))
                    {
                        separateArray = true;
                    }                    
                }
                else
                {
                    if (separateArray)
                    {
                        numbers.Insert(0, symbol);
                        counter = 1;
                        separateArray = false;
                    }
                    else
                    {
                        numbers.Insert(counter, symbol);
                        counter++;
                    }
                }
            }

            Console.WriteLine(string.Join(' ', numbers));           
        }
    }
}
