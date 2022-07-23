using System;
using System.Linq;

namespace ConsoleApp2
{
    //Character Multiplier
    //Create a method that takes two strings as arguments and returns the sum of their character codes multiplied.
    //I.e. multiply str1[0] with str2[0] and add to the total sum, then continue with the next two characters.
    //If one of the strings is longer than the other, add the remaining character codes to the total sum without multiplication.
    //Examples
    //Input             Output
    //Peter George	    52114
    //123 522	        7647
    //a aaaa	        9700

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            string str1 = string.Empty;
            string str2 = string.Empty;
            int result = 0;

            if (input[0].Length >= input[1].Length)
            {
                str1 = input[0];
                str2 = input[1];
            }
            else
            {
                str1 = input[1];
                str2 = input[0];
            }

            for (int i = 0; i < str1.Length; i++)
            {
                char str1_char = str1[i];

                if (i <= str2.Length - 1)
                {
                    char str2_char = str2[i];

                    result += str1_char * str2_char;
                }
                else
                {
                    result += str1_char;
                }
            }

            Console.WriteLine(result);
        }
    }
}
