using System;
using System.Collections.Generic;

namespace Stack_QueueLab6
{
    //Supermarket
    //Read an input consisting of a customer's name and add it to a queue until the "End" command is received.
    //If you receive the command "Paid", print every customer name in the queue and empty it.
    //When you receive "End", print the count of the remaining customers in the queue in the format: "{count} people remaining.".
    //
    //Examples
    //Input     Output                  Input       Output
    //Liam      Liam                    Amelia      3 people remaining.
    //Noah      Noah                    Thomas
    //James     James                   Elias
    //Paid      4 people remaining.     End
    //Oliver
    //Lucas
    //Logan
    //Tiana
    //End

    class Program
    {
        static void Main()
        {
            Queue<string> customers = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    Console.WriteLine($"{customers.Count} people remaining.");
                    break;
                }
                else if (input == "Paid")
                {
                    while (customers.Count > 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                    }
                }
                else
                {
                    customers.Enqueue(input);
                }
            }
        }
    }
}
