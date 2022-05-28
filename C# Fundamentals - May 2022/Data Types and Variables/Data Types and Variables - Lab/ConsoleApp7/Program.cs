using System;

namespace ConsoleApp7
{
    class Program
    {
        //7.	Concat Names
        //Read two names and a delimiter. Print the names joined by the delimiter.
        //Examples
        //Input   Output
        //John
        //Smith
        //->	  John->Smith
        //Input   Output
        //Jan
        //White
        //<->	  Jan<->White
        //Input   Output
        //Linda
        //Terry
        //=>	  Linda=>Terry

        static void Main()
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string delimiter = Console.ReadLine();

            Console.WriteLine($"{firstName}{delimiter}{lastName}");
        }
    }
}
