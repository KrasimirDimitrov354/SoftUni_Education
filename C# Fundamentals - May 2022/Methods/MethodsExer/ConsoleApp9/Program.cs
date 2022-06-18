using System;

namespace ConsoleApp9
{
    class Program
    {
        //Palindrome Integers
        //Create a program that reads positive integers until you receive the "END" command.
        //For each number print whether the number is a palindrome or not. A palindrome is a number that reads the same backward as forward, such as 323 or 1001. 
        //Examples
        //Input     Output  Input   Output
        //123       false   32      false
        //323       true    2       true
        //421       false   232     true
        //121       true    1010    false
        //END               END

        private static bool IsPalindrome(string number)
        {
            bool result = true;

            for (int i = 1; i <= number.Length; i++)
            {
                int forwardDigit = int.Parse(number[i - 1].ToString());

                for (int j = number.Length - i; j == number.Length - i; j++)
                {
                    int backwardDigit = int.Parse(number[j].ToString());

                    if (forwardDigit != backwardDigit)
                    {
                        result = false;
                        break;
                    }
                }

                if (result == false)
                {
                    break;
                }
            }

            return result;
        }

        static void Main()
        {
            string input = "";

            while (true)
            {
                input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                else
                {
                    Console.WriteLine(IsPalindrome(input));
                }
                
            }
        }
    }
}
