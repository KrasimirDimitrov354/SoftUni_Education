using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp7
{
    class Program
    {
        //List Manipulation Advanced
        //Next, we are going to implement more complicated list commands, extending the previous task.
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

                string instruction = commands[0];

                if (instruction == "end")
                {
                    break;
                }
                else
                {
                    switch (instruction)
                    {
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
                }
            }
        }
    }
}
