using System;

namespace ConsoleApp2
{
    class Program
    {
        //2.	English Name of the Last Digit
        //Create a method that returns the English spelling of the last digit of a given number.
        //Write a program that reads an integer and prints the returned value from this method.
        //Examples
        //Input     Output
        //512	    two
        //1	        one
        //1643	    three

        static void Main()
        {
            string input = Console.ReadLine();
            char digit = input[input.Length - 1];

            switch (digit)
            {
                case '0':
                    Console.WriteLine("zero");
                    break;
                case '1':
                    Console.WriteLine("one");
                    break;
                case '2':
                    Console.WriteLine("two");
                    break;
                case '3':
                    Console.WriteLine("three");
                    break;
                case '4':
                    Console.WriteLine("four");
                    break;
                case '5':
                    Console.WriteLine("five");
                    break;
                case '6':
                    Console.WriteLine("six");
                    break;
                case '7':
                    Console.WriteLine("seven");
                    break;
                case '8':
                    Console.WriteLine("eight");
                    break;
                case '9':
                    Console.WriteLine("nine");
                    break;
            }
        }
    }
}
