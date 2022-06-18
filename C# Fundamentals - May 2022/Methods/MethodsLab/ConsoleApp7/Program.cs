using System;

namespace ConsoleApp7
{
    class Program
    {
        //Repeat String
        //Create a method that receives two parameters:
        //  •	A string 
        //  •	A number n (integer) that represents how many times the string will be repeated.
        //The method should return a new string containing the initial one repeated n times without space.
        //Example
        //Input     Output
        //abc       abcabcabc
        //3
        //Input     Output
        //String    StringString
        //2	

        private static string Repeat(string text, int repeats)
        {
            string output = "";

            for (int i = 0; i < repeats; i++)
            {
                output += text;
            }

            return output;
        }

        static void Main()
        {
            string input = Console.ReadLine();
            int repetition = int.Parse(Console.ReadLine());
            string result = Repeat(input, repetition);
            Console.WriteLine(result);
        }
    }
}
