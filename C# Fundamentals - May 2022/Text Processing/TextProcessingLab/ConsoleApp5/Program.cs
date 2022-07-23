using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    //Digits, Letters and Other
    //Create a program that receives a single string and on the first line prints all the digits, on the second – all the letters, and on the third – all the other characters.
    //There will always be at least one digit, one letter and one other character.
    //Examples
    //Input                 Output
    //Agd#53Dfg^&4F53	    53453
    //                      AgdDfgF
    //                      #^&
    //
    //Input                 Output
    //So%f94t34U*n&i></37	943437
    //                      SoftUni
    //                      %*&></

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            List<List<char>> listOfCharacters = new List<List<char>>();

            for (int i = 0; i < 3; i++)
            {
                listOfCharacters.Add(new List<char>());
            }

            for (int i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];

                if (currentSymbol >= 48 && currentSymbol <= 57)
                {
                    listOfCharacters[0].Add(currentSymbol);
                }
                else if ((currentSymbol >= 65 && currentSymbol <= 90) || 
                    (currentSymbol >= 97 && currentSymbol <= 122))
                {
                    listOfCharacters[1].Add(currentSymbol);
                }
                else
                {
                    listOfCharacters[2].Add(currentSymbol);
                }
            }

            foreach (List<char> characters in listOfCharacters)
            {
                Console.WriteLine(string.Concat(characters));
            }
        }
    }
}
