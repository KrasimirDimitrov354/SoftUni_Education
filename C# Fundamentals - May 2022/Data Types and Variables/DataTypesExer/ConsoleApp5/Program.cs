using System;

namespace ConsoleApp5
{
    class Program
    {
        //5.	Print Part of the ASCII Table
        //Write a program that prints part of the ASCII table of characters at the console.
        //On the first line of input, you will receive the char index you should start with, and on the second line - the index of the last character you should print.
        //Examples
        //Input     Output
        //60        < = > ? @ A
        //65
        //Input     Output
        //35        # $ % & ' ( ) * + , - . / 0 1
        //49

        static void Main()
        {
            int asciiStart = int.Parse(Console.ReadLine());
            int asciiEnd = int.Parse(Console.ReadLine());

            for (int i = asciiStart; i <= asciiEnd; i++)
            {
                char asciiCharacter = (char)i;
                Console.Write($"{asciiCharacter} ");
            }
        }
    }
}
