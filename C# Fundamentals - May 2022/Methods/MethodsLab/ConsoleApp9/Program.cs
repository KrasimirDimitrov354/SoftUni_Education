using System;

namespace ConsoleApp9
{
    class Program
    {
        //Greater of Two Values
        //You are given an input of two values of the same type. The values can be of type int, char, or string.
        //Create methods called GetMax(), which can compare int, char or string and returns the biggest of the two values.
        //Examples
        //Input     Output
        //int       16
        //2
        //16
        //Input     Output
        //char      z
        //a
        //z
        //Input     Output
        //string    bbb
        //aaa
        //bbb 

        private static void GetMax(int num1, int num2)
        {
            if (num1 > num2)
            {
                Console.WriteLine(num1);
            }
            else
            {
                Console.WriteLine(num2);
            }
        }

        private static void GetMax(char char1, char char2)
        {
            int result = char1.CompareTo(char2);

            if (result > 0)
            {
                Console.WriteLine(char1);
            }
            else
            {
                Console.WriteLine(char2);
            }
        }

        private static void GetMax(string string1, string string2)
        {
            int result = string1.CompareTo(string2);

            if (result > 0)
            {
                Console.WriteLine(string1);
            }
            else
            {
                Console.WriteLine(string2);
            }
        }

        static void Main()
        {
            string valueType = Console.ReadLine();

            switch (valueType)
            {
                case "int":
                    int firstNum = int.Parse(Console.ReadLine());
                    int secondNum = int.Parse(Console.ReadLine());
                    GetMax(firstNum, secondNum);
                    break;
                case "char":
                    char firstChar = char.Parse(Console.ReadLine());
                    char secondChar = char.Parse(Console.ReadLine());
                    GetMax(firstChar, secondChar);
                    break;
                case "string":
                    string firstString = Console.ReadLine();
                    string secondString = Console.ReadLine();
                    GetMax(firstString, secondString);
                    break;
            }
        }
    }
}
