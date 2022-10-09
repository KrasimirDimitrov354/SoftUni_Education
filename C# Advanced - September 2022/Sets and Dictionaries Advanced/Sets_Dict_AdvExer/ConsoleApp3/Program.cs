using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    //Periodic Table
    //Create a program that keeps all the unique chemical elements.
    //
    //On the first line you will be given a number n - the count of input lines that you are going to receive.
    //On the next n lines you will be receiving chemical compounds separated by a single space. Your task is to print all the unique ones in ascending order.
    //Examples
    //Input     Output          Input           Output
    //4         Ce Ee Mo O      3               Ch Ge Mo Nb Ne O Tc
    //Ce O                      Ge Ch O Ne
    //Mo O Ce                   Nb Mo Tc
    //Ee                        O Ne
    //Mo

    class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());

            SortedSet<string> uniqueCompounds = new SortedSet<string>();

            for (int i = 0; i < lines; i++)
            {
                string[] compounds = Console.ReadLine().Split();

                for (int j = 0; j < compounds.Length; j++)
                {
                    string currentCompound = compounds[j];
                    uniqueCompounds.Add(currentCompound);
                }
            }

            foreach (string uniqueCompound in uniqueCompounds)
            {
                Console.Write($"{uniqueCompound} ");
            }
        }
    }
}
