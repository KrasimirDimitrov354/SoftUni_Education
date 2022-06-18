using System;

namespace ConsoleApp2
{
    class Program
    {
        //Vowels Count
        //Create a method that receives a single string and prints out the number of vowels contained in it.
        //Examples
        //Input     Output
        //SoftUni	3
        //Cats	    1
        //JS	    0

        private static int CountVowels(string input)
        {
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];
                bool firstCondition = currentSymbol == 'a' || currentSymbol == 'e' || currentSymbol == 'i'
                    || currentSymbol == 'o' || currentSymbol == 'u' || currentSymbol == 'y';
                bool secondCondition = currentSymbol == 'A' || currentSymbol == 'E' || currentSymbol == 'I'
                    || currentSymbol == 'O' || currentSymbol == 'U' || currentSymbol == 'Y';

                if (firstCondition || secondCondition)
                {
                    count++;
                }
            }

            return count;
        }

        static void Main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(CountVowels(input));
        }
    }
}
