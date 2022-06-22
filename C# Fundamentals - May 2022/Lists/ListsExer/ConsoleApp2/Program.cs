using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        //Change List
        //Create a program, that reads a list of integers from the console and receives commands to manipulate the list.
        //Your program may receive the following commands:
        //  •	Delete {element} – delete all elements in the array which are equal to the given element.
        //  •	Insert {element} {position} – insert the element at the given position.
        //You should exit the program when you receive the "end" command. Print all numbers in the array separated by a single whitespace.
        //Examples
        //Input                 Output          Input                               Output
        //1 2 3 4 5 5 5 6       1 10 2 3 4 6    20 12 4 319 21 31234 2 41 23 4      20 12 50 319 50 21 31234 2 41 23
        //Delete 5                              Insert 50 2
        //Insert 10 1                           Insert 50 5
        //Delete 5                              Delete 4
        //end                                   end

        private static List<int> DeleteElement(List<int> numbers, int element)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                int numbersElement = numbers[i];

                if (numbersElement == element)
                {
                    numbers.Remove(numbersElement);
                    i--;
                }
            }

            return numbers;
        }

        private static List<int> InsertElement(List<int> numbers, int element, int position)
        {
            List<int> modifiedNumbers = numbers.GetRange(0, position);
            modifiedNumbers.Add(element);

            for (int i = position; i < numbers.Count; i++)
            {
                modifiedNumbers.Add(numbers[i]);
            }

            return modifiedNumbers;
        }

        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                List<string> commands = Console.ReadLine()
                    .Split(' ')
                    .ToList();

                string command = commands[0];

                if (command == "end")
                {
                    Console.WriteLine(string.Join(' ', numbers));
                    break;
                }
                else
                {
                    int element = int.Parse(commands[1]);

                    switch (command)
                    {
                        case "Delete":
                            numbers = DeleteElement(numbers, element);
                            break;
                        case "Insert":
                            int position = int.Parse(commands[2]);
                            numbers = InsertElement(numbers, element, position);
                            break;
                    }
                }
            }
        }
    }
}
