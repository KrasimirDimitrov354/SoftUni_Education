using System;

namespace ConsoleApp3
{
    class Program
    {
        //Characters in Range
        //Create a method that receives two characters and prints all the characters between them on a single line.
        //NOTE: If the second letter's ASCII value is less than that of the first one then the two initial letters should be swapped.
        //Examples
        //Input     Output
        //a         b c
        //d
        //Input     Output
        //#         $ % & ' ( ) * + , - . / 0 1 2 3 4 5 6 7 8 9
        //:
        //Input     Output
        //C         $ % & ' ( ) * + , - . / 0 1 2 3 4 5 6 7 8 9 : ; < = > ? @ A B
        //#

        private static void PrintBetween(char firstSymbol, char secondSymbol)
        {
            char temp = ' ';

            if (firstSymbol.CompareTo(secondSymbol) > 0)
            {
                temp = secondSymbol;
                secondSymbol = firstSymbol;
                firstSymbol = temp;
            }

            for (int i = (int)firstSymbol + 1; i < (int)secondSymbol; i++)
            {
                Console.Write($"{(char)i} ");
            }
            
            
        }

        static void Main()
        {
            char firstSymbol = char.Parse(Console.ReadLine());
            char secondSymbol = char.Parse(Console.ReadLine());
            PrintBetween(firstSymbol, secondSymbol);
        }
    }
}
