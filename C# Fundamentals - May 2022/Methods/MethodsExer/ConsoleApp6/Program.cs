using System;

namespace ConsoleApp6
{
    class Program
    {
        //Middle Characters
        //You will receive a single string. Create a method that prints the character found at its middle.
        //If the length of the string is even there are two middle characters.
        //Examples
        //Input     Output
        //aString   r
        //someText  eT
        //3245	    24

        private static void FindMiddle(string input)
        {
            char[] characters = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                characters[i] = input[i];
            }

            if (input.Length % 2 == 0)
            {
                Console.WriteLine($"{characters[(input.Length / 2) - 1]}{characters[input.Length / 2]}");
            }
            else
            {
                Console.WriteLine(characters[input.Length / 2]);
            }
        }

        static void Main()
        {
            string input = Console.ReadLine();
            FindMiddle(input);
        }
    }
}
