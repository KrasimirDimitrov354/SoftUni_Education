using System;

namespace ConsoleApp4
{
    //Caesar Cipher
    //Create a program that returns an encrypted version of the same text. Encrypt the text by shifting each character with three positions forward.
    //For example, A would be replaced by D, B would become E, and so on. Print the encrypted text.
    //Examples
    //Input                     Output
    //Programming is cool!	    Surjudpplqj#lv#frro$
    //One year has 365 days.    Rqh#|hdu#kdv#698#gd|v1

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                currentChar += (char)3;
                Console.Write(currentChar);
            }
        }
    }
}
