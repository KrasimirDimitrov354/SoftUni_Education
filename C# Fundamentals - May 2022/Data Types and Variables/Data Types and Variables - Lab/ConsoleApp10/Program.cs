using System;

namespace ConsoleApp10
{
    class Program
    {
        //10.	Lower or Upper
        //Create a program that prints whether a given character is upper-case or lower case.
        //Examples
        //Input     Output
        //L         upper-case
        //f         lower-case

        static void Main()
        {
            char input = char.Parse(Console.ReadLine());
            bool isUppercase = char.IsUpper(input);

            if (isUppercase)
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
