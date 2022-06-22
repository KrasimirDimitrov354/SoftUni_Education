using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6
{
    class Program
    {
        //List Manipulation Basics
        //Create a program that reads a list of integers. Until you receive "end", you will receive different commands:
        //  •	Add {number}: add a number to the end of the list.
        //  •	Remove {number}: remove a number from the list.
        //  •	RemoveAt {index}: remove a number at a given index.
        //  •	Insert {number}{index}: insert a number at a given index.
        //Note: All the indices will be valid!
        //When you receive the "end" command, print the final state of the list (separated by spaces).
        //Example
        //Input	                    Output
        //4 19 2 53 6 43            4 53 6 8 43 3
        //Add 3
        //Remove 2
        //RemoveAt 1
        //Insert 8 3
        //end
        //Input	                    Output
        //23 1 456 63 32 87 9 32    23 1 14 63 32 87 9 32 1 34
        //Remove 5
        //Add 1
        //Insert 14 2
        //RemoveAt 3
        //Add 34
        //end
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //List Manipulation Advanced
        //Next we are going to implement more complicated list commands, extending the previous task.
        //Again, read a list and keep reading commands until you receive "end":
        //  •	Contains {number} – check if the list contains the number and if so - print "Yes", otherwise print "No such number".
        //  •	PrintEven – print all the even numbers, separated by a space.
        //  •	PrintOdd – print all the odd numbers, separated by a space.
        //  •	GetSum – print the sum of all the numbers.
        //  •	Filter {condition} {number} – print all the numbers that fulfill the given condition. The condition will be either '<', '>', ">=", "<=".
        //After the end command, print the list only if you have made some changes to the original list. Changes are made only from the commands from the previous task.
        //Example
        //Input	                    Output
        //5 34 678 67 5 563 98      No such number
        //Contains 23               5 67 5 563
        //PrintOdd                  1450
        //GetSum                    34 678 67 563 98
        //Filter >= 21
        //end
        //Input	                    Output
        //2 13 43 876 342 23 543    No such number
        //Contains 100              Yes
        //Contains 543              2 876 342
        //PrintEven                 13 43 23 543
        //PrintOdd                  1842
        //GetSum                    43 876 342 543
        //Filter >= 43              2 13 43 23
        //Filter < 100
        //end

        private static void ModifyList(List<int> listToModify, string modification, int modifier)
        {
            switch (modification)
            {
                case "Add":
                    listToModify.Add(modifier);
                    break;
                case "Remove":
                    listToModify.Remove(modifier);
                    break;
                case "RemoveAt":
                    listToModify.RemoveAt(modifier);
                    break;
            }
        }

        private static List<int> ModifyList(List<int> listToModify, int index, int modifier)
        {
            List<int> modifiedList = listToModify.GetRange(0, index);
            modifiedList.Add(modifier);

            for (int i = index; i < listToModify.Count; i++)
            {
                modifiedList.Add(listToModify[i]);
            }

            return modifiedList;
        }

        private static void ContainsNumber(List<int> numbers, int number)
        {
            bool containsNum = false;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == number)
                {
                    containsNum = true;
                    break;
                }
            }

            if (containsNum)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }

        private static void PrintEvenOrOdd(List<int> numbers, string instruction)
        {
            List<int> result = new List<int>();
            instruction = instruction.Replace("Print", "");

            for (int i = 0; i < numbers.Count; i++)
            {
                switch (instruction)
                {
                    case "Even":
                        if (numbers[i] % 2 == 0)
                        {
                            result.Add(numbers[i]);
                        }
                        break;
                    case "Odd":
                        if (numbers[i] % 2 != 0)
                        {
                            result.Add(numbers[i]);
                        }
                        break;
                }

            }

            Console.WriteLine(string.Join(' ', result));
        }

        private static void GetSum(List<int> numbers)
        {
            int result = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                result += numbers[i];
            }

            Console.WriteLine(result);
        }

        private static void FilterElements(List<int> numbers, string condition, int number)
        {
            List<int> filteredList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNum = numbers[i];
                switch (condition)
                {
                    case "<":
                        if (currentNum < number)
                        {
                            filteredList.Add(currentNum);
                        }
                        break;
                    case ">":
                        if (currentNum > number)
                        {
                            filteredList.Add(currentNum);
                        }
                        break;
                    case ">=":
                        if (currentNum >= number)
                        {
                            filteredList.Add(currentNum);
                        }
                        break;
                    case "<=":
                        if (currentNum <= number)
                        {
                            filteredList.Add(currentNum);
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(' ', filteredList));
        }

        private static bool CheckForChanges(List<int> modifiedList, List<int> originalList)
        {
            bool hasChanged = false;

            if (modifiedList.Count != originalList.Count)
            {
                hasChanged = true;
            }
            else
            {
                for (int i = 0; i < modifiedList.Count; i++)
                {
                    int modifiedNum = modifiedList[i];
                    int originalNum = originalList[i];

                    if (modifiedNum != originalNum)
                    {
                        hasChanged = true;
                        break;
                    }
                }
            }

            return hasChanged;
        }

        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> originalNumbers = new List<int>(numbers);
            bool hasChanged = false;

            while (true)
            {
                List<string> commands = Console.ReadLine()
                    .Split(' ')
                    .ToList();

                string instruction = commands[0];

                if (instruction == "end")
                {
                    if (hasChanged)
                    {
                        Console.WriteLine(string.Join(' ', numbers));
                    }
                    
                    break;
                }
                else
                {
                    switch (instruction)
                    {
                        case "Add":
                        case "Remove":
                        case "RemoveAt":
                            {
                                int modifier = int.Parse(commands[1]);
                                ModifyList(numbers, instruction, modifier);
                                break;
                            }
                        case "Insert":
                            {
                                int number = int.Parse(commands[1]);
                                int index = int.Parse(commands[2]);
                                numbers = ModifyList(numbers, index, number);
                                break;
                            }
                        case "Contains":
                            {
                                int number = int.Parse(commands[1]);
                                ContainsNumber(numbers, number);
                                break;
                            }
                        case "PrintEven":
                        case "PrintOdd":
                            {
                                PrintEvenOrOdd(numbers, instruction);
                                break;
                            }
                        case "GetSum":
                            {
                                GetSum(numbers);
                                break;
                            }
                        case "Filter":
                            {
                                string conditionSign = commands[1];
                                int conditionNumber = int.Parse(commands[2]);
                                FilterElements(numbers, conditionSign, conditionNumber);
                                break;
                            }
                    }

                    if (hasChanged == false)
                    {
                        hasChanged = CheckForChanges(numbers, originalNumbers);
                    }
                }
            }
        }
    }
}
