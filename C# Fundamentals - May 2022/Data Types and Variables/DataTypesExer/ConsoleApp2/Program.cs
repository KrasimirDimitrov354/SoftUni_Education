using System;

namespace ConsoleApp2
{
    class Program
    {
        //2.	Sum Digits
        //Create a program that receives a single integer. Your task is to find the sum of its digits.
        //For example: 12345 -> 1+2+3+4+5 = 15
        //Examples
        //Input     Output
        //245678	32
        //97561	    28
        //543	    12

        static void Main()
        {
            string number = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                int digit = int.Parse(number[i].ToString());
                sum += digit;
            }

            Console.WriteLine(sum);
        }
    }
}
