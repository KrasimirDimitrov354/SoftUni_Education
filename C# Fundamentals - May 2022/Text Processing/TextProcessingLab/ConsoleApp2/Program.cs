using System;
using System.Linq;

namespace ConsoleApp2
{
    //Repeat Strings
    //Create a program that reads an array of strings. Each string is repeated n times, where n is the length of the string. Print the concatenated string.
    //Examples
    //Input         Output
    //hi abc add    hihiabcabcabcaddaddadd
    //work          workworkworkwork
    //ball          ballballballball

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split(' ')
                .ToArray();

            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                string currentString = input[i];

                for (int j = 0; j < currentString.Length; j++)
                {
                    output = string.Concat(output, currentString);
                }              
            }

            Console.WriteLine(output);
        }
    }
}
