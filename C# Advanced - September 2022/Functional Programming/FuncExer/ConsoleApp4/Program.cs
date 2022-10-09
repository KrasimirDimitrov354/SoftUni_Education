using System;
using System.Linq;

namespace ConsoleApp4
{
    //Applied Arithmetics
    //Create a program that executes some mathematical operations on a given collection.
    //
    //On the first line, you are given a list of numbers. On the next lines you are passed different commands that you need to apply to all the numbers in the list:
    //  •	"add" -> add 1 to each number.
    //  •	"multiply" -> multiply each number by 2.
    //  •	"subtract" -> subtract 1 from each number.
    //  •	"print" -> print the collection.
    //  •	"end" -> ends the input.
    //
    //Examples
    //Input         Output
    //1 2 3 4 5     3 4 5 6 7
    //add
    //add
    //print
    //end
    //
    //Input         Output
    //5 10          9 19
    //multiply
    //subtract
    //print
    //end

    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(num => int.Parse(num))
                .ToArray();

            string operation = Console.ReadLine();

            while (operation != "end")
            {
                if (operation == "print")
                {
                    Console.WriteLine(String.Join(' ', numbers));
                }
                else
                {
                    Func<int[], int[]> performAction = DetermineAction(operation);
                    numbers = performAction(numbers);
                }               

                operation = Console.ReadLine();
            }
        }

        private static Func<int[], int[]> DetermineAction(string operation)
        {
            switch (operation)
            {
                case "add":
                    return numbers => numbers
                    .Select(n => n + 1)
                    .ToArray();
                case "multiply":
                    return numbers => numbers
                    .Select(n => n * 2)
                    .ToArray();
                case "subtract":
                    return numbers => numbers
                    .Select(n => n - 1)
                    .ToArray();
                default:
                    throw new NotImplementedException();
            }            
        }
    }
}
