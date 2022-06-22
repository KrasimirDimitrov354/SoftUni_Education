using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        //List Operations
        //The first input line will hold a list of integers. Until we receive the "End" command, we will be given operations we have to apply to the list.
        //The possible commands are:
        //  •	Add {number} – add the given number to the end of the list
        //  •	Insert {number} {index} – insert the number at the given index
        //  •	Remove {index} – remove the number at the given index
        //  •	Shift left {count} – first number becomes last. This has to be repeated the specified number of times
        //  •	Shift right {count} – last number becomes first. To be repeated the specified number of times
        //Note: the index given may be outside of the bounds of the array. In that case print: "Invalid index".
        //
        //Examples
        //Input	                    Output              Input	                    Output
        //1 23 29 18 43 21 20       43 20 5 1 23 29 18  5 12 42 95 32 1             Invalid index
        //Add 5                                         Insert 3 0                  5 12 42 95 32 8 1 3
        //Remove 5                                      Remove 10
        //Shift left 3                                  Insert 8 6
        //Shift left 1                                  Shift right 1
        //End                                           Shift left 2
        //                                              End

        private static bool IndexIsValid(List<int> numbers, int index)
        {
            bool isValid = true;

            if (index < 0 || index >= numbers.Count)
            {
                Console.WriteLine("Invalid index");
                isValid = false;
            }

            return isValid;
        }

        private static List<int> InsertNumber(List<int> numbers, int element, int index)
        {
            List<int> modifiedNumbers = numbers.GetRange(0, index);
            modifiedNumbers.Add(element);

            for (int i = index; i < numbers.Count; i++)
            {
                modifiedNumbers.Add(numbers[i]);
            }

            return modifiedNumbers;
        }

        private static List<int> ShiftNumbers(List<int> numbers, string direction, int count)
        {
            int numberToShift = 0;

            for (int i = 0; i < count; i++)
            {
                switch (direction)
                {
                    case "left":
                        {
                            numberToShift = numbers[0];
                            numbers.RemoveAt(0);
                            numbers.Add(numberToShift);
                            break;
                        }
                    case "right":
                        {
                            numberToShift = numbers[numbers.Count - 1];
                            numbers.RemoveAt(numbers.Count - 1);
                            numbers.Insert(0, numberToShift);
                            break;
                        }
                }
            }

            return numbers;
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

                if (command == "End")
                {
                    Console.WriteLine(string.Join(' ', numbers));
                    break;
                }
                else
                {
                    switch (command)
                    {
                        case "Add":
                            {
                                int number = int.Parse(commands[1]);
                                numbers.Add(number);
                                break;
                            }
                        case "Insert":
                            {
                                int numToInsert = int.Parse(commands[1]);
                                int index = int.Parse(commands[2]);

                                if (IndexIsValid(numbers, index))
                                {
                                    numbers = InsertNumber(numbers, numToInsert, index);
                                }
                                break;
                            }
                        case "Remove":
                            {
                                int indexToRemove = int.Parse(commands[1]);

                                if (IndexIsValid(numbers, indexToRemove))
                                {
                                    numbers.RemoveAt(indexToRemove);
                                }
                                break;
                            }
                        case "Shift":
                            {
                                string direction = commands[1];
                                int count = int.Parse(commands[2]);
                                numbers = ShiftNumbers(numbers, direction, count);
                                break;
                            }
                    }
                }
            }
        }
    }
}
