using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_QueueLab2
{
    //Stack Sum
    //Create a program that:
    //  •	Reads an input of integer numbers and adds them to a stack
    //  •	Reads command until "end" is received
    //  •	Prints the sum of the remaining elements of the stack
    //
    //Input
    //  •	On the first line, you will receive an array of integers
    //  •	Until the "end" command is given you will receive commands – a single command and one or two numbers after the command, depending on what command you are given.
    //  •	If the command is "add", you will always receive exactly two numbers after the command which you need to add to the stack.
    //  •	If the command is "remove", you will always receive exactly one number after the command which represents the count of the numbers you need to remove from the stack.
    //      If there are not enough elements skip the command.
    //
    //Output
    //  •	When the command "end" is received, you need to print the sum of the remaining elements in the stack.
    //
    //Examples
    //Input         Output
    //1 2 3 4       Sum: 6
    //adD 5 6
    //REmove 3
    //eNd
    //Input         Output
    //3 5 8 4 1 9   Sum: 16
    //add 19 32
    //remove 10
    //add 89 22
    //remove 4
    //remove 3
    //end 

    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Stack<int> stack = new Stack<int>(numbers);

            while (true)
            {
                string[] command = Console.ReadLine()
                    .ToLower()
                    .Split()                    
                    .ToArray();

                if (command[0] == "end")
                {
                    Console.WriteLine($"Sum: {stack.Sum()}");
                    break;
                }
                else
                {
                    switch (command[0])
                    {
                        case "add":
                            int num1 = int.Parse(command[1]);
                            int num2 = int.Parse(command[2]);

                            stack.Push(num1);
                            stack.Push(num2);
                            break;
                        case "remove":
                            int count = int.Parse(command[1]);

                            if (count <= stack.Count)
                            {
                                for (int i = 0; i < count; i++)
                                {
                                    stack.Pop();
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}
