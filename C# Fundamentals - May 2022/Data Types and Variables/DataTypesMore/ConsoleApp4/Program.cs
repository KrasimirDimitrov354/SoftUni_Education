using System;

namespace ConsoleApp4
{
    class Program
    {
        //4. Refactoring: Prime Checker
        //You are given a program that checks if numbers in a given range[2...N] are prime. For each number is printed "{number} -> {true or false}".
        //The code, however, is not very well written. Your job is to modify it in a way that is easy to read and understand.
        //Code
        //Sample Code
        //int ___Do___ = int.Parse(Console.ReadLine());
        //for (int takoa = 2; takoa <= ___Do___; takoa++)
        //{
        //   bool takovalie = true;
        //   for (int cepitel = 2; cepitel<takoa; cepitel++)
        //   {
        //       if (takoa % cepitel == 0)
        //       {
        //          takovalie = false;
        //          break;
        //       }
        //   }
        //Console.WriteLine("{0} -> {1}", takoa, takovalie);
        //}
        //Examples
        //Input	Output
        //5	    2 -> true
        //      3 -> true
        //      4 -> false
        //      5 -> true

        static void Main()
        {
            int rangeEnd = int.Parse(Console.ReadLine());

            for (int i = 2; i <= rangeEnd; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    Console.WriteLine($"{i} -> true");
                }
                else
                {
                    Console.WriteLine($"{i} -> false");
                }
                
            }
        }
    }
}
