using System;

namespace ConsoleApp1
{
    //Reverse Strings
    //You will be given a series of strings until you receive an "end" command.
    //Write a program that reverses strings and prints each pair on a separate line in the format "{word} = {reversed word}".
    //Examples
    //Input     Output
    //helLo     helLo = oLleh
    //Softuni   Softuni = inutfoS
    //bottle    bottle = elttob
    //end 
    //
    //Input     Output
    //Dog       Dog = goD
    //caT       caT = Tac
    //chAir     chAir = riAhc
    //end 

    class Program
    {
        static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }
                else
                {
                    string reverse = "";

                    for (int i = input.Length - 1; i >= 0; i--)
                    {
                        reverse += input[i].ToString();
                    }

                    Console.WriteLine($"{input} = {reverse}");
                }               
            }
        }
    }
}
