using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    //Record Unique Names
    //Create a program, which will take a list of names and print only the unique names in the list.
    //
    //Examples
    //Input     Output
    //8         John
    //John      Alex
    //Alex      Sam
    //John      Alice
    //Sam       Peter
    //Alex
    //Alice
    //Peter
    //Alex 
    //
    //Input     Output
    //7         Lyle
    //Lyle      Bruce
    //Bruce     Alice
    //Alice     Easton
    //Easton    Shawn
    //Shawn
    //Alice
    //Shawn
    //Peter
    //
    //Input     Output
    //6         Roki
    //Roki
    //Roki
    //Roki
    //Roki
    //Roki
    //Roki

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
