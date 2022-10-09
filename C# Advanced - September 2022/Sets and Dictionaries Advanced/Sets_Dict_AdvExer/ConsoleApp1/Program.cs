using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    //Unique Usernames
    //Create a program that reads from the console a sequence of N usernames and keeps a collection only of the unique ones.
    //
    //On the first line you will be given an integer N. On the next N lines you will receive one username per line.
    //Print the collection on the console in order of insertion.
    //
    //Examples
    //Input     Output
    //6         John
    //John      Peter
    //John      Boy1234
    //John
    //Peter
    //John
    //Boy1234
    //
    //Input     Output
    //10        Peter
    //Peter     Maria
    //Maria     George
    //Peter     Sam
    //George    Sara
    //Sam
    //Maria
    //Sara
    //Peter
    //Sam
    //George

    class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }

            foreach (string uniqueName in names)
            {
                Console.WriteLine(uniqueName);
            }
        }
    }
}
