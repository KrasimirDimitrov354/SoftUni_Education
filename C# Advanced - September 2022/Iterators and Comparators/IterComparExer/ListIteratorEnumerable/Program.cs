﻿using System;
using System.Linq;

namespace ListIteratorEnumerable
{
    //Extend the ListyIterator from the last problem by implementing the IEnumerable<T> interface. Use yield return for the GetEnumerator() method.
    //
    //Add a new command PrintAll that should foreach the collection and print all of the elements on a single line separated by a space.
    //Your program should catch any exceptions thrown because of validations and print their messages instead.
    //
    //Input
    //  •	Input will come from the console as lines of commands.
    //  •	The first line will always be the Create command in the input. 
    //  •	The last command received will always be the END command.
    //Output
    //  •	For every command from the input (except for the END and Create commands), print the result of that command on the console, each on a new line.
    //  •	In the case of Move or HasNext commands print the return value of the method
    //  •	In the case of a Print command, you don’t have to do anything additional as the method itself should already print on the console.
    //  •	In the case of a PrintAll command, you should print all of the elements on a single line separated by spaces.
    //Constraints
    //  •	Do NOT use the GetEnumerator() method from the base class. Use your implementation using "yield return".
    //  •	There will always be only one Create command and it will always be the first command passed.
    //  •	The number of commands received will be between[1…100].
    //  •	The last command will always be the only END command.
    //
    //Examples
    //Input
    //  Create 1 2 3 4 5
    //  Move
    //  PrintAll
    //  END
    //Output
    //  True
    //  1 2 3 4 5
    //
    //Input
    //  Create Stefcho Goshky Peshu
    //  PrintAll
    //  Move
    //  Move
    //  Print
    //  HasNext
    //  END
    //Output
    // Stefcho Goshky Peshu
    // True
    // True
    // Peshu
    // False

    class Program
    {
        static void Main()
        {
            ListyIterator<string> listy = new ListyIterator<string>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray());

            string command = Console.ReadLine();

            while (command != "END")
            {
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listy.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listy.HasNext());
                        break;
                    case "Print":
                    case "PrintAll":
                        try
                        {
                            if (command == "Print")
                            {
                                listy.Print();
                            }
                            else
                            {
                                listy.PrintAll();
                            }
                        }
                        catch (InvalidOperationException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
