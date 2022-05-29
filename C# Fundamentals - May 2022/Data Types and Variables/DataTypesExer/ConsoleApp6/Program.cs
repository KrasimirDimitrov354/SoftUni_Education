using System;

namespace ConsoleApp6
{
    class Program
    {
        //6.	Triples of Latin Letters
        //Create a program that receives an integer n and print all triples of the first n small Latin letters, ordered alphabetically:
        //Examples
        //Input     Output
        //3         aaa
        //          aab
        //          aac
        //          aba
        //          abb
        //          abc
        //          aca
        //          acb
        //          acc
        //          baa
        //          bab
        //          bac
        //          bba
        //          bbb
        //          bbc
        //          bca
        //          bcb
        //          bcc
        //          caa
        //          cab
        //          cac
        //          cba
        //          cbb
        //          cbc
        //          cca
        //          ccb
        //          ccc

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                char firstSymbol = (char)(i + 97);

                for (int j = 0; j < n; j++)
                {
                    char secondSymbol = (char)(j + 97);

                    for (int k = 0; k < n; k++)
                    {
                        char thirdSymbol = (char)(k + 97);

                        Console.WriteLine($"{firstSymbol}{secondSymbol}{thirdSymbol}");
                    }
                }
            }
        }
    }
}
