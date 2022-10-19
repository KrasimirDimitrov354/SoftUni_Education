using System;
using System.Linq;

namespace ListIterator
{
    //ListyIterator
    //Create a generic class ListyIterator. The collection which it will iterate through must be received by the constructor.
    //You must store the elements in a List. The class should have three main functions:
    //  •	Move - move an internal index position to the next index in the list.
    //      The method should return true if it has successfully moved the index and false if there is no next index.
    //  •	HasNext - should return true if there is a next index and false if the index is already at the last element of the list.
    //  •	Print - should print the element at the current internal index.
    //      Calling Print on a collection without elements should throw an appropriate exception with the message "Invalid Operation!".
    //
    //By default, the internal index should be pointing to index 0 of the List. Your program should support the following commands:
    //
    //Command               Return Type         Description
    //Create {e1 e2 …}      void                Creates a ListyIterator from the specified collection.
    //                                          In case of a Create command without any elements, create a ListyIterator with an empty collection.
    //
    //Move	                boolean	            This command should move the internal index to the next index.
    //
    //Print                 void	            This command should print the element at the current internal index.
    //
    //HasNext               boolean             Returns whether the collection has the next element.
    //
    //END                   void                Stops the input.
    //
    //Your program should catch any exceptions thrown as per the described validations (calling Print on an empty collection) and print their messages instead.
    //
    //Input
    //  •	Input will come from the console as lines of commands. 
    //  •	The first line will always be the Create command in the input. 
    //  •	The last command received will always be the END command.
    //Output
    //  •	For every command from the input (except for the END and Create commands), print the result of that command on the console, each on a new line.
    //  •	In the case of Move or HasNext commands, print the return value of the methods.
    //  •	In the case of a Print command, you don’t have to do anything additional as the method itself should already print on the console.
    //Constraints
    //  •	There will always be only one Create command and it will always be the first command passed.
    //  •	The number of commands received will be between [1…100].
    //  •	The last command will always be the only END command.
    //
    //Examples
    //Input                     Output
    //Create                    Invalid Operation!
    //Print
    //END
    //
    //Input                     Output
    //Create Steve George       True
    //HasNext                   Steve
    //Print                     True
    //Move                      George
    //Print
    //END
    //
    //Input                     Output
    //Create 1 2 3              True
    //HasNext                   True
    //Move                      True
    //HasNext                   True
    //HasNext                   True
    //Move                      False
    //HasNext
    //END

    public class Program
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
                        try
                        {
                            listy.Print();
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
